using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour {

    static int randPlayerCnt = 0;
    private static HashSet<string> players = new HashSet<string>();
    private static List<Dictionary<string, float>> properties = new List<Dictionary<string, float>>();

    // 角色移动速度
    // 子弹速度
    // 射击速度
    // 能量消耗速率
    // 角色能量
    // 角色血量
    public static Dictionary<string, float> playerMoveSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerBulletSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerShootSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerPowerConsumeSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerPower = new Dictionary<string, float>();
    
    public static Dictionary<string, float> playerHealth = new Dictionary<string, float>();

    //需要新属性时添加新的Dict并在静态代码块中Add即可
    static PlayerStatusController() {
        properties.Add(playerMoveSpeed);
        properties.Add(playerBulletSpeed);
        properties.Add(playerShootSpeed);
        properties.Add(playerPowerConsumeSpeed);
        properties.Add(playerPower);
    }

    //用于注册玩家，并初始化玩家能力信息
    public static void RegisterPlayerProperty(SimpleMove player) {
        string playerID = player.playerID;
        if(playerID != null && playerID != "" && !players.Contains(playerID)) {
            players.Add(playerID);
        } else {
            player.playerID = GenerateRandomPlayerName();
            playerID = player.playerID;
            players.Add(playerID);
        }
        foreach (Dictionary<string, float> property in properties) {
            property.Add(playerID, 1);
        }
    }

    public static void RegisterPlayerProperty(SimpleMove player, float initialHealth, float initialPower, float initialPowerIncreaseSpeed) {
        string playerID = player.GetPlayerID();
        RegisterPlayerProperty(player);
        playerPower[playerID] = initialPower;
        playerPowerConsumeSpeed[playerID] = initialPowerIncreaseSpeed;
        playerHealth[playerID] = initialHealth;
    }

    //玩家销毁时清除玩家信息
    public static void RemovePlayer(string playerId) {
        foreach (Dictionary<string, float> property in properties) {
            property.Remove(playerId);
        }
    }

    public static void RemoveAllPlayers() {
        foreach (string player in players) {
            foreach (Dictionary<string, float> property in properties) {
                property.Remove(player);
            }
        }
        players.Clear();
    }

    //生成随机玩家名，使用时间戳，因此不会重复
    private static string GenerateRandomPlayerName() {
        System.Random random = new System.Random();
        int randValue = random.Next(1, 1000);


        return "Player-Rand" + (randPlayerCnt++) + "-" + randValue + "-" + DateTime.Now.Ticks.ToString();
    }
}
