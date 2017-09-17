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
                // transform.forward前进方向是1.0or-1.0，但其他也会有一点0.1之类的
                // 所以就判断0.9了
                if (bullet.transform.forward.x < 0.9)
                {
                    bullet.transform.position += new Vector3(boundary.size.x, 0.0f, 0.0f);
                }

                if (bullet.transform.forward.x > -0.9)
                {
                    bullet.transform.position -= new Vector3(boundary.size.x, 0.0f, 0.0f);
                }

                if (bullet.transform.forward.z < 0.9)
                {
                    bullet.transform.position += new Vector3(0.0f, 0.0f, boundary.size.z);
                }

                if (bullet.transform.forward.z > -0.9)
                {
                    bullet.transform.position -= new Vector3(0.0f, 0.0f, boundary.size.z);
                }
            }            
        } 
    }
}
