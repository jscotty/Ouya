using UnityEngine;
using System.Collections;

public class PlayerRotating : MonoBehaviour {

	[SerializeField]
	private float _smoothRot = 3f;

	private Quaternion _rotation = Quaternion.identity;
	private Rigidbody _body;

	private float _horizontal,_vertical;

	void Start() {
		_body = gameObject.GetComponent<Rigidbody> ();
	}

	void Update () {
		_horizontal = -Input.GetAxis ("Horizontal");
		_vertical = -Input.GetAxis ("Vertical");

		Rotating();
	}
	
	void Rotating () {
		Vector3 targetDirection = new Vector3(_horizontal, 0f, _vertical);
		
		_rotation = Quaternion.LookRotation(targetDirection, Vector3.up);
		
		Quaternion newRotation = Quaternion.Lerp(_body.rotation, _rotation, _smoothRot * Time.deltaTime);
		
		_body.MoveRotation(newRotation);
	}
}
