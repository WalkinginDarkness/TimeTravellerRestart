using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDemage : MonoBehaviour
{
    public int attackDamage;
    public ParticleSystem explosionEffect;
    public AudioClip clip_小爆炸;

    GameObject hitObject;
    private string shooter;
    private string hitID;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
                // 触发粒子效果
                var boom = Instantiate(explosionEffect, transform.position, Quaternion.LookRotation(Vector3.up));
                boom.Play();
                Destroy(boom, 4);
                // 播放爆炸声音
                audioSource.clip = clip_小爆炸;
                
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
    