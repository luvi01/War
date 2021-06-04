using UnityEngine;
using System.Collections;

public class UI_Era : MonoBehaviour
{
    GameManager gm;
    private float _lastShootTimestamp = 0.0f;
    public float shootDelay = 2.5f;

    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnTank()
    {
        if (Time.time - _lastShootTimestamp < shootDelay) return;
        //AudioManager.PlaySFX(shootSFX);

        if (gm.playerMoney < 20) return;

        gm.playerMoney -= 20;
        _lastShootTimestamp = Time.time;

        gm.playerTankSpawState = true;
    }
}
