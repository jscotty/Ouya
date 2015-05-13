using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

	public static bool isLoading;
	public GameObject loadScreen;

	void Start(){
		isLoading = false;
		loadScreen.SetActive(false);
	}

	void Update(){
		if (isLoading) {
			loadScreen.SetActive(true);
		}
	}
}
