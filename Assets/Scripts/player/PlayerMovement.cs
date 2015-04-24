using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private int _speed;

	private Rigidbody _body;

	void Start () {
		_body = gameObject.GetComponent<Rigidbody> ();
		//_speed = _speed * 100;
	}

	void Update () {

		Move ();
	}

	private void Move(){
		Vector3 moveVelocity = _body.velocity;
		moveVelocity.x = Input.GetAxis ("Horizontal");
		moveVelocity.y = 0;
		moveVelocity.z = Input.GetAxis ("Vertical");
		_body.velocity = moveVelocity * _speed;
		//print (_body.velocity);
	}

}
