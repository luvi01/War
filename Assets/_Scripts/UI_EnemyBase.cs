using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_EnemyBase : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        textComp.text = "Vida da base inimiga: "+ gm.enemyBaseHealth;
    }
}
