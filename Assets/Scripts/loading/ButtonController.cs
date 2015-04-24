using UnityEngine;
using System.Collections;

public class ButtonController : MonoBehaviour {

	private DrawLine _drawLine;
	private int lineHolderIndex;

	void Start(){
		_drawLine = GetComponent<DrawLine> ();
	}

	void Update(){
		lineHolderIndex = _drawLine.lineIndex;
		if(Input.GetKeyDown(KeyCode.Backspace)){
			Undo();
		}
	}

	public void Undo(){
		print (lineHolderIndex);
		GameObject lineHolder = GameObject.Find ("LineHolder" + lineHolderIndex);
		Destroy (lineHolder);
		_drawLine.lineIndex--;
	}
}
