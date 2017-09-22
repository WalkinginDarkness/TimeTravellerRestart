using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenuManager : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject guideCanvas;
    public GameObject statusCanvas;

    private Text btnModeText;
    private bool isBlockPauseMenu;
    DestroyByBoundary destroyByBoundary;

    void Start() {
        isBlockPauseMenu = false;
        if (menuCanvas == null) { 
            menuCanvas = GameObject.Find("MenuCanvas");
           
        }
        if(guideCanvas == null) {
            guideCanvas = GameObject.Find("GuideCanvas");
        }
        if (statusCanvas == null)
        {
            statusCanvas = GameObject.Find("StatusCanvas");
        }
        menuCanvas.SetActive(false);
        guideCanvas.SetActive(false);
        statusCanvas.SetActive(true);
        // 寻找Mode的UI视图（现在是文字，之后也可以改成图片等）
        if (btnModeText == null)
        {
            var go = menuCanvas.transform.Find("Options/Text");
            if (go != null)
            {
                btnModeText = go.GetComponent<Text>();
            } else
            {
                Debug.LogError("PauseMenu/Options/Text not found!");
            }
        }

        destroyByBoundary = GameObject.FindGameObjectWithTag("Boundary").GetComponent<DestroyByBoundary>();
        UpdateModeUI();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && !isBlockPauseMenu) {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    internal void BlockPauseMenu()
    {
        isBlockPauseMenu = true;
    }

    private void PauseGame() {
        Debug.LogError(guideCanvas);
        if(menuCanvas.activeSelf) {
            Time.timeScale = 1;
            guideCanvas.SetActive(false);
            menuCanvas.SetActive(false);
        } else {
            Time.timeScale = 0;
            menuCanvas.SetActive(true);
            guideCanvas.SetActive(true);
        }
    }
 
    public void ReturnToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void ChangePlayStyle()
    {
        if (destroyByBoundary.bulletDestroyStyle == BulletDestroyStyle.DirectDestroy)
        {
            destroyByBoundary.bulletDestroyStyle = BulletDestroyStyle.LoopTeleport;
        }
        else if (destroyByBoundary.bulletDestroyStyle == BulletDestroyStyle.LoopTeleport)
        {
            destroyByBoundary.bulletDestroyStyle = BulletDestroyStyle.DirectDestroy;
        }
        UpdateModeUI();
    }

    // 视图的更新，现在是用文字，如果之后改成图片，只需要修改这个方法即可
    private void UpdateModeUI()
    {
        if (destroyByBoundary.bulletDestroyStyle == BulletDestroyStyle.DirectDestroy)
        {
            btnModeText.text = "LOOP: FALSE";
        } else if (destroyByBoundary.bulletDestroyStyle == BulletDestroyStyle.LoopTeleport)
        {
            btnModeText.text = "LOOP: TRUE";
        }

    }

    public void RestartLevel()
    {
        // Reload the level that is currently loaded.
        // PlayerStatusController.RemoveAllPlayers();
        
        Time.timeScale = 1;
        Debug.LogWarning("Restarting Level!");
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
