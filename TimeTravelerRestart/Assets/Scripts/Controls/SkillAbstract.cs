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

    protected bool b_是否正在施放技能 = false;


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
            // 如果用GetKey方法，会在每帧调用BeforeSkill后立即调用AfterSkill
            // 对于加速技能而言，它的速度并没有实质上的修改
            // 故检测GetKey的返回和是否施放技能的状态的变化
            // 1. 如果状态是false且GetKey是true
            if (Input.GetKey(key) && !b_是否正在施放技能)
            {
                b_是否正在施放技能 = true;
                BeforeSkill();
            }
            // 2. 如果状态是true且GetKey是false
            if (!Input.GetKey(key) && b_是否正在施放技能)
            {
                b_是否正在施放技能 = false;
                AfterSkill();
            } else if (!IsPlayerPowerEnough())
            {
                // 3. 无论处于什么值，只要能量不足，就强制触发AfterSkill方法
                b_是否正在施放技能 = false;
                AfterSkill();
                Debug.Log(this.name + " don't have enough to Execute Skill [" + skillName + "]! ");
            }
            // 实际技能的施放
            if (b_是否正在施放技能) { 
                if (IsPlayerPowerEnough()) {
                    PlayerPowerConsume();
                    ReleaseSkill();
                } else
                {
                    Debug.LogError("Should never run to here!");
                }
            }
        }
    }

    private bool IsPlayerPowerEnough() {
        if(powerConsumeSpeed < 0.0000001 || PlayerStatusController.playerPower[gameObject.GetComponent<SimpleMove>().GetPlayerID()] > powerConsumeSpeed * Time.deltaTime) {
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
            PlayerStatusController.playerPower[gameObject.GetComponent<SimpleMove>().GetPlayerID()] -= powerConsumeSpeed * Time.deltaTime;
        }
    }

    public virtual void ReleaseSkill() {
        Debug.LogWarning ("Abstract Skill not implemented!");
	}

    public virtual void BeforeSkill()
    {
        //Debug.LogWarning("Abstract Skill not implemented!");
    }

    public virtual void AfterSkill()
    {
        //Debug.LogWarning("Abstract Skill not implemented!");
    }

    //用于方便子类利用Update()，若不使用可以不重写
    public virtual void AdditionalUpdate() {

    }
}
