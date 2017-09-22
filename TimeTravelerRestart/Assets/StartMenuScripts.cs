using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuScripts : MonoBehaviour {
    public GameObject MainMenu;
    public GameObject SelectSceneMenu;
    public GameObject CreditsMenu;
    public GameObject MainCamera;
    public GameObject Background;

    private int cnt;
    private int scene;
    private void Start()
    {
        InitMenus();
        cnt = 0;
        scene = 0;
    }
    private void Update()
    {
        cnt++;
        if (cnt > 200) {
            if (scene != 0) {
                SceneManager.LoadScene(scene);
            }
        }
    }
    /*
     * 若自动寻找，初始应设置两个Menu为Active并且名字相同
     */
    private void InitMenus() {
        if (MainMenu == null) {
            MainMenu = GameObject.Find("MainMenu");
        }
        if (SelectSceneMenu == null) {
            SelectSceneMenu = GameObject.Find("SelectSceneMenu");
        }
        if (CreditsMenu == null) {
            SelectSceneMenu = GameObject.Find("CreditsMenu");
        }
        if (MainCamera == null) {
            MainCamera = GameObject.Find("MainCamera");
        }
        MainMenu.SetActive(true);
        SelectSceneMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void StartButtonTrigger() {
        MainMenu.SetActive(false);
        SelectSceneMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void CreditsButtonTrigger() {
        MainMenu.SetActive(false);
        SelectSceneMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void BackMainMenu() {
        MainMenu.SetActive(true);
        SelectSceneMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void ExitButtonTrigger() {
        Application.Quit();
    }
    
    public void StartMode1() {
        StartGame(1);
    }

    public void StartMode2() {
        StartGame(2);
    }

    public void StartMode3() {
        StartGame(3);
    }
    public void StartGame(int scene) {
        MainCamera.GetComponent<SplashScreen>().enabled = true;
        MainCamera.GetComponent<SplashScreen>().SetModeID(scene);
        Background.SetActive(false);
        MainMenu.SetActive(false);
        SelectSceneMenu.SetActive(false);
        CreditsMenu.SetActive(false);
        cnt = 0;
        this.scene = scene;
    }

}
