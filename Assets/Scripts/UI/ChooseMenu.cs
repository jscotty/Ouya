using UnityEngine;
using System.Collections;

public class ChooseMenu : MonoBehaviour {


	public void Play(){
		LoadingScreen.isLoading = true;
		Application.LoadLevel (Levels.DRAW);
	}
	public void Back(){
		LoadingScreen.isLoading = true;
		Application.LoadLevel (Levels.GRID);
	}
	public void Create(){
		LoadingScreen.isLoading = true;
		Application.LoadLevel (Levels.BUILD_GRID);
	}
}
