using UnityEngine;
using System.Collections;

public class PlayerGridDetection : MonoBehaviour {

	private PlayerMovement _playerMovement;
	private float _indexX;
	private float _indexY;
	
	private float posX;
	private float posZ;

	void Start () {
		_playerMovement = gameObject.GetComponent<PlayerMovement> ();
	}

	void Update () {
		GridPos ();
	}

	private void GridPos(){
		Vector3 player = transform.position;
		_indexX = Mathf.Round (player.x + posX);
		_indexY = Mathf.Round (((player.z - posZ) % 9) * -1);
		//print (_indexX + " | iY: " + _indexY + " PY: " + player.z);
	}
	
	#region
	
	public float indexX{
		get {
			return _indexX;
		}
		set {
			_indexX = value;
		}
	}
	
	public float indexY{
		get {
			return _indexY;
		}
		set {
			_indexY = value;
		}
	}
	
	#endregion
}
