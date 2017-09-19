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
        //powerConsumeSpeed = 0.0f;
	}

    void FixedUpdate() {
        if (skillType == SkillType.按键施放) {
            if (Input.GetKeyDown(key)) {
                if (coldDownTimeLeft <= 0) {
                    /*
                     * 目前释放技能失败会将蓝量加回
                     * NOTE：也可以更改Release为一个待bool返回值的函数
                     * 从而可以判断是否技能真正的释放，从而正确扣减蓝量
                     */ 
                    if(IsPlayerPowerEnough()) {
                        PlayerPowerConsume();
                        ReleaseSkill();
                        coldDownTimeLeft = coldDown;
                    } else {
                        Debug.Log(this.name + " don't have enough to Execute Skill [" + skillName + "]! ");
                    }
                }
                else {
                    Debug.Log("Skill [" + skillName + "] is colding down! " + coldDownTimeLeft);
                }
            }
            coldDownTimeLeft -= Time.deltaTime * GetPlayerSkillSpeedProperty();
            AdditionalUpdate();
        } else if (skillType == SkillType.持续施放) {
            if (Input.GetKey(key)) {
                /*
                 * 直接释放即可
                 */
                if (IsPlayerPowerEnough()) {
                    PlayerPowerConsume();
                    BeforeSkill();
                    ReleaseSkill();
                    AfterSkill();
                } else {
                    Debug.Log(this.name + " don't have enough to Execute Skill [" + skillName + "]! ");
                }
            }
        }
    }

    private bool IsPlayerPowerEnough() {
        if(powerConsumeSpeed < 0.0000001 || PlayerStatusController.playerPower[gameObject.GetComponent<SimpleMove>().GetPlayerID()] > powerConsumeSpeed) {
            return true;
        }
        return false;
    }
    //冷却缩减，暂未实现
    private float GetPlayerSkillSpeedProperty() {
        return PlayerStatusController.playerBulletSpeed.ContainsKey("1") ? (int)PlayerStatusController.playerMoveSpeed["1"] : 1.0f;
    }

    /*
     * 能量消耗
     * 假设一定存在PlayerStatusController，并且每个Player都有SimpleMove
     */
    protected void PlayerPowerConsume() {
       if (gameObject.tag == "Player1" || gameObject.tag == "Player2") {
            PlayerStatusController.playerPower[gameObject.GetComponent<SimpleMove>().GetPlayerID()] -= powerConsumeSpeed;
        }
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
