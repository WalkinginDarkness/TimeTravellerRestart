using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAbstract : MonoBehaviour {
	[Header("设定技能按键")]
	public KeyCode key;
	[Header("设定技能名称")]
	public string skillName;

	public float coldDown;
	private float timeColdDownLeft;

	void Start () {
		timeColdDownLeft = 0;
	}
	
	void Update () {
		if (Input.GetKeyDown (key)) {
			if (timeColdDownLeft <= 0) {
				ReleaseSkill ();
				timeColdDownLeft = coldDown;
			} else {
				Debug.Log ("Skill [" + skillName + "] is colding down! " + timeColdDownLeft);
			}
		}
		timeColdDownLeft -= Time.deltaTime;
	}

	public virtual void ReleaseSkill() {
		Debug.LogWarning ("Abstract Skill not implemented!");
	}

}
