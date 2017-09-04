using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShoot : SkillAbstract {

	public BulletMove bullet;
	public GameObject go;
	// TODO 可能需要维护 bullet 的实例数组

	public override void ReleaseSkill() {
		go = Instantiate (bullet.gameObject, transform.position, Quaternion.LookRotation(transform.forward));
		//go.GetComponent<BulletMove>().direction = transform.forward;
		Debug.Log (transform.forward);
	}




}
