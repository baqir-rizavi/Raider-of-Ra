using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    float health = 20f;
    [SerializeField]
    float attackPower = 5f;
    public void damage(float damage)
    {
        health -= damage;
        if (health <= 0)
            kill();
    }
    void kill()
    {
        // do stuff here
        Destroy(gameObject);
    }
}
