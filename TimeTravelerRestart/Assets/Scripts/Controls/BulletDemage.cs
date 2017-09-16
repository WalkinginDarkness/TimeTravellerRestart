using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDemage : MonoBehaviour
{

    // 子弹碰撞进入检测后，attack，再调取player的takedemage
    // 就是调用另一脚本的函数
    // 写得不好，要两种子弹
    public int attackDamage;

    GameObject hitObject;
    private string shooter;
    private string hitID;

    void OnTriggerEnter(Collider other)
    {
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
                hitObject = other.gameObject;
                Debug.Log("hurt");
                Attack(hitObject, attackDamage);
            }
        }
    }

    void Attack(GameObject hitObject, int attackDamage)
    {
        Destroy(gameObject);
        string hitID = hitObject.GetComponentInParent<SimpleMove>().playerID;
        PlayerStatusController.playerHealth[hitID] -= attackDamage;
        Debug.Log(PlayerStatusController.playerHealth[hitID]);

        if (PlayerStatusController.playerHealth[hitID] <= 0)
        {
            hitObject.SendMessage("Death");
        }
    }
}
    