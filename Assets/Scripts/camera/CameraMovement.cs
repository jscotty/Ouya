using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public bool build;
	[SerializeField]
	private GameObject _player;
	[SerializeField]
	private int _speed;

	private int _z = -7;
	
	private Rigidbody _body;

	private Vector3 _cameraPos;
	private Vector3 _playerPos;
	private Vector3 _dis;
	private Movement _playerMove;
	
	void Start () {
		_body = GetComponent<Rigidbody>();
		_playerMove = _player.GetComponent<Movement>();

		if(build)
			_z = -2;
	}
	
	void Update () {
		_cameraPos = gameObject.transform.position;
		_playerPos = _player.transform.position;

		_dis = _playerPos - _cameraPos;

		Move ();
	}
	
	private void Move(){
//		print("x: " + _dis.x + "  | z: " + _dis.z);
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(_playerPos.x, _cameraPos.y, _playerPos.z + _z), (_speed)* Time.deltaTime);

	}

}
