using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private int _speed;

	private Rigidbody _body;
	private bool _keyDown;

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

		if(moveVelocity.x == 0f && moveVelocity.z == 0f){
			_keyDown = false;
		} else {
			_keyDown = true;
		}
	}

	#region Geters and setters
	
	public bool keyDown {
		get {
			return _keyDown;
		}
		set {
			_keyDown = value;
		}
	}

	#endregion

}
