using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	[SerializeField]
	private int _speed;
	[SerializeField]
	private bool _y;

	private int _saveSpeed;
	private Rigidbody _body;
	private bool _keyDown;
	private Vector3 _moveVelocity;

	void Start () {
		_saveSpeed = _speed;
		_body = gameObject.GetComponent<Rigidbody> ();
		//_speed = _speed * 100;
	}

	void Update () {
		Move ();
	}

	private void Move(){
		_moveVelocity = _body.velocity;
		_moveVelocity.x = Input.GetAxis ("Horizontal");
		if(_y){
			_moveVelocity.y = Input.GetAxis ("Vertical");
		} else {
			_moveVelocity.y = 0;
			_moveVelocity.z = Input.GetAxis ("Vertical");
		}

		_body.velocity = _moveVelocity * _speed;
		//print (_body.velocity);

		if(_moveVelocity.x == 0f && _moveVelocity.z == 0f){
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
