﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDemage : MonoBehaviour
{
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

        Debug.Log(hitObject);
        if (PlayerStatusController.playerHealth[hitID] <= 0)
        {
            // 这是调用player脚本里的函数来销毁，也许方便播放音效什么的
            if (hitObject.name == "Model")
            {
                hitObject.transform.parent.gameObject.GetComponent<SimpleMove>().SendMessage("Death");
            }
            else if (hitObject.name == "player1" || hitObject.name == "player2")
            {
                hitObject.GetComponent<SimpleMove>().SendMessage("Death");
            }


            // 这是直接在bulletDemage脚本销毁
            // Destroy(hitObject);
        }
    }
}
    