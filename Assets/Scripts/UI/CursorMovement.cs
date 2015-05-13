using UnityEngine;
using System.Collections;

public class CursorMovement : MonoBehaviour {


	void Update () {
		transform.position = Input.mousePosition;
	}
}
