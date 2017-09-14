using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDemage : MonoBehaviour
{

    // 子弹碰撞进入检测后，attack，再调取player的takedemage
    // 就是调用另一脚本的函数
    // 写得不好，要两种子弹
    public int attackDamage;

    GameObject victim;
    private string shooter;
    private string hitID;

    void OnTriggerEnter(Collider other)
    {
        // 因为player里的model也有个collider，就用个if了
        // 关键是不会从model推出player1，所以又弄多了一个boxCollider
        if (other.gameObject.GetComponentInParent<SimpleMove>())//GetComponent<SimpleMove>())
        {
            hitID = other.gameObject.GetComponentInParent<SimpleMove>().playerID;
            shooter = gameObject.GetComponent<BulletMove>().GetParentName();

            if (hitID == shooter)
            {
                Debug.Log("noHurt");
            }
            else
            {
                victim = other.gameObject;
                Debug.Log("hurt");
                Attack(hitID, attackDamage);
            }
        }
    }

    void Attack(string hitID, int attackDamage)
    {
        Destroy(gameObject);
        PlayerStatusController.playerHealth[hitID] -= attackDamage;
        Debug.Log(PlayerStatusController.playerHealth[hitID]);
    }
}
    