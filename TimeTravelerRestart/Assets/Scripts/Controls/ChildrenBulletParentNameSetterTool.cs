using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenBulletParentNameSetterTool : DestroyCallbackAbstract {

    public GameObject toByDestroyObject;
    private int aliveBullet;
    

	public void SetParentName(string name) {
        BulletMove[] childrenBullets = GetComponentsInChildren<BulletMove>();
        for(int i = 0; i < childrenBullets.Length; i++) {
            childrenBullets[i].SetParentName(name);
        }
        aliveBullet = childrenBullets.Length;
    }

    public override void ExecuteOnCallerDestroy() {
        Debug.Log(aliveBullet);
        --aliveBullet;
        if(aliveBullet == 0) {
            Destroy(toByDestroyObject);
        }
    }
}
