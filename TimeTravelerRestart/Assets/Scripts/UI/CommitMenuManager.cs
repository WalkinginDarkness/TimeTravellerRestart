using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommitMenuManager : MonoBehaviour
{
    public GameObject commitCanvas;
    public GameObject player1WinFlag;
    public GameObject player2WinFlag;

    void Start()
    {
        commitCanvas.SetActive(false);
        player1WinFlag.SetActive(false);
        player2WinFlag.SetActive(false);
    }

    public void Player1Win()
    {
        player1WinFlag.SetActive(true);
        player2WinFlag.SetActive(false);
        commitCanvas.SetActive(true);
    }

    public void Player2Win()
    {
        player2WinFlag.SetActive(true);
        player1WinFlag.SetActive(false);
        commitCanvas.SetActive(true);
    }
}