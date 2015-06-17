using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class game_actions_scripts : MonoBehaviour {
	//force used for jump
	int ForceMode = 1;
	int[] force_map = {0,1,2,3,4,3,2,1,2,3,4,3,2,1,2,3,4,3,2,1,2,3,4,3,2,1,2,3,4,3,2,1,2,3,4,3,2,1,2,3,4,3,2,1,2,3,4,3,2,1,2,3,4,3,2,1};
	int[] height_map = {0,3,4,4,5};
	//flag to tell which direction buttion was clicked
	string jump_direction;

	//used to calculate time between two clicks
	float startTime =0;
	bool game_stat = false;


	//used to calcualte countdownTime;
	System.TimeSpan time_sec;
	System.TimeSpan game_time = new System.TimeSpan (0, 1, 0);
	int game_time_left = 0, finishing_time=0;


	//lable to display forcemode
	public Text box_info;
	public Button left_button;
	public Button right_button;
	static game_actions_scripts instance;
	
	public static game_actions_scripts Instance{
		get{
			return instance;
		}
	}
	// Use this for initialization
	void Start () {
		instance = this;
		game_stat = true;
	}
	
	// Update is called once per frame
	void Update () {
		//box_info.text = player_scripts.Instance.player_health+ "Distance:" + player_scripts.Instance.caltulate_distance ();
		if (startTime != 0) {
			ForceMode = (int)Mathf.Round (Time.time - startTime)+1;
			update_force_bar(jump_direction, false);
		}
		if (player_scripts.Instance.player_health <= 0)
			Application.LoadLevel (0);

		 
		time_sec =  System.TimeSpan.FromSeconds (Time.timeSinceLevelLoad);


		if (!finishline.Instance.get_display_win ())
			game_time_left = (game_time.Subtract (time_sec)).Seconds;

		box_info.text = "Time Left:" + game_time_left;
	}

	public void get_user_input (string direction) {
			//Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began
		if(startTime == 0){
			startTime = Time.time;

			if(direction=="left")
				right_button.gameObject.SetActive(false);
			else
				left_button.gameObject.SetActive(false);
		}
		else{
			startTime =0;
			right_button.gameObject.SetActive(true);
			left_button.gameObject.SetActive(true);
			update_force_bar(jump_direction, true);
		}
		jump_direction = direction;
	}

	void update_force_bar(string direction, bool jump){
		if (jump && player_scripts.Instance.player_rb.IsSleeping()) {
			if(direction == "left"){
				player_scripts.Instance.player_rb.AddForce(new Vector2(-get_froce(),height_map[get_froce()]),ForceMode2D.Impulse);
				player_scripts.Instance.player_object.transform.eulerAngles = new Vector3 (0,180,0);
			}
			else{
				player_scripts.Instance.player_rb.AddForce(new Vector2(get_froce(),height_map[get_froce()]),ForceMode2D.Impulse);	
				player_scripts.Instance.player_object.transform.eulerAngles = new Vector3 (0,0,0);}
			ForceMode = 1;
		}
	}

	//function used to pass force value to other scripts like button;
	public int get_froce(){
		return(force_map[ForceMode]);
	}

	public int time_left(){
		return game_time_left;
	}	
}
