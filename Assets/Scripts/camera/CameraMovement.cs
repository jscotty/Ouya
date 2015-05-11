using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private int _speed;
	
	private Rigidbody _body;

	private Vector3 _cameraPos;
	private Vector3 _playerPos;
	private Vector3 _dis;
	private PlayerMovement _playerMove;
	
	void Start () {
		_body = GetComponent<Rigidbody>();
		_playerMove = _player.GetComponent<PlayerMovement>();
	}
	
	void Update () {
		_cameraPos = gameObject.transform.position;
		_playerPos = _player.transform.position;

		_dis = _playerPos - _cameraPos;

		Move ();
	}
	
	private void Move(){
//		print("x: " + _dis.x + "  | z: " + _dis.z);

		Vector3 moveVelocity = _body.velocity;
		if(_dis.x >= 1f){
			moveVelocity.x = 1;
		} else if(_dis.x <= -1f){
			moveVelocity.x = -1;
		} else {
			moveVelocity.x = 0;
		}
		moveVelocity.y = 0;
		if(_dis.z >= 5.4f){
			moveVelocity.z = 1;
		} else if(_dis.z <= 4.5f){
			moveVelocity.z = -1;
		} else {
			moveVelocity.z = 0;
		}

		if(_playerMove.keyDown){

		} else {
			transform.position = Vector3.MoveTowards(transform.position, new Vector3(_playerPos.x, _cameraPos.y, _playerPos.z + -5f), (_speed -2)* Time.deltaTime);
		}

		_body.velocity = moveVelocity * _speed;
	}
}
