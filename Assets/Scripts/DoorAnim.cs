using UnityEngine;
using System.Collections;

public class DoorAnim : MonoBehaviour {

	Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void OnTriggerStay(Collider other){
		print(other);
		if(other.tag == Tags.PLAYER){
			anim.SetBool("Open", true);
		}
	}
	void OnTriggerExit(Collider other){
			anim.SetBool("Open", false);
	}
}
