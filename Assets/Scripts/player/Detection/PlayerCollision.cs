using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private bool _jump;

	void OnTriggerEnter(Collider other){
		if(other.tag == Tags.HOME){
			LoadingScreen.isLoading = true;
			Application.LoadLevel(Levels.GRID);
		} else if(other.tag == Tags.GRID_EXIT_DOOR){
			LoadingScreen.isLoading = true;
			Application.LoadLevel(Levels.WORLD);
		}
	}
	void OnTriggerStay(Collider other){
		if(other.tag == Tags.TRAMPOLINE){
			_jump = true;
		} else {
			_jump = false;
		}
	}
	void OnTriggerExit(Collider other){
		_jump = false;
	}
	
	public bool jump {
		get {
			return _jump;
		}
		set {
			_jump = value;
		}
	}
}
