using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	[SerializeField]
	private int _speed;
	
	private Rigidbody _body;
	
	void Start () {
		_body = gameObject.GetComponent<Rigidbody> ();
		_speed = _speed * 100;
	}
	
	void Update () {
		
		Move ();
	}
	
	private void Move(){
		Vector3 moveVelocity = _body.velocity;
		moveVelocity.x = Input.GetAxis ("Horizontal");
		moveVelocity.y = 0;
		_body.velocity = moveVelocity * _speed * Time.deltaTime;
		//print (_body.velocity);
	}
}
