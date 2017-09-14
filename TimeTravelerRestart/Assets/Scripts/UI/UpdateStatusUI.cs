using System.Collections;
using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 
 public class UpdateStatusUI : MonoBehaviour
 {
 
     public string[] PlayerPowerSlideName;
     public string[] PlayerHealthSlideName;
 
     public Slider Player1HealthSlider;
     public Slider Player2HealthSlider;
     public Slider Player1PowerSlider;
     public Slider Player2PowerSlider;
 
     // Use this for initialization
     void Start()
     {
         Slider[] components = gameObject.GetComponents<Slider>();
         // 如果是多个人，这样写岂不没用了吗？
         // 要与playerID联系起来
         foreach (Slider Component in components)
         {
             if (Component.name == PlayerHealthSlideName[1])
             {
                 Player1HealthSlider = Component;
             }
             else if (Component.name == PlayerHealthSlideName[1])
             {
                 Player2HealthSlider = Component;
             }
             else if (Component.name == PlayerPowerSlideName[1])
             {
                 Player1PowerSlider = Component;
             }
             else if(Component.name == PlayerPowerSlideName[1])
             {
                 Player2PowerSlider = Component;
             }
         }
     }
 
     // Update is called once per frame
     void Update()
     {
         Player1PowerSlider.value = PlayerStatusController.playerPower["1"];
         Player2PowerSlider.value = PlayerStatusController.playerPower["2"];
         //Debug.Log("PlayerStatusController.playerPower[1]  value" + Player1PowerSlider.value);
 
         Player1HealthSlider.value = PlayerStatusController.playerHealth["1"];
         Player2HealthSlider.value = PlayerStatusController.playerHealth["2"];
         //Debug.Log("PlayerStatusController.playerPower[1]  value" + Player1HealthSlider.value);
     }
}