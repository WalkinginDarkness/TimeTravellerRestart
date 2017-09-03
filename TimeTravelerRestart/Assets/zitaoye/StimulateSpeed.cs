using UnityEngine;
using System.Collections;

public class StimulateSpeed : MonoBehaviour
{
	private ParticleSystem ps;
	public float hSliderValue = 1.0F;

	void Start()
	{
		ps = GetComponent<ParticleSystem>();
	}

	void Update()
	{
		var main = ps.main;
		main.simulationSpeed = hSliderValue;
	}

	void OnGUI()
	{
		hSliderValue = GUI.HorizontalSlider(new Rect(25, 45, 100, 30), hSliderValue, 0.0F, 5.0F);
	}
}