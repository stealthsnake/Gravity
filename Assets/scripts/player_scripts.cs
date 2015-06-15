using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player_scripts : MonoBehaviour {

	// Use this for initialization

	public Rigidbody2D player_rb;
	public int player_health = 5;
	Vector2 position_start;
	Vector2 position_end;
	float jump_y_distance = 0;
	public GameObject player_object;

	protected Animator animator;
	protected Animation animation;
	static player_scripts instance;

	public int small_damage = 5;
	public int mid_damage = 8;
	public int big_damage = 11;
	public int full_damage = 15;


	public static player_scripts Instance{
		get{
			return instance;
		}
	}
	
	void Start () {
		instance = this;
		animator = GetComponent<Animator>();
		animation = GetComponent<Animation>();

		position_start = position_end = player_rb.position;


	}
	
	// Update is called once per frame
	void LateUpdate () {
	}

	public Vector2 get_player_start_position()
	{
		return position_start;
	}

	public Vector2 get_player_end_position()
	{
		return position_end;
	}

	void OnCollisionEnter2D(){
		position_end = player_rb.position;
		//animator.SetBool ("state", false);


	}

	void OnCollisionExit2D(){
		position_start = player_rb.position;
		//animator.SetBool ("state", true);
	}
	public int caltulate_distance(){
		if (player_rb.IsAwake ()) {
			jump_y_distance = Mathf.Abs (player_rb.position.y - position_start.y);
		} else {
			if (player_rb.IsSleeping ()) {
				jump_y_distance = Mathf.Abs (position_end.y - position_start.y);
			}
		}
		jump_y_distance = Mathf.Abs (position_end.y - position_start.y);
		calculate_health ();
		return (int)Mathf.Round (jump_y_distance);
	}

	void calculate_health(){
		if (jump_y_distance > small_damage &&  jump_y_distance < mid_damage) {
			player_health -=1;
		}
		if (jump_y_distance > mid_damage &&  jump_y_distance < big_damage) {
			player_health -=2;
		}
		if (jump_y_distance > big_damage &&  jump_y_distance < full_damage) {
			player_health -=3;
		}
		if (jump_y_distance > full_damage) {
			player_health -=5;
		}
	}
}
