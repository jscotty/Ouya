using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if(other.tag == Tags.HOME){
			Application.LoadLevel(2);
		}
	}
}
