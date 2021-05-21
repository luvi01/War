using UnityEngine;
using System.Collections;

public class EnemyTroopsSpawner : MonoBehaviour
{
    public GameObject tube;
    public float height;
    public float maxTimer = 1;
    public float timer = 1;
    public bool state = false;
    //private GameManager gm;


    // Use this for initialization
    void Start()
    {
        //gm = GameManager.GetInstance();
        GameObject newTube = Instantiate(tube);
        newTube.transform.position = transform.position + new Vector3(0, 0, 1);

    }

    // Update is called once per frame
    void Update()
    {
        //if (gm.gameState != GameManager.GameState.GAME &
        //     gm.gameState != GameManager.GameState.RESUME) return;

        if (state)
        {
            GameObject newTube = Instantiate(tube);
            newTube.transform.position = transform.position + new Vector3(0, 0, 1);
            timer = 0;
            state = false;
        }
        //timer += Time.deltaTime;
    }
}
