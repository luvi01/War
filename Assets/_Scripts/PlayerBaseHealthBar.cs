using UnityEngine;
using System.Collections;

public class PlayerBaseHealthBar : MonoBehaviour
{
    public GameManager gm;

    // Health Bar
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;

    // Use this for initialization
    void Start()
    {
        gm = GameManager.GetInstance();
        //maxHealth = gm.playerBaseHealth;
        Debug.Log("BASE HEALTH:"+ maxHealth);
        healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = gm.playerBaseHealth;
        healthBar.SetHealth(currentHealth);
        Debug.Log("BASE HEALTH UPDATE:" + currentHealth);

    }
}
