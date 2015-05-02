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
	
	private GameObject _newLineHolder;
	
	private int _currentLineID = 0;
	private int _lineCount = 0;
	private int _lineIndex = 0;
	private int _pointLines = 0;
	private int _lastLineCount = 0;

	private bool _mouseDown = false; 

	private Camera _mainCamera;
	private Vector3 _mouseWorld;
	private Vector3 _lastPos = Vector3.one * float.MaxValue;
	private List<LineRenderer> _lines = new List<LineRenderer>();
	private List<GameObject> _lineHolders = new List<GameObject>();
	private List<Vector3> _linePoints = new List<Vector3>();

	private Vector3 _lineStartPosition;
	private Vector3 _lineEndPosition;
	private GameObject _points;
	private GameObject _startPoint;
	private GameObject _endPoint;
	private RaycastHit _hit;
	private bool[] _hitPoints = new bool[10];
	private int _count = 0;
	private bool _allTrue;
	private bool _fail;
	
	
	// Use this for initialization
	void Awake() {
		_mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update() {
		// Check if the mouse is down and set the screen to world position.  
		checkMouseDown();
		setMouseWorld();
			
		if (_mouseDown == true) {
			// Check distance.
			float dist = Vector3.Distance(_lastPos, _mouseWorld);

			// Check if distance is below the threshold, if not then cancel. 
			if (dist <= threshold) {
				return;
			}

			_lastPos = _mouseWorld; // Set the last position.
				
				// Make a liust of the linepoints if it doesn't exist.
			if (_linePoints == null) {
				_linePoints = new List<Vector3>();
			}
				// Add the position of the mouse to the array of linepoints. 
			_linePoints.Add(_mouseWorld);

				// Update the line.
			UpdateLine();
			GameObject startPoint = GameObject.Find("linePoint1");
			GameObject endPoint = GameObject.Find("linePoint" + _pointLines);

			Vector3 pos = _points.transform.position;
			pos.x = pos.x * -(Input.mousePosition.x / pos.x) * -1;
			pos.y = pos.y * -(Input.mousePosition.y / pos.y) * -1;
			//pos.y = pos.y * 173.8461538461538f;
			//print(ray);
			Ray ray = Camera.main.ScreenPointToRay(pos);
			if (Physics.Raycast(ray, out _hit)){
				//print(_hit.transform.gameObject.name);
				for (int i = 0; i < 10; i++) {
					int index = i + 1;
					//print(hit.transform.gameObject.name);
					//print(hitPoints[i] + " (" + i + ")");
					if(_hit.transform.gameObject.name == Names.POINT + index){
						_count ++;
						if(_count == 1){
							_startPoint = _hit.transform.gameObject;
						}
						print("ja");
						_hitPoints[i] = true;
					} else if(_hit.transform.gameObject.name == Names.LINE_POINT + 1){
						_count ++;
						if(_count == 1){
							_startPoint = _hit.transform.gameObject;
						}
					}
				}
			}

			_allTrue = true;
			for (int i = 0; i < _hitPoints.Length; i++) {
				if(!_hitPoints[i]){
					_allTrue = false;
				}
			}
		}
		
	}
	
	// Set the mouse to world position. 
	void setMouseWorld() {
		Vector3 mousePos = Input.mousePosition;
		mousePos.z = 10;
		_mouseWorld = _mainCamera.ScreenToWorldPoint(mousePos);
	}
	
	void UpdateLine() {
		// Mousedown, create new linerenderer if line doesn't exist, and add it to a new lineholder.
		if (_lines.Count - 1 < _currentLineID) {
			_lineIndex++;
			setMouseWorld ();
			_newLineHolder = new GameObject ("LineHolder" + _lineIndex);
			_newLineHolder.tag = Tags.DRAW_LINE;
			LineRenderer newLine = _newLineHolder.AddComponent<LineRenderer> () as LineRenderer;
			newLine.material = lineColorBlack;
			newLine.SetWidth (0, 0);
			newLine.useWorldSpace = false;
			_lines.Add (newLine);

		} else if (_lines.Count - 1 == _currentLineID) {
			
			// Set the line properties.
			_lines [_currentLineID].SetWidth (startWidth, endWidth);
			_lines [_currentLineID].SetVertexCount (_linePoints.Count);

			if (_linePoints.Count > 0) {
				_pointLines++;
				_points = new GameObject ("linePoint" + _pointLines);
				_points.transform.SetParent (_newLineHolder.transform);
				_points.transform.position = Vector3.Lerp (_linePoints [_linePoints.Count - 1], _linePoints [_linePoints.Count - 2], 0.5f);
				if (_pointLines == 1) {
					BoxCollider bc = _points.AddComponent<BoxCollider> ();
					_points.transform.LookAt (_linePoints [_linePoints.Count - 1]);
					bc.size = new Vector3 (0.20f, 0.15f, Vector3.Distance (_linePoints [_linePoints.Count - 1], _linePoints [_linePoints.Count - 2]));
				} else {
					if(_pointLines > 1){
						_endPoint = _points;
					}
				}
			}
			
			// Set the lines to their proper positions.
			for (int i = _lineCount; i < _linePoints.Count; i++) {
				_lines [_currentLineID].SetPosition (i, _linePoints [i]);
			}
			
			_lastLineCount = _lineCount;
			_lineCount = _linePoints.Count;
		}
	}
	
	void checkMouseDown() {
		// Check if the mouse is down, if it is set drawing on true, on release return it to false.
		if(Input.GetMouseButtonDown(0)) {
			setMouseWorld();
			if(mouseDown)
				_mouseDown = false;
			else
				_mouseDown = true;

			_lineCount = 0;
		}

		else if(Input.GetMouseButtonUp(0)) {
			_linePoints.Clear();
			_currentLineID += 1;
		}
	}

	
	#region Getters and Setters
	public int lineIndex {
		get {
			return _lineIndex;
		}
		set {
			_lineIndex = value;
		}
	}

	public int pointLines {
		get {
			return _pointLines;
		}
		set {
			_pointLines = value;
		}
	}
	
	public bool allTrue {
		get {
			return _allTrue;
		}
		set {
			_allTrue = value;
		}
	}
	
	public bool mouseDown {
		get {
			return _mouseDown;
		}
		set {
			_mouseDown = value;
		}
	}
	
	public bool fail {
		get {
			return _fail;
		}
		set {
			_fail = value;
		}
	}
	
	public GameObject startPoint {
		get {
			return _startPoint;
		}
		set {
			_startPoint = value;
		}
	}
	
	public GameObject endPoint {
		get {
			return _endPoint;
		}
		set {
			_endPoint = value;
		}
	}

	#endregion
}