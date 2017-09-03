using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public List<GameObject> elements;
	public GameObject mapRoot;
	public int radiusRange;

	// Use this for initialization
	void Start () {
		int r = radiusRange;
		for (int x = -r; x <= r; x++)
			for (int z = -r; z <= r; z++) {
				int k = Random.Range (0, elements.Count);
				Instantiate (elements [k], new Vector3 (x, 0, z), Quaternion.identity, mapRoot.transform); 
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
