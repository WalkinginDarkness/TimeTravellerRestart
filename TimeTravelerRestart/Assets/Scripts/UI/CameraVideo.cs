using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CameraVideo : MonoBehaviour {

    static bool bPlay = false;

    public VideoPlayer videoPlayer;
    public GameObject canvas;

    public float videoAlphaSpeed;
    public float targetAlphaValue = 0.5f;

    private bool bIsEnd = false;
	// Use this for initialization
	void Start () {
        canvas = GameObject.FindGameObjectWithTag("StartSceneUI");
        videoPlayer = GetComponent<VideoPlayer>();
        if (!bPlay)
        {
            canvas.SetActive(false);
            videoPlayer.enabled = true;
            videoPlayer.loopPointReached += EndReached;
            videoPlayer.Play();
        }
        else
        {
            canvas.SetActive(true);
            videoPlayer.enabled = false;
        }


	}

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // fake call EndReached
            bPlay = true;
            bIsEnd = true;
        }
        if (bIsEnd)
        {
            //Debug.Log(videoPlayer.targetCameraAlpha);
            if (videoPlayer.targetCameraAlpha > targetAlphaValue)
            {
                videoPlayer.targetCameraAlpha = videoPlayer.targetCameraAlpha-videoAlphaSpeed*Time.deltaTime;
            }
            else
            {
                if(canvas!=null)
                    canvas.SetActive(true);
                videoPlayer.enabled = false;
            }
        }
        
    }

    void Prepared(VideoPlayer videoPlayer){
        Debug.Log("Prepared");
    }

    void EndReached(VideoPlayer videoPlayer)
    {
        bPlay = true;
        bIsEnd = true;
    }
}
