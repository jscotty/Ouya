using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackPackUI : MonoBehaviour {

	public Text[] text;

	void Start(){
		Text ();
	}

	public void Text(){
		for (int i = 0; i < text.Length; i++) {
			text[i].text = "-------";
			if(i == 0){
				text[i].text = "Bed : \n" + BackPack.itemAmount[i] + " x";
			} else if(i == 1){
				text[i].text = "Stoel : \n" + BackPack.itemAmount[i] + " x";
			} else if(i == 2){
				text[i].text = "Kast : \n" + BackPack.itemAmount[i] + " x";
			} else if(i == 3){
				text[i].text = "Kaars : \n" + BackPack.itemAmount[i] + " x";
			}
		}
	}

}
