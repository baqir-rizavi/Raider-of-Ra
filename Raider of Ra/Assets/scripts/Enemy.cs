using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 20f;
    float curHealth = 20f;
    [SerializeField]
    float attackPower = 5f;

    GameObject playerArmature;
    ThirdPersonShooter player;

    [Header("HealthBar")]
    [SerializeField] Image healthBar;
    [SerializeField] Canvas healthBarCanvas;


    private void Awake()
    {
        curHealth = health;
        playerArmature = GameObject.FindGameObjectWithTag("Player");
        player = playerArmature.GetComponent<ThirdPersonShooter>();
        healthBarCanvas.worldCamera = Camera.main;
    }

    public static float NormalizeRange(float value, float min, float max)
    {
        return (value - min) / (max - min);
    }
    public void damage(float damage)
    {
        curHealth -= damage;
        healthBar.fillAmount = NormalizeRange(curHealth, 0, health);
        if (curHealth <= 0)
            kill();
    }
    void kill()
    {
        // do stuff here
        Destroy(gameObject);
    }

    public void OnEnemyAttack(AnimationEvent animationEvent)
    {
        Debug.Log("player hit");
        player.damage(attackPower);
    }
}
