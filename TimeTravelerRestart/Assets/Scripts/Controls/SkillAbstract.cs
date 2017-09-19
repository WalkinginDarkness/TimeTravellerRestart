using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    按键施放, 持续施放
}

public class SkillAbstract : MonoBehaviour {
	[Header("设定技能按键")]
	public KeyCode key;
	[Header("设定技能名称")]
	public string skillName;
    [Header("设定技能类型")]
    public SkillType skillType = SkillType.按键施放;


    public float coldDown;
	protected float coldDownTimeLeft;

    public float powerConsumeSpeed = 0f;
    protected float oldPowerConsumeSpeed = 0f;


    void Start () {
        coldDownTimeLeft = 0.0f;
        powerConsumeSpeed = 0.0f;
	}

    void Update()
    {
        if (skillType == SkillType.按键施放)
        {
            if (Input.GetKeyDown(key))
            {
                if (coldDownTimeLeft <= 0)
                {
                    ReleaseSkill();
                    coldDownTimeLeft = coldDown;
                }
                else
                {
                    Debug.Log("Skill [" + skillName + "] is colding down! " + coldDownTimeLeft);
                }
            }
            coldDownTimeLeft -= Time.deltaTime * GetPlayerSkillSpeedProperty();
            AdditionalUpdate();
        }
        else if (skillType == SkillType.持续施放)
        {
            if (Input.GetKeyDown(key))
            {
                BeforeSkill();
                ReleaseSkill();
                AfterSkill();
            }
            if (Input.GetKeyUp(key))
            {
                BeforeSkill();
                ReleaseSkill();
                AfterSkill();
            }
        }
    }

    private float GetPlayerSkillSpeedProperty() {
        return PlayerStatusController.playerBulletSpeed.ContainsKey("1") ? (int)PlayerStatusController.playerMoveSpeed["1"] : 1.0f;
    }

    public virtual void ReleaseSkill() {
        Debug.LogWarning ("Abstract Skill not implemented!");
	}

    public virtual void BeforeSkill()
    {
        Debug.LogWarning("Abstract Skill not implemented!");
    }

    public virtual void AfterSkill()
    {
        Debug.LogWarning("Abstract Skill not implemented!");
    }

    //用于方便子类利用Update()，若不使用可以不重写
    public virtual void AdditionalUpdate() {

    }
}
