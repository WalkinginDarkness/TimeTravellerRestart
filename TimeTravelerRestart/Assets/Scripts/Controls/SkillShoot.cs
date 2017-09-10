using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShoot : SkillAbstract {

	public BulletMove bulletModel;
	[HideInInspector]
	public GameObject lastBullet;
	[Tooltip("子弹射出的位置")]
	public Transform bulletSpawnPoint;

	void Start() {
		if (bulletSpawnPoint == null) {
			Debug.LogWarning (gameObject.name + "的子弹位置未指定，右击SkillShot组件，选择Update Bullet Spawn Point");
			UpdateBullectSpawnPoint ();
		}
	}

	public override void ReleaseSkill() {
        GenerateBullet();
	}

    /*
     * 由于目前使用GameController中的全局变量来控制子弹速度，射击速度和移动速度等，而存储的类型是Hash表
     * 因此按照PlayerID来取相应属性，所以给子弹设定parent可以方便的进行速度调整
     */
    private void GenerateBullet() {
		lastBullet = Instantiate(bulletModel.gameObject, bulletSpawnPoint.position, Quaternion.LookRotation(transform.forward));
        lastBullet.GetComponent<BulletMove>().SetParentName(this.GetComponent<SimpleMove>().playerID);
    }

	[ContextMenu ("Update Bullet Spawn Point")]
	void UpdateBullectSpawnPoint ()
	{
		foreach (var child in gameObject.GetComponentsInChildren<Transform>()) {
			if (child.name == "BulletSpawnPoint") {
				bulletSpawnPoint = child;
			}
		}
		if (bulletSpawnPoint == null) {
			Debug.LogError ("无法设置子弹生成位置！(在Player下创建BulletSpawnPoint子对象，并设定其位置即可)");
		}
	}
}
