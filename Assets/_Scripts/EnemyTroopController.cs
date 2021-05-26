using System.Collections;
using System.Collections.Generic;
using helper;
using UnityEngine;

public class EnemyTroopController : MonoBehaviour, IDamageable
{
    public int speed;
    public Animator animator;
    public int castDist;
    public Transform castPoint;
    private LineDrawer lineDrawer;
    private bool walking = true;
    private bool attack = false;
    public int life = 10;
    public GameObject enemyObject;
    public int damage = 1;


    // Start is called before the first frame update
    void Start()
    {
        lineDrawer = new LineDrawer();
    }

    void FixedUpdate()
    {
        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 15;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        // Does the ray intersect any objects excluding the player layer
        Vector2 endPos = castPoint.position + Vector3.right * castDist;

        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, layerMask);
        if (hit.collider != null)
        {
            //Debug.DrawLine(castPoint.position, hit.point, Color.yellow);
            //lineDrawer.DrawLineInGameView(castPoint.position, hit.point, Color.yellow);
            Debug.Log("Did Hit");
            walking = false;
            if (hit.collider.gameObject.CompareTag("PlayerTroops"))
            {
                enemyObject = hit.collider.gameObject;
                Debug.Log("Attacaca");
                attack = true;
            }
        }
        else
        {
            //Debug.DrawLine(castPoint.position, endPos, Color.red);
            //lineDrawer.DrawLineInGameView(castPoint.position, endPos, Color.red);
            walking = true;
            attack = false;

            Debug.Log("Did not Hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attack)
        {

            animator.SetFloat("Attack", 1.0f);
            Invoke("giveDamage", 3f);
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
        }

    }

    public void TakeDamage(int damage)
    {
        life -= damage;
    }

    public void Die()
    {
        Debug.Log("MORRI");
        animator.SetFloat("Death", 1.0f);
        walking = false;
        attack = false;
        Invoke("newVoid", 3f);
    }

    void giveDamage()
    {
        if(!(enemyObject == null))
        {
            IDamageable damageable = enemyObject.gameObject.GetComponent(typeof(IDamageable)) as IDamageable;
            if (!(damageable is null))
            {
                Debug.Log("Dei damage!");

                damageable.TakeDamage(damage);
            }
        }
        
    }

    void newVoid()
    {
        Destroy(gameObject);
    }
}
