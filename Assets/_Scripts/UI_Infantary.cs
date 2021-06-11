using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Infantary : MonoBehaviour
{
    GameManager gm;
    private float _lastShootTimestamp = 0.0f;
    public float shootDelay = 2.5f;
    public Button goblinButton;

    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.playerMoney < 20)
        {
            goblinButton.interactable = false;
        } else {
            goblinButton.interactable = true;
        }

    }

    public void SpawnInfantary()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        //AudioManager.PlaySFX(shootSFX);

        if (gm.playerMoney < 10) return;

        gm.playerMoney -= 10;
        _lastShootTimestamp = Time.time;

        gm.playerInfantarySpawState = true;
    }
}
