using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeLimitedSkillAbstract : SkillAbstract {

    public float skillDurationTime = 2.0f;
    protected float skillDurationTimeLeft = -1.0f;

    private bool isSkillFinish;

    void Start() {
        if (skillType == SkillType.按键施放) {
            //避免设置的冷却时间比持续时间短可能出现的Bug
            if (skillDurationTime > coldDown) {
                skillDurationTime = coldDown - 0.1f;
            }
            skillDurationTimeLeft = 0.0f;
        }
        isSkillFinish = true;
    }

    public override void AdditionalUpdate() {
        if (skillType == SkillType.按键施放) {
            if (!isSkillFinish && skillDurationTimeLeft <= 0) {
                isSkillFinish = !isSkillFinish;
                AfterSkill();
            } else if(skillDurationTimeLeft > 0) {
                //应该加入技能持续时间延长属性（GameController），暂时未做
                skillDurationTimeLeft -= Time.deltaTime;
            }
        } else if (skillType == SkillType.持续施放)
        {

        }
    }

	public override void ReleaseSkill() {
        if (skillType == SkillType.按键施放)
        {
            if (isSkillFinish == true)
            {
                skillDurationTimeLeft = skillDurationTime;
                isSkillFinish = !isSkillFinish;
                BeforeSkill();
            }
        } 
    }
}