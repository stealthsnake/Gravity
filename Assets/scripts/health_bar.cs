using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class health_bar : MonoBehaviour {

	public Image player_health_image;
	public Sprite one_life;
	public Sprite two_life;
	public Sprite three_life;
	public Sprite four_life;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		switch (player_scripts.Instance.player_health) {
		case 1:
			player_health_image.sprite = one_life;
			break;
		case 2:
			player_health_image.sprite = two_life;
			break;
		case 3:
			player_health_image.sprite = three_life;
			break;
		case 4:
			player_health_image.sprite = four_life;
			break;
		}
		
	}
}
