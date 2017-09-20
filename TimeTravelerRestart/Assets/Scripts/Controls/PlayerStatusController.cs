using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour {

    static int randPlayerCnt = 0;
    private static HashSet<string> players = new HashSet<string>();
    private static List<Dictionary<string, float>> properties = new List<Dictionary<string, float>>();

    /*
     * playerMoveSpeed          角色移动速度
     * playerBulletSpeed        子弹速度
     * playerShootSpeed         射击速度
     * playerPowerConsumeSpeed  能量消耗速率
     * playerPower              角色能量
     * playerHealth             角色血量
     */
    public static Dictionary<string, float> playerMoveSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerBulletSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerShootSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerPowerConsumeSpeed = new Dictionary<string, float>();
    public static Dictionary<string, float> playerPower = new Dictionary<string, float>();
    public static Dictionary<string, float> playerHealth = new Dictionary<string, float>();

    /*
     * 配置需要初始化的属性【默认均为1】
     * Note：需要新属性时添加新的Dict并在静态代码块中Add即可
     * 【为了减少重复代码量】
     */
    static PlayerStatusController() {
        properties.Add(playerMoveSpeed);
        properties.Add(playerBulletSpeed);
        properties.Add(playerShootSpeed);
        properties.Add(playerPowerConsumeSpeed);
        properties.Add(playerHealth);
        properties.Add(playerPower);
    }

    /* 
     * 用于注册玩家，并初始化玩家能力信息
     * Note:这个函数负责的是比例属性，主要负责子弹移动速度，玩家移速，子弹发射速度
     * 修改这三个属性时，实际属性是比例增加的，如playerBulletSpeed设为2，实际上玩家的子弹移动速度会变为初始速度的两倍
     * 【此处不负责设置初始速度的，注册时默认所有属性为1，即为一倍速】
     */
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

    /* 
     * 用于注册玩家，并初始化玩家能力信息
     * Note:这个函数使用了RegisterPlayerProperty(SimpleMove player)，可以初始化比例属性
     * 还负责值类型的信息，如HP，MP，MP增长速度
     * 【playerPowerConsumeSpeed初始化时已经取反，因此在SimpleMove填入正数即可】
     * 【可以放在player的SimpleMove中】
     */
    public static void RegisterPlayerProperty(SimpleMove player, float initialHealth, float initialPower, float initialPowerIncreaseSpeed) {
        string playerID = player.GetPlayerID();
        RegisterPlayerProperty(player);
        playerPower[playerID] = initialPower;
        playerPowerConsumeSpeed[playerID] = -initialPowerIncreaseSpeed;
        playerHealth[playerID] = initialHealth;
    }

    /*
     * 用于玩家的能量缩减
     * 传入正数则为消耗能量，负数为增加能量，因此player初始能量传入为负数
     */
    public static void PlayerPowerConsume(string playerID, float maxPower) {
        if (playerPower[playerID] < maxPower) {
            playerPower[playerID] -= playerPowerConsumeSpeed[playerID] * Time.deltaTime;
        }
    }

    public static void PlayerPowerConsume(string playerID) {
        PlayerPowerConsume(playerID, 100);
    }

    //玩家销毁时清除玩家信息
    public static void RemovePlayer(string playerId) {
        foreach (Dictionary<string, float> property in properties) {
            property.Remove(playerId);
        }
        players.Remove(playerId);
    }

    //清除所有玩家信息
    public static void RemoveAllPlayers() {
        foreach (string playerId in players) {
            RemovePlayer(playerId);
        }
        players.Clear();
    }

    /*
     * 生成随机玩家名，使用时间戳，因此不会重复
     * 【解决当需要玩家给player设置ID进行游戏时，可能会导致的ID冲突，从而无法找到需要的属性并出现异常】
     * 【游戏开始前配置好玩家ID可以不使用】
     */
    private static string GenerateRandomPlayerName() {
        System.Random random = new System.Random();
        int randValue = random.Next(1, 1000);
        return "Player-Rand" + (randPlayerCnt++) + "-" + randValue + "-" + DateTime.Now.Ticks.ToString();
    }
}
