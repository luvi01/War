﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_Tank : MonoBehaviour
{
    GameManager gm;
    private float _lastShootTimestamp = 0.0f;
    public float shootDelay = 2.5f;
    public Button tankButton;

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
            tankButton.interactable = false;
        } else {
            tankButton.interactable = true;
        }

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
