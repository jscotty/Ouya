using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public void StartButton(){
		LoadingScreen.isLoading = true;
		Application.LoadLevel (1);
	}
}
