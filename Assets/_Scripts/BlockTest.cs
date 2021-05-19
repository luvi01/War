using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTest : MonoBehaviour, IDamageable
{
    public int life = 5;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("aAAAAAAAAAA");
        life -= damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
