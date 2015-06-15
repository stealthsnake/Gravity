using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camera_scripts : MonoBehaviour {
	
	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {


		Camera.main.transform.position = player_scripts.Instance.player_object.transform.position;
	}
}
