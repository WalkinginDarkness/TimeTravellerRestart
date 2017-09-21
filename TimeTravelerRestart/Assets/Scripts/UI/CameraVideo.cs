using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CameraVideo : MonoBehaviour {

    public VideoPlayer videoPlayer;
    public GameObject canvas;

    public float videoAlphaSpeed;
    public float targetAlphaValue = 0.5f;

    private bool bIsEnd = false;
	// Use this for initialization
	void Start () {
        canvas = GameObject.FindGameObjectWithTag("StartSceneUI");
        canvas.SetActive(false);
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
        //videoPlayer.Play();
        //videoPlayer.prepareCompleted+=Prepared;
	}

    private void Update(){
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
        bIsEnd = true;
    }
}
