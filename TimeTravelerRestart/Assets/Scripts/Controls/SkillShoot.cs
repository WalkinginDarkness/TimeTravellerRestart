using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShoot : SkillAbstract {

	public BulletMove bulletModel;
    // TODO 可能需要维护 bullet 的实例数组
    public GameObject lastBullet;

	public override void ReleaseSkill() {
        GenerateBullet();
	}

    /*
     * 由于目前使用GameController中的全局变量来控制子弹速度，射击速度和移动速度等，而存储的类型是Hash表
     * 因此按照PlayerID来取相应属性，所以给子弹设定parent可以方便的进行速度调整
     */
    private void GenerateBullet() {
        lastBullet = Instantiate(bulletModel.gameObject, transform.position, Quaternion.LookRotation(transform.forward));
        lastBullet.GetComponent<BulletMove>().SetParentName(this.GetComponent<SimpleMove>().playerID);
    }
}
