using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishline : MonoBehaviour {

	public Image win_msg;
	bool display_win;
	float lerp_time=1, currentLerpTime;
	// Use this for initialization
	void Start () {
		display_win = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(display_win){
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerp_time) {
				currentLerpTime = lerp_time;
			}
			float perc = currentLerpTime / lerp_time;
			perc = perc * perc;
			win_msg.rectTransform.eulerAngles = Vector3.Lerp(new Vector3(90,0,0), new Vector3 (0, 0, 0),perc);

		}
	}
	void OnCollisionEnter2D(){
		display_win = true;
		currentLerpTime = 0;
	}
}
