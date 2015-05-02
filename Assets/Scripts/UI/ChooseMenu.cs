using UnityEngine;
using System.Collections;

public class ChooseMenu : MonoBehaviour {

	public void play(){
		Application.LoadLevel (3);
	}
	public void Back(){
		Application.LoadLevel (1);
	}
}
