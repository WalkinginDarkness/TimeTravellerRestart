using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAbstract : MonoBehaviour {
	[Header("设定技能按键")]
	public KeyCode key;
	[Header("设定技能名称")]
	public string skillName;

	public float coldDown;
	protected float coldDownTimeLeft;

	void Start () {
        coldDownTimeLeft = 0.0f;
	}
	
	void Update () {
		if (Input.GetKeyDown (key)) {
			if (coldDownTimeLeft <= 0) {
				ReleaseSkill ();
                coldDownTimeLeft = coldDown;
			} else {
				Debug.Log ("Skill [" + skillName + "] is colding down! " + coldDownTimeLeft);
			}
		}
        coldDownTimeLeft -= Time.deltaTime * GetPlayerSkillSpeedProperty();
        AdditionalUpdate();
    }

    private float GetPlayerSkillSpeedProperty() {
        return PlayerStatusController.playerBulletSpeed.ContainsKey("1") ? (int)PlayerStatusController.playerMoveSpeed["1"] : 1.0f;
    }

    public virtual void ReleaseSkill() {
        Debug.LogWarning ("Abstract Skill not implemented!");
	}
    
    //用于方便子类利用Update()，若不使用可以不重写
    public virtual void AdditionalUpdate() {

    }
}
