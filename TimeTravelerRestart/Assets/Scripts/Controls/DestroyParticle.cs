using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour {

    public float duration;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, duration); //两秒后删除粒子系统
    }
}
