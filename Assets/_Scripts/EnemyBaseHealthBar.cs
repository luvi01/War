using UnityEngine;
using System.Collections;

public class EnemyBaseHealthBar : MonoBehaviour
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
        currentHealth = gm.enemyBaseHealth;
        healthBar.SetHealth(currentHealth);
        Debug.Log("BASE HEALTH UPDATE:" + currentHealth);

    }
}
