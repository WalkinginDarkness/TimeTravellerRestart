using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanismCollision : MonoBehaviour {
    public GameObject mechanism;
    public GameObject thisGameObject;
    void OnTriggerEnter(Collider collider) {
        
        GameObject cloneMechanism = Instantiate(mechanism, new Vector3(transform.position.x, collider.transform.position.y, transform.position.z), new Quaternion());
        cloneMechanism.GetComponent<Name123>().SetParentName(collider.GetComponent<SimpleMove>().playerID);
        Debug.Log("机关被触发");
        Destroy(thisGameObject);
    }
}
