using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseController : MonoBehaviour, IDamageable
{
    public int life = 10;

    public GameManager gm;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        gm.playerBaseHealth = life;
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        gm.playerBaseHealth = life;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Die();
        }

    }
}
