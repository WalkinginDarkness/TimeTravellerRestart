using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStatusUI : MonoBehaviour {

    public string[] PlayerPowerSlideName;
    public string[] PlayerHealthSlideName;

    public Slider Player1PowerSlider;
    public Slider Player2PowerSlider;

    // Use this for initialization
    void Start () {
        Slider[] components = this.gameObject.GetComponents<Slider>();
		foreach(Slider Component in components){
            if (Component.name == PlayerPowerSlideName[1])
            {
                Player1PowerSlider = Component;
            }
            else if (Component.name == PlayerPowerSlideName[1])
            {
                Player2PowerSlider = Component;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        Player1PowerSlider.value = PlayerStatusController.playerPower["1"];
        Player2PowerSlider.value = PlayerStatusController.playerPower["2"];
        //Debug.Log("PlayerStatusController.playerPower[1]  value" + Player1PowerSlider.value);
    }
}
