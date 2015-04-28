using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public GameObject plane;
	public GameObject planeTwo;
	private int width = 10;
	private int height = 10;

	private float cellWidth = -1.0f;
	private float cellHeight = 1.0f;


	private int[,] gridList = new int[,]{
		{0,0,0,0,0,0,0,0,0,1},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
	};

	void Awake(){
		CreateGrid ();
	}

	public void CreateGrid(){
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				
				//print("x: " + x + " | z: " + z);
				if(gridList[x,z] == 0){
					GameObject gridPlane = (GameObject)Instantiate(plane);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth;
					gridV.z = z * cellHeight;
					gridPlane.transform.position = gridV;
				} else {
					//print ("jo");
					GameObject gridPlane2 = (GameObject)Instantiate(planeTwo);
					Vector3 gridV2 = gridPlane2.transform.position;
					gridV2.x = x * cellWidth;
					gridV2.z = z * cellHeight;
					gridPlane2.transform.position = gridV2;
				}
			}
		}
	}

	void Start (){
	
	}

	void Update (){
	
	}
}
