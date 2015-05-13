using UnityEngine;
using System.Collections;

public class PlayerSFX : MonoBehaviour {

	public AudioClip jumpSound;

	private AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource>();
	}

	public void PlayJumpSound(){
		audio.PlayOneShot(jumpSound,1f);
	}
}
