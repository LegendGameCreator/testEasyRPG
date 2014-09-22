using UnityEngine;
using System.Collections;

public class moveTest : MonoBehaviour {

	public GameObject prefab;

	private GameObject inst_prefab;

	// Use this for initialization
	void Start () {
		if( prefab != null )
			inst_prefab = GameObject.Instantiate(prefab) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if( inst_prefab != null ){
			inst_prefab.transform.position = new Vector3(0, 5, 0);
		}
	}
}
