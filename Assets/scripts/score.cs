using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class score : MonoBehaviour {

	public Text mytext;


	void LateUpdate(){
		float text_width = (Screen.width / 2) - 10;
		float ratio = mytext.GetComponent<RectTransform> ().sizeDelta.y / mytext.GetComponent<RectTransform> ().sizeDelta.x;
		float text_height = text_width * ratio;
		mytext.GetComponent<RectTransform> ().sizeDelta = new Vector2 (text_width, text_height);
		mytext.GetComponent<FontData> ().bestFit = true;
	}
}
