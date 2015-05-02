using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public GameObject[] menuObjects;

	private enum Menu {Start,Options};

	public void StartButton(){
		LoadingScreen.isLoading = true;
		Application.LoadLevel (1);
	}

	public void OptionsButton(){
		ButtonHandler (Menu.Options);
	}

	public void BackButton(){
		ButtonHandler (Menu.Start);
	}

	private void ButtonHandler(Menu menu){
		if (menu == Menu.Start) {
			menuObjects[0].SetActive(true);
			menuObjects[1].SetActive(false);
		} else if(menu == Menu.Options){
			menuObjects[0].SetActive(false);
			menuObjects[1].SetActive(true);
		}
	}
}
