using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismCollision : MonoBehaviour {
    public GameObject mechanism;
    public GameObject thisGameObject;
	public ParticleSystem particles;
    void OnTriggerEnter(Collider collider) {

        Debug.Log(collider.tag);
        if (collider.tag == "Player1" || collider.tag == "Player2")
        {
            GameObject cloneMechanism = Instantiate(mechanism, new Vector3(transform.position.x, collider.transform.position.y + 3, transform.position.z), new Quaternion());
            // 机关被子弹触发后有bug：Object reference not set to an instance of an object
            cloneMechanism.GetComponent<ChildrenBulletParentNameSetterTool>().SetParentName(collider.GetComponent<SimpleMove>().playerID);
            Debug.Log("机关被触发");
            Debug.Log(collider.GetComponent<SimpleMove>().playerID);
            Destroy(thisGameObject);

            // 播放粒子效果
            particles.gameObject.SetActive(true);
            Destroy(particles.gameObject, 3.0f);
        }
        else if (collider.tag == "Bullet")
        {
            Destroy(collider.gameObject);
        }
    }
}
