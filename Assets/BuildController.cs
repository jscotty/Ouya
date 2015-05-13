using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildController : MonoBehaviour {

	public Text text;

	void Start(){
		if(BackPack.choosItem == 0){
			text.text = "bed";
		} else if(BackPack.choosItem == 1){
			text.text = "stoel";
		} else if(BackPack.choosItem == 2){
			text.text = "kast";
		} else if(BackPack.choosItem == 3){
			text.text = "Kaars";
		}
	}

	void Update(){
		if(Input.GetButtonUp(InputButton.Y)){
			Application.LoadLevel(Levels.BACKPACK);
		} else if(Input.GetButtonUp(InputButton.A)){
			Application.LoadLevel(Levels.CHOOSE_MENU);
		}
	}
}
