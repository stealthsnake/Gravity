using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player_scripts : MonoBehaviour {

	// Use this for initialization

	public Rigidbody2D player_rb;
	public int player_health;
	Vector2 position_start;
	Vector2 position_end;
	float jump_y_distance = 0;
	public GameObject player_object;

	protected Animator animator;
	protected Animation animation;
	static player_scripts instance;

	public int small_damage;
	public int mid_damage;
	public int big_damage;
	public int full_damage;


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

	void FixedUpdate(){
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
		caltulate_distance ();
		calculate_health ();

	}

	void OnCollisionExit2D(){
		position_start = player_rb.position;
		//animator.SetBool ("state", true);
	}
	void caltulate_distance(){
		/*if (player_rb.IsAwake ()) {
			jump_y_distance = Mathf.Abs (player_rb.position.y - position_start.y);
		} else {
			if (player_rb.IsSleeping ()) {
				jump_y_distance = Mathf.Abs (position_end.y - position_start.y);
			}
		}*/
		jump_y_distance = Mathf.Floor(Mathf.Abs (position_end.y - position_start.y));
	}

	void calculate_health(){

		if (jump_y_distance > small_damage &&  jump_y_distance < mid_damage) {
			player_health -=1;
		}
		if (jump_y_distance >= mid_damage &&  jump_y_distance < big_damage) {
			player_health -=2;
		}
		if (jump_y_distance >= big_damage &&  jump_y_distance < full_damage) {
			player_health -=3;
		}
		if (jump_y_distance >= full_damage) {
			player_health -=5;
		}
	}

	public float get_jump_distance(){
		return jump_y_distance;
	}

	public void check (){
		var x = player_rb.position.x;
		var y = player_rb.position.y;
		
		x = Mathf.Clamp (x, 
		                 camera_scripts.Instance.get_bonds_x ().x + 0.25f,
		                 camera_scripts.Instance.get_bonds_x().y + 0.25f);
		y = Mathf.Clamp(y,
		                camera_scripts.Instance.get_bonds_y().x + 0.25f,
		                camera_scripts.Instance.get_bonds_y().y + 0.25f);
		
		player_rb.position = new Vector2 (x, y);
	}
}
