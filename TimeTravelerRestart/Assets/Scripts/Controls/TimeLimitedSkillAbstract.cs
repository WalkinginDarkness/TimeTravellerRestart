using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimitedSkillAbstract : SkillAbstract {

    public float skillDurationTime = 2.0f;
    protected float skillDurationTimeLeft = 1.0f;

    private bool isSkillFinish;

    void Start() {
        //避免设置的冷却时间比持续时间短可能出现的Bug
        if (skillDurationTime > coldDown) {
            skillDurationTime = coldDown - 0.1f;
        }
        isSkillFinish = false;
        skillDurationTimeLeft = 0.0f;
    }

    public override void AdditionalUpdate() {
        if (!isSkillFinish && skillDurationTimeLeft <= 0) {
            isSkillFinish = !isSkillFinish;
            AfterSkill();
        } else if(skillDurationTimeLeft > 0) {
            //应该加入技能持续时间延长属性（GameController），暂时未做
            skillDurationTimeLeft -= Time.deltaTime;
        }
    }

	public override void ReleaseSkill() {
		if (isSkillFinish == true) {
			skillDurationTimeLeft = skillDurationTime;
			isSkillFinish = !isSkillFinish;
			BeforeSkill();
		}
    }

    public virtual void BeforeSkill() {
        Debug.LogWarning("Abstract Skill not implemented!");
    }

    public virtual void AfterSkill() {
        Debug.LogWarning("Abstract Skill not implemented!");
    }
}