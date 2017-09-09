using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenuManager : MonoBehaviour {

    public GameObject pauseMenu;

    void Start() {
        if(pauseMenu == null) { 
            pauseMenu = GameObject.Find("PauseMenu");
        }
        pauseMenu.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
        PauseMenuAction();
    }

    private void PauseGame() {
        if(pauseMenu.activeSelf) {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        } else {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
    /*
     * 之后做成真的菜单，目前随便写写
     * 目前功能只有重置关卡，之后计划加入更改键位和游戏环境设置
     * 重置关卡后环境变色是Unity自身的问题，build后实际游戏并不会出现这样的情况
     */
    private void PauseMenuAction() {
        //重置关卡要先抛出PlayerStatusController的所有数据，然后恢复timeScale后才能加载场景
        if (pauseMenu.activeSelf && Input.GetKeyDown(KeyCode.P)) {
            PlayerStatusController.RemoveAllPlayers();
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
