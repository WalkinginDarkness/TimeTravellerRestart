using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpeedUp : TimeLimitedSkillAbstract {
    [Header("设定倍率")]
    public float shootSpeed = 1.0f;
    public float moveSpeed = 1.0f;
    public float bulletSpeed = 1.0f;

    private float oldShootSpeed = 1.0f;
    private float oldMoveSpeed = 1.0f;
    private float oldBulletSpeed = 1.0f;

    public override void BeforeSkill() {
        oldShootSpeed = (int)PlayerStatusController.playerShootSpeed[this.GetComponent<SimpleMove>().playerID];
        oldMoveSpeed = (int)PlayerStatusController.playerMoveSpeed[this.GetComponent<SimpleMove>().playerID];
        oldBulletSpeed = (int)PlayerStatusController.playerBulletSpeed[this.GetComponent<SimpleMove>().playerID];
        PlayerStatusController.playerShootSpeed[this.GetComponent<SimpleMove>().playerID] = oldShootSpeed * shootSpeed;
        PlayerStatusController.playerMoveSpeed[this.GetComponent<SimpleMove>().playerID] = oldMoveSpeed * moveSpeed;
        PlayerStatusController.playerBulletSpeed[this.GetComponent<SimpleMove>().playerID] = oldBulletSpeed * bulletSpeed;
    }

    public override void AfterSkill() {
        PlayerStatusController.playerShootSpeed[this.GetComponent<SimpleMove>().playerID] = oldShootSpeed;
        PlayerStatusController.playerMoveSpeed[this.GetComponent<SimpleMove>().playerID] = oldMoveSpeed;
        PlayerStatusController.playerBulletSpeed[this.GetComponent<SimpleMove>().playerID] = oldBulletSpeed;
    }
}
