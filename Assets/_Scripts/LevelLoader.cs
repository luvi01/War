using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public float transitionTime = 1f;

    public Animator transition;
    public GameManager gm;

    // Update is called once per frame
    void Update()
    {
        gm = GameManager.GetInstance();

        if(gm.playerBaseHealth <= 0)
        {
            SceneManager.LoadScene("End");
            gm.playerBaseHealth = 10;
            gm.playerMoney = 50;
        }

        if(gm.enemyBaseHealth <= 0)
        {
            LoadNextLevel();
            gm.enemyBaseHealth = 10;
        }

        // if(Input.GetKeyDown(KeyCode.Alpha3) || gm.playerBaseHealth < 0)
        // {
        //     if(SceneManager.GetActiveScene().buildIndex == 3)
        //     {
        //         Debug.Log("ACABOU!");
        //     } 
        //     else 
        //     {
        //         LoadNextLevel();
        //         gm.enemyBaseHealth = 5;
        //     }
            
        // }
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
