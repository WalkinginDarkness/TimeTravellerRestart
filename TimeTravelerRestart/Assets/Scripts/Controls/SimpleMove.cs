using UnityEngine;

//TODO：目前玩家信息和Move脚本放在一起，以后修改
public class SimpleMove : MonoBehaviour {

    //按照之前的，玩家信息包括能量先放这里，之后要拿出来
	[Tooltip("玩家ID")]
	public string playerID = "1";
    public int initialHealth = 100; // 注意健康值要与滑条里的MaxValue一致
    public float initialPower = 100.0f;
    public float initialPowerIncreaseSpeed = 1.0f;

	public float moveSpeed = 45.0f;
	public float rotateSpeed = 6.0f;

    private void Start()
    {
        PlayerStatusController.playerPower[playerID] = initialPower;
        PlayerStatusController.playerPowerConsumeSpeed[playerID] = initialPowerIncreaseSpeed;

        PlayerStatusController.playerHealth[playerID] = initialHealth;
    }

    void Update () {
		Move ();
        //Debug.Log(playerID);
	}

    public string GetPlayerID()
    {
        return playerID; 
    }

    void Move()
    {
		float inputX = Input.GetAxisRaw ("Horizontal" + playerID);	// 临时的x方向值
		float inputZ = Input.GetAxisRaw ("Vertical" + playerID);	// 临时的z方向值
		
		// 如果输入的位置接近于0，那么不进行转向（否则LookRotation会抛警告）
		if (inputX * inputX + inputZ * inputZ > 0.0025f) {
            Quaternion fromQuaternion = transform.rotation;
            Quaternion toQuaternion = Quaternion.LookRotation (new Vector3 (inputX, 0, inputZ));
			transform.rotation = Quaternion.Lerp (fromQuaternion, toQuaternion, Time.deltaTime * rotateSpeed);

			// 当当前方向和目标方向夹角过大时，只转向，不进行移动
            // 180是不是每次都需要跳进来？
			if (Quaternion.Angle (fromQuaternion, toQuaternion) < 180) {
                // 为什么要用InverseTransformVector，因为转完之后Translate移动的方向也变了
                // 所以需要从局部的坐标映射回全局的坐标
                transform.Translate(transform.InverseTransformVector(Time.deltaTime * moveSpeed * new Vector3(inputX, 0, inputZ) * (int)(PlayerStatusController.playerShootSpeed.ContainsKey(playerID) ? PlayerStatusController.playerMoveSpeed[playerID] : 1)));
			}
        }	
	}

    void Death()
    {
        Destroy(gameObject);
    }
}
