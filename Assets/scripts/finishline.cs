using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finishline : MonoBehaviour {

	public Image win_msg;
	public bool display_win;
	float lerp_time=1, currentLerpTime;

	static finishline instance;
	public static finishline Instance{
		get{
			return instance;
		}
	}



	// Use this for initialization
	void Start () {
		display_win = false;
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {

		if(display_win && player_scripts.Instance.player_health >=1){
			currentLerpTime += Time.deltaTime;
			if (currentLerpTime > lerp_time) {
				currentLerpTime = lerp_time;
			}
			float perc = currentLerpTime / lerp_time;
			perc = perc * perc;
			win_msg.rectTransform.eulerAngles = Vector3.Lerp(new Vector3(90,0,0), new Vector3 (0, 0, 0),perc);
			if(perc ==1)
			{
	
				//Application.LoadLevel(0);
				int score = player_scripts.Instance.player_health * game_actions_scripts.Instance.time_left();
				win_msg.GetComponentInChildren<Text>().text = "You Win \n Your Score is:" + score;

				Time.timeScale = 0;

				if(Input.anyKey)
				{
					Application.LoadLevel(0);
					Time.timeScale = 1;
				}
			}
		}
	}
	void OnCollisionEnter2D(){
			display_win = true;
			currentLerpTime = 0;
	}

	public bool get_display_win(){
		return display_win;
	}
}
