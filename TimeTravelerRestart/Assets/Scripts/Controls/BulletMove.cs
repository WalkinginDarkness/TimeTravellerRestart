using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletMove : MonoBehaviour {
	public float moveSpeed;
	public float rotateSpeed;
	public Vector3 direction;
    public DestroyCallbackAbstract destroyCallbackObject;



	private ParticleSystem[] pss;
    private Light light;
    private bool isLastBullet = false;

    //设置从属关系，以便查询角色状态从而决定实际移动速度
    private string parentName;

	void Start () {
        Destroy(gameObject, 25);
		if (pss == null)
			pss = GetComponentsInChildren<ParticleSystem> ();
		if (pss == null || pss.Length == 0)
			Debug.LogWarning ("no ParticleSystem found in Rocket!");
        foreach (var ps in pss)
        {
            //if (ps.name.Equals("MarkerEffect"))
            //    marker = ps;
        }
        light = GetComponentInChildren<Light>();
    }

	void Update () {
        BulletMovement();
        BulletRotation();
		ParticleSystemSpeed ();
	}

    public void SetParentName(string parentName) {
        this.parentName = parentName;
    }

    public string GetParentName() {
        return parentName;
    }

    public void SetIsLastBullet(bool isLastBullet)
    {
        this.isLastBullet = isLastBullet;
        if (light != null)
        {
            var pos = light.transform.position;
            Debug.Log(light);
            if (isLastBullet)
            {
                light.transform.position = new Vector3(pos.x, 7, pos.z);
            } else
            {
                light.transform.position = new Vector3(pos.x, 2.8f, pos.z);
            }


        }
        //marker.gameObject.SetActive(isLastBullet);
    }

    public bool GetIsLastBullet()
    {
        return isLastBullet;
    }

    private void BulletMovement() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * GetPlayerBulletSpeedProperty());
    }

    private void BulletRotation() {
        transform.RotateAround(transform.position, transform.forward, rotateSpeed * Time.deltaTime);
    }

	private void ParticleSystemSpeed() {
		// change simulation speed
		foreach (var ps in pss) {
			var main = ps.main;
			float ratio = GetPlayerBulletSpeedProperty();
			main.simulationSpeed = ratio * 1.0f;
		}
		// get ratio
	}

    private float GetPlayerBulletSpeedProperty() {
        //if (parentName == null)
        //    return 1.0f;
        return PlayerStatusController.playerBulletSpeed.ContainsKey(parentName) ? PlayerStatusController.playerBulletSpeed[parentName] : 1.0f;
    }

    private void OnDestroy() {
        if(destroyCallbackObject != null) {
            destroyCallbackObject.ExecuteOnCallerDestroy();
        }
    }
}
