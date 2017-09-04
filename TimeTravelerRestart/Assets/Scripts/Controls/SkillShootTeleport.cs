using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SkillShoot))]

public class SkillShootTeleport : SkillAbstract  {

	public override void ReleaseSkill(){
	
		SkillShoot ss = this.GetComponent<SkillShoot> ();
		if (ss.go == null) {

			Debug.Log ("go is null!");
			return;
		}
		Debug.Log (ss.go.transform.position);

		transform.position = ss.go.transform.position;
		Destroy (ss.go);

	}
}
