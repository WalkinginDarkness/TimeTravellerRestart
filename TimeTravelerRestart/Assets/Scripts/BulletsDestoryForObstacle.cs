using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsDestoryForObstacle : MonoBehaviour {
    void OnTriggerStay(Collider collider) {
        Debug.Log(collider.tag);
        if (collider.tag == "Bullet") {
            Destroy(collider.gameObject);
        }
    }
}
