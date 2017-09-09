using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

	public List<GameObject> elements;
	public GameObject mapRoot;
	public float tileSize;
	public int radiusRange;
    
	void Start () {
		for (int x = -radiusRange; x <= radiusRange; x++)
			for (int z = -radiusRange; z <= radiusRange; z++) {
				int k = Random.Range (0, elements.Count);
				Instantiate (elements[k], new Vector3 (x * tileSize, 0, z * tileSize), Quaternion.identity, mapRoot.transform); 
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
