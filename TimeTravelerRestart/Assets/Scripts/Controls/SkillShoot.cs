using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShoot : SkillAbstract {

	public BulletMove bullet;

	public override void ReleaseSkill() {
		GameObject go = Instantiate (bullet.gameObject, transform.position, Quaternion.LookRotation(transform.forward));
		//go.GetComponent<BulletMove>().direction = transform.forward;
		Debug.Log (transform.forward);
	}
}
