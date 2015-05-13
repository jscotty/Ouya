using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	public PlayerCollision playerCol;
	Animator anim;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update () {
		if(Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0){
			anim.SetBool("Walk", false);
		} else {
			anim.SetBool("Walk", true);
		}

		if(playerCol.jump){
			anim.SetBool("Jump", true);
		} else {
			anim.SetBool("Jump", false);
		}
	}
}
