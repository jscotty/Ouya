using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

	public static bool isLoading;

	void Start(){
		isLoading = false;
		gameObject.SetActive(false);
	}

	void Update(){
		if (isLoading) {
			gameObject.SetActive(true);
		}
	}
}
