using UnityEngine;
using System.Collections;

public class ChooseMenu : MonoBehaviour {

	public void play(){
		Application.LoadLevel (4);
	}
	public void Back(){
		Application.LoadLevel (2);
	}
	public void Create(){

	}
}
