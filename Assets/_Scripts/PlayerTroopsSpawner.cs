using UnityEngine;
using System.Collections;

public class PlayerTroopsSpawner : MonoBehaviour
{
    public GameObject infantary;
    public GameObject tank;

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


    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();
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

    // Update is called once per frame
    void Update()
    {
        //if (gm.gameState != GameManager.GameState.GAME &
        //     gm.gameState != GameManager.GameState.RESUME) return;
        if (!spawn) return;

        if (gm.playerInfantarySpawState)
        {
            GameObject newInfantary = Instantiate(infantary);
            newInfantary.transform.position = transform.position + new Vector3(0, 0, 1);
            timer = 0;
            gm.playerInfantarySpawState = false;
        }

        if (gm.playerTankSpawState)
        {
            GameObject newTank = Instantiate(tank);
            newTank.transform.position = transform.position + new Vector3(0, 0, 1);
            timer = 0;
            gm.playerTankSpawState = false;
        }

        
        //timer += Time.deltaTime;
    }
}
