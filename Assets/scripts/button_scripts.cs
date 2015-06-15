using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button_scripts : MonoBehaviour {


	// Use this for initialization
	public Button button_action;
	public Sprite level_1;
	public Sprite level_2;
	public Sprite level_3;
	public Sprite level_4;

	static button_scripts instance;
	public static button_scripts Instance{
		get{
			return instance;
		}
	}

	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		int image = game_actions_scripts.Instance.get_froce ();
		switch (image) {
		case 1:
			button_action.image.sprite = level_1;
			break;
		case 2:
			button_action.image.sprite = level_2;
			break;
		case 3:
			button_action.image.sprite = level_3;
			break;
		case 4:
			button_action.image.sprite = level_4;
			break;
		}
	}
}
