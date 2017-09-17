using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    //public Boundary boundary;

    void OnTriggerExit(Collider other)
    {
        BoxCollider box = gameObject.GetComponent<BoxCollider>();
        Debug.Log(other);

        // 子弹从另一边穿回来不会写……再想想
        //other.gameObject.transform.position = new Vector3(-box.size.x, 0, 0);
        //Destroy(other.gameObject);
    }
}
