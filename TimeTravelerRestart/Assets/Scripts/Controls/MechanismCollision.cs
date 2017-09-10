using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismCollision : MonoBehaviour {
    public GameObject mechanism;
    public GameObject thisGameObject;
	public ParticleSystem particles;
    void OnTriggerEnter(Collider collider) {
        GameObject cloneMechanism = Instantiate(mechanism, new Vector3(transform.position.x, collider.transform.position.y, transform.position.z), new Quaternion());
        cloneMechanism.GetComponent<ChildrenBulletParentNameSetterTool>().SetParentName(collider.GetComponent<SimpleMove>().playerID);
        Debug.Log("机关被触发");
		Destroy(thisGameObject);

		// 播放粒子效果
		particles.gameObject.SetActive (true);
		Destroy (particles.gameObject, 3.0f);
    }
}
