using UnityEngine;
using System.Collections;

public class EnemyTroopsSpawner : MonoBehaviour
{
    public GameObject tube;
    public float height;
    public float maxTimer = 1;
    public float timer = 1;
    public bool state = false;
    private GameManager gm;
    private float _lastShootTimestamp = 0.0f;
    public float shootDelay = 2.5f;
    public int castDist;
    public Transform castPoint;
    public bool spawn = true;
    public int level = 5;


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
            spawn = false;
            //if (hit.collider.gameObject.CompareTag("EnemyTroops"))
            //{
            //    enemyObject = hit.collider.gameObject;
            //    Debug.Log("Attacaca");
            //    attack = true;
            //}
        }
        else
        {
            //Debug.DrawLine(castPoint.position, endPos, Color.red);
            //lineDrawer.DrawLineInGameView(castPoint.position, endPos, Color.red);
            spawn = true;


            Debug.Log("Did not Hit");
        }
    }

    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        // if (gm.gameState != GameManager.GameState.GAME &
        //      gm.gameState != GameManager.GameState.RESUME) return;

        SpawnInfantary();
        if (state && level>0)
        {
            GameObject newTube = Instantiate(tube);
            newTube.transform.position = transform.position + new Vector3(0, 0, 1);
            timer = 0;
            state = false;
            level -= 1;
        }
        //timer += Time.deltaTime;
    }

    public void SpawnInfantary()
    {
        if (!spawn)
        {
            Debug.Log("BARREIRA");
            return;
        } 

        if (Time.time - _lastShootTimestamp < shootDelay) return;
        //AudioManager.PlaySFX(shootSFX);

        if (gm.enemyMoney < 10) return;

        gm.enemyMoney -= 10;
        _lastShootTimestamp = Time.time;

        state = true;
    }
}
