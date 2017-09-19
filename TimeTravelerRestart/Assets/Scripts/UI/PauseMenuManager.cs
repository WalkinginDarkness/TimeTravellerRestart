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
    DestroyByBoundary destroyByBoundary;

    void Start() {
        if(pauseMenu == null) { 
            pauseMenu = GameObject.Find("PauseMenu");
        }
        pauseMenu.SetActive(false);

        destroyByBoundary = GameObject.FindGameObjectWithTag("Boundary").GetComponent<DestroyByBoundary>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
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
 
    public void ChangePlayStyle()
    {
        if (destroyByBoundary.bulletDestroyStyle == BulletDestroyStyle.DirectDestroy)
        {
            destroyByBoundary.bulletDestroyStyle = BulletDestroyStyle.LoopTeleport;
            //btnText.text = "切换至默认模式";
        }
        else if (destroyByBoundary.bulletDestroyStyle == BulletDestroyStyle.LoopTeleport)
        {
            destroyByBoundary.bulletDestroyStyle = BulletDestroyStyle.DirectDestroy;
            //btnText.text = "切换至无限模式";
        }
    }

    public void RestartLevel()
    {
        // Reload the level that is currently loaded.
        PlayerStatusController.RemoveAllPlayers();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
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
