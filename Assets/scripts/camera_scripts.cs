using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class camera_scripts : MonoBehaviour {
		
	public BoxCollider2D bonds;

	private Vector2 _min, _max, game_bonds_x, game_bonds_y;


	static camera_scripts instance;

	public static camera_scripts Instance{
		get{
			return instance;
		}
	}



	// Use this for initialization
	void Start () {	
		instance = this;
		_min = bonds.bounds.min;
		_max = bonds.bounds.max;
	}
	
	// Update is called once per frame
	void Update () {
		var x = transform.position.x;
		var y = transform.position.y;

		x = player_scripts.Instance.transform.position.x;
		y = player_scripts.Instance.transform.position.y;


		var screen_half_with = Camera.main.orthographicSize * ((float)Screen.width / Screen.height);

		game_bonds_x.x = _min.x ;
		game_bonds_x.y = _max.x;

		game_bonds_y.x = _min.y;
		game_bonds_y.y = _max.y + Camera.main.orthographicSize;

		x = Mathf.Clamp (x, 
		                 game_bonds_x.x + screen_half_with ,
		                 game_bonds_x.y - screen_half_with );
		y = Mathf.Clamp (y, 
		                 game_bonds_y.x + Camera.main.orthographicSize , 
		                 game_bonds_y.y + Camera.main.orthographicSize );
		transform.position = new Vector3 (x, y, transform.position.z);
	}

	public Vector2 get_bonds_x(){
		return game_bonds_x;
	}

	public Vector2 get_bonds_y(){
		return game_bonds_y;
	}
}