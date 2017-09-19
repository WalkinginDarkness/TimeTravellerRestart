using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsDestoryForObstacle : MonoBehaviour {
    void OnTriggerEnter(Collider collider) {
        Debug.Log(collider.name + ":" + collider.tag);
        if (collider.tag == "Bullet") {
            Destroy(collider.gameObject);
        }
    }
}
