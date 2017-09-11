using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDemage : MonoBehaviour {

    // 子弹碰撞进入检测后，attack，再调取player的takedemage
    // 就是调用另一脚本的函数
    // 写得不好，要两种子弹
    public int attackDamage;
    public string target;
    GameObject victim;                          // Reference to the player GameObject.

    // Use this for initialization
    void Awake () {
        victim = GameObject.FindGameObjectWithTag(target);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == target)
        {
            Debug.Log(victim.name);
            Attack(attackDamage);
        }  
    }

    void Attack(int attackDamage)
    {
        // Reset the timer.
        //timer = 0f;

        // If the player has health to lose...
        //if (playerHealth.currentHealth > 0)
        //{
        // ... damage the player.
        //playerHealth.TakeDamage(attackDamage);
        Debug.Log("Hit");
        Destroy(gameObject);
        victim.SendMessage("TakeDamage", attackDamage);
        //}
    }
}
