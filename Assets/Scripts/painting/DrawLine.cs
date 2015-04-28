using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour {
	public float startWidth = 10.0f;
	public float endWidth   = 10.0f;
	public float threshold  = 0.01f;
	public Material lineColorBlack;
	public PhysicMaterial colliderMaterial;
	
	private GameObject newLineHolder;
	
	int currentLineID = -1;
	int lineCount = 0;
	int _lineIndex = 0;
	int _linePoints = 0;
	int lastLineCount = 0;

	bool mouseDown = false; 

	Camera mainCamera;
	Vector3 mouseWorld;
	Vector3 lastPos = Vector3.one * float.MaxValue;
	List<LineRenderer> lines = new List<LineRenderer>();
	List<GameObject> lineHolders = new List<GameObject>();
	List<Vector3> linePoints = new List<Vector3>();

	Vector3 lineStartPosition;
	Vector3 lineEndPosition;
	GameObject points;
	RaycastHit hit;
	
	
	
	// Use this for initialization
	void Awake() {
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update() {
		// Check if the mouse is down and set the screen to world position.  
		checkMouseDown();
		setMouseWorld();
			
		if (mouseDown == true) {
			// Check distance.
			float dist = Vector3.Distance(lastPos, mouseWorld);

			// Check if distance is below the threshold, if not then cancel. 
			if (dist <= threshold) {
				return;
			}

			lastPos = mouseWorld; // Set the last position.
				
				// Make a liust of the linepoints if it doesn't exist.
			if (linePoints == null) {
				linePoints = new List<Vector3>();
			}
				// Add the position of the mouse to the array of linepoints. 
			linePoints.Add(mouseWorld);

				// Update the line.
			UpdateLine();
			GameObject startPoint = GameObject.Find("linePoint1");
			GameObject endPoint = GameObject.Find("linePoint" + _linePoints);
				
			/*if(endPoint != null){
				lineStartPosition = startPoint.transform.position;
				lineEndPosition = endPoint.transform.position;
				//print("startP: " + lineStartPosition + " | endP: " + lineEndPosition);
				RaycastHit hit;
				print(hit.transform.position);
				if (Physics.Raycast (lineStartPosition, lineEndPosition - lineStartPosition, out hit)) {
					print(hit.transform.gameObject.name);
					
				}
			}*/
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//print(ray);
			if (Physics.Raycast(ray, out hit))
				print(hit.transform.gameObject.name);
		}
		
	}
	
	// Set the mouse to world position. 
	void setMouseWorld() {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;
		mouseWorld = mainCamera.ScreenToWorldPoint(mousePos);
	}
	
	void UpdateLine() {
		// Mousedown, create new linerenderer if line doesn't exist, and add it to a new lineholder.
		if(lines.Count - 1 < currentLineID)
		{
			_lineIndex++;
			setMouseWorld();
			newLineHolder = new GameObject("LineHolder" + _lineIndex);
			newLineHolder.tag = Tags.DRAW_LINE;
			LineRenderer newLine = newLineHolder.AddComponent<LineRenderer>() as LineRenderer;
			newLine.material = lineColorBlack;
			newLine.SetWidth(0, 0);
			newLine.useWorldSpace = false;
			lines.Add(newLine);

		}
		else if(lines.Count - 1 == currentLineID) {
			
			// Set the line properties.
			lines[currentLineID].SetWidth(startWidth, endWidth);
			lines[currentLineID].SetVertexCount(linePoints.Count);
			
			// Add a collider between the last two linepoints.
			if (linePoints.Count > 0) {
				_linePoints++;
				points = new GameObject("linePoint" + _linePoints);
				points.tag = Tags.DRAW_LINE;
				points.transform.SetParent(newLineHolder.transform);
				points.transform.position = Vector3.Lerp(linePoints[linePoints.Count - 1], linePoints[linePoints.Count - 2], 0.5f);
				//colliderKeeper.transform.LookAt(linePoints[linePoints.Count - 1]);
				//bc.size = new Vector3(0.20f, 0.15f, Vector3.Distance(linePoints[linePoints.Count - 1], linePoints[linePoints.Count - 2]));
				
			}
			
			// Set the lines to their proper positions.
			for (int i = lineCount; i < linePoints.Count; i++) {
				lines[currentLineID].SetPosition(i, linePoints[i]);
			}
			
			lastLineCount = lineCount;
			lineCount = linePoints.Count;
		}
	}
	
	void checkMouseDown() {
		// Check if the mouse is down, if it is set drawing on true, on release return it to false.
		if(Input.GetMouseButtonDown(0)) {
			setMouseWorld();
			mouseDown = true;
			lineCount = 0;
		}

		else if(Input.GetMouseButtonUp(0)) {
			linePoints.Clear();
			mouseDown = false;
			currentLineID += 1;
		}
	}

	
	
	public int lineIndex {
		get {
			return _lineIndex;
		}
		set {
			_lineIndex = value;
		}
	}
}