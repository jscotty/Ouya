using UnityEngine;
using System.Collections;

public class LineCheck : MonoBehaviour {
	
	private DrawLine drawLine;
	private bool allTrue;
	private int points;
	private int maxPoints = 180;
	private int minPoints = 130;
	private GameObject startPoint;
	private GameObject endPoint;

	void Start () {
		drawLine = GetComponent<DrawLine> ();	
	}

	void Update () {
		allTrue = drawLine.allTrue;
		points = drawLine.pointLines;
		startPoint = drawLine.startPoint;
		endPoint = drawLine.endPoint;

		if (allTrue && points < maxPoints && points > minPoints) {
			Vector3 dif = startPoint.transform.position - endPoint.transform.position;
			float allDif = dif.x + dif.y + dif.z;
			print(Mathf.Floor(allDif));
			if(Mathf.Floor(allDif) == 0){
				print("DONE");
				drawLine.mouseDown = false;
			}
		}
	}
}
