using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
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
    public Vector3 addtionalMoveSpeed = new Vector3(0,0,0);

    const int timeRatio = 10;

    // 可以用另一个方法，获取Boundary物体的colldier尺寸
    // private BoxCollider boundary;
    public Boundary boundary;

    private void Start()
    {
        //这句话用于注册player，从而根据playerID初始化player属性，切不可删除
        PlayerStatusController.RegisterPlayerProperty(this, initialHealth, initialPower, initialPowerIncreaseSpeed / timeRatio);
        Debug.Log("玩家" + this.name + " 初始化完毕");

        //boundary = GameObject.FindWithTag("Boundary").GetComponent<BoxCollider>();
    }

    void Update () {
		Move ();
        AutoIncreasePower();
    }

    private void OnDestroy() {
        //Player销毁时根据playerID销毁销毁player的所有信息
        PlayerStatusController.RemovePlayer(playerID);
    }

    private void AutoIncreasePower() {
        PlayerStatusController.PlayerPowerConsume(playerID, initialPower);
        //Debug.Log(this.playerID + " " + PlayerStatusController.playerPower[playerID]);
        //Debug.Log(this.playerID + " " + PlayerStatusController.playerPowerConsumeSpeed[playerID]);
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
        //防止Player1和Player2碰撞导致y脱离0的情况
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        //额外强制移动
        transform.position += addtionalMoveSpeed * Time.deltaTime;

        
        GetComponent<Rigidbody>().position = new Vector3
        (
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            transform.position.y,
            Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
        );
    }

    public string GetPlayerID() {
        return playerID;
    }

    void Death()
    {
        Destroy(gameObject);
    }

    
}
