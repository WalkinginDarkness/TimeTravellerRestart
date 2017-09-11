using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMove : MonoBehaviour {
	public float moveSpeed;
	public float rotateSpeed;
	public Vector3 direction;
    public DestroyCallbackAbstract destroyCallbackObject;
    public bool isBulletSpeedAcce = true;

    //设置从属关系，以便查询角色状态从而决定实际移动速度
    private string parentName;

	void Start () {
        Destroy(gameObject, 20);
	}

	void Update () {
        BulletMovement();
        BulletRotation();
    }

    public void SetParentName(string parentName) {
        this.parentName = parentName;
    }

    public string GetParentName() {
        return parentName;
    }

    private void BulletMovement() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * GetPlayerBulletSpeedProperty());
    }

    private void BulletRotation() {
        transform.RotateAround(transform.position, transform.forward, rotateSpeed * Time.deltaTime);
    }

    private float GetPlayerBulletSpeedProperty() {
        return isBulletSpeedAcce ? (PlayerStatusController.playerBulletSpeed.ContainsKey(parentName) ? PlayerStatusController.playerBulletSpeed[parentName] : 1.0f) : 1.0f;
    }

    private void OnDestroy() {
        if(destroyCallbackObject != null) {
            destroyCallbackObject.ExecuteOnCallerDestroy();
        }
    }
}
