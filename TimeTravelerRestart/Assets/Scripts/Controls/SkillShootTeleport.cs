using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SkillShoot))]

public class SkillShootTeleport : SkillAbstract  {

    public ParticleSystem teleportPrefab;
    private GameObject exchangeBullet;

    public override void ReleaseSkill(){
        exchangeBullet = this.GetComponent<SkillShoot>().lastBullet;
        //当无子弹时，重置冷却时间为0
        if (exchangeBullet == null) {
            PlayerStatusController.playerPower[gameObject.GetComponent<SimpleMove>().GetPlayerID()] += powerConsumeSpeed;
            Debug.Log("no bullet can exchange position, skill [" + skillName + "] can't trigger!");
            coldDownTimeLeft = 0.0f;
            return;
        }
        //转移比较突兀，加入动画效果
        Vector3 pos2 = new Vector3(0, 0, 0);
        var boom = Instantiate(teleportPrefab, transform.position, Quaternion.LookRotation(Vector3.up));
        boom.Play();
        Destroy(boom, 2);
        
        //使触发此技能的玩家的position与rotation与子弹的相同
        var pos = exchangeBullet.transform.position;
		transform.position = new Vector3(pos.x, transform.position.y, pos.z);
        Vector3 eulerAngles = exchangeBullet.transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerAngles.x, eulerAngles.y, 0);

        Destroy (exchangeBullet);
	}
}
