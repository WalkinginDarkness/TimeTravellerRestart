using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletDestroyStyle
{
    DirectDestroy,
    LoopTeleport
};
public class DestroyByBoundary : MonoBehaviour {

    BoxCollider boundary;

    [SerializeField]
    public BulletDestroyStyle bulletDestroyStyle;


    void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.transform.position);
        //Debug.Log(other.gameObject.transform.forward);

        if (other.gameObject.tag == "Bullet")
        {
            boundary = this.GetComponent<BoxCollider>();
            GameObject bullet = other.gameObject;

            if (bulletDestroyStyle == BulletDestroyStyle.DirectDestroy)
            {
                Destroy(bullet);
            }

            if (bulletDestroyStyle == BulletDestroyStyle.LoopTeleport)
            {
                // 根据位置是否超界来判断往哪里移动
                float xTotal = boundary.size.x * boundary.transform.localScale.x;
                float zTotal = boundary.size.z * boundary.transform.localScale.z;
                float xMin = -xTotal / 2, xMax = xTotal / 2;
                float zMin = -zTotal / 2, zMax = zTotal / 2;
                // translate via x axis
                if (bullet.transform.position.x >= xMax)
                    bullet.transform.position -= new Vector3(xTotal, 0.0f, 0.0f);
                else if (bullet.transform.position.x <= xMin)
                    bullet.transform.position += new Vector3(xTotal, 0.0f, 0.0f);
                // translate via x axis
                if (bullet.transform.position.z >= zMax)
                    bullet.transform.position -= new Vector3(0.0f, 0.0f, zTotal);
                else if (bullet.transform.position.z <= zMin)
                    bullet.transform.position += new Vector3(0.0f, 0.0f, zTotal);
                
            }            
        } 
    }
}
