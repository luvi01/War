using System.Collections;
using System.Collections.Generic;
using helper;
using UnityEngine;

public class ArcherController : MonoBehaviour, IDamageable
{
    public int speed;
    public Animator animator;
    public int castDist;
    public int friendDist;
    public Transform castPoint;
    private LineDrawer lineDrawer;
    private bool walking = true;
    private bool attack = false;
    public int life = 10;
    public GameObject enemyObject;
    public int damage = 1;
    private float _lastShootTimestamp = 0.0f;
    public float shootDelay = 2.5f;
    GameManager gm;
    public int money;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        lineDrawer = new LineDrawer();
        gm = GameManager.GetInstance();
    }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 10;

        int friendMask = 1 << 15;


        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        friendMask = ~friendMask;

        // Does the ray intersect any objects excluding the player layer
        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, layerMask);

        // Does the ray intersect any objects excluding the player layer
        Vector2 friendEndPos = castPoint.position + Vector3.right * friendDist;

        RaycastHit2D friendHit = Physics2D.Linecast(castPoint.position, friendEndPos, friendMask);

        if (hit.collider != null)
        {
            //Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
            //lineDrawer.DrawLineInGameView(castPoint.position, hit.point, Color.yellow);
            Debug.Log("Did Hit");
            if (hit.collider.gameObject.CompareTag("EnemyTroops"))
            {
                Debug.Log("AAAAAIAJIJIAJIC:"+ walking);
                enemyObject = hit.collider.gameObject;
                Debug.Log("Attacaca");
                attack = true;
            }
        }
        else
        {
            //Debug.DrawLine(castPoint.position, endPos, Color.red);
            //lineDrawer.DrawLineInGameView(castPoint.position, endPos, Color.red);
            //walking = true;
            attack = false;

            Debug.Log("Did not Hit");
        }

        if (friendHit.collider != null)
        {
            //Debug.DrawLine(castPoint.position, friendHit.point, Color.yellow);
            //lineDrawer.DrawLineInGameView(castPoint.position, friendHit.point, Color.yellow);
            //Debug.Log("Did Hit");
            walking = false;
        }
        else
        {
            //Debug.DrawLine(castPoint.position, friendEndPos, Color.red);
            //lineDrawer.DrawLineInGameView(castPoint.position, friendEndPos, Color.black);
            walking = true;
            Debug.Log("Did not Hit");
        }
    }

    public void Shoot()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        //AudioManager.PlaySFX(shootSFX);

        _lastShootTimestamp = Time.time;

        giveDamage();
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {
            animator.SetFloat("Attack", 1.0f);
            Shoot();
        }

        if (!attack)
        {
            animator.SetFloat("Attack", -1.0f);
        }

        if (walking)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            animator.SetFloat("Walk", 1.0f);
        }

        if (!walking)
        {
            animator.SetFloat("Walk", -1.0f);
        }

        if (life <= 0)
        {
            Die();
            animator.SetFloat("Death", 1.0f);
        }

    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    public void Die()
    {
        Debug.Log("MORRI");
        walking = false;
        attack = false;
        gm.enemyMoney += money;
        Destroy(gameObject);
    }

    void giveDamage()
    {
        IDamageable damageable = enemyObject.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
        if (!(damageable is null))
        {
            Debug.Log("Dei damage!");

            damageable.TakeDamage(damage);
        }
    }

    void newVoid()
    {
        Destroy(gameObject);
    }
}
