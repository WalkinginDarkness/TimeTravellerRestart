using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenBulletParentNameSetterTool : DestroyCallbackAbstract {

    private int aliveBullet;
    

	public void SetParentName(string name) {
        BulletMove[] childrenBullets = GetComponentsInChildren<BulletMove>();
        aliveBullet = childrenBullets.Length;
        for (int i = 0; i < childrenBullets.Length; i++) {
            Debug.Log("----------" + i + "-------");
            childrenBullets[i].SetParentName(name);
            Debug.Log("----------" + i + "-------" + childrenBullets[i].GetParentName());
        }
    }

    public override void ExecuteOnCallerDestroy() {
        Debug.Log(aliveBullet + "!!!!!!");
        --aliveBullet;
        if(aliveBullet == 0) {
            Destroy(gameObject);
        }
    }
}
