using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
	public GameObject plane;
	public GameObject planeTwo;
	public PlayerGridDetection playerGridDetection;
	private int width = 10;
	private int height = 10;

	private float cellWidth = -1.0f;
	private float cellHeight = 1.0f;

	private int _playerX;
	private int _playerY;
	private int max = 1;
	private int count = 0;

	private GameObject obj;

	private int[,] gridList = new int[,]{
		{0,0,0,0,0,0,0,0,0,0},
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
		if (obj != null) {
			Destroy(obj);
			print("ja");
			obj = new GameObject ("gridHolder");
		} else 
			obj = new GameObject ("gridHolder");
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				
				//print("x: " + x + " | z: " + z);
				if(gridList[z,x] == 0){
					GameObject gridPlane = (GameObject)Instantiate(plane);
					gridPlane.transform.SetParent(obj.transform);
					Vector3 gridV = gridPlane.transform.position;
					
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
				} else {
					//print ("jo");
					GameObject gridPlane2 = (GameObject)Instantiate(planeTwo);
					gridPlane2.transform.SetParent(obj.transform);
					Vector3 gridV2 = gridPlane2.transform.position;
					gridV2.x = x * cellWidth * -1;
					gridV2.z = z * cellHeight * -1;
					gridPlane2.transform.position = gridV2;
				}
			}
		}

	}

	void Start (){

	}

	void Update (){
		_playerX = Mathf.FloorToInt(playerGridDetection.indexX);
		_playerY = Mathf.FloorToInt(playerGridDetection.indexY);

		if (Input.GetKeyDown (KeyCode.Space)) {
			ReadGridFile ();
		} else if (Input.GetKeyDown (KeyCode.Z)) {
			CreateGrid ();
			print("ho");
		}
		GridDetect ();
	}

	void GridDetect(){
		//print (gridList[_playerY,_playerX]);
		if (gridList [_playerY, _playerX] == 1) {
			Application.LoadLevel(2);
		}
	}

	void SendGridFile(){
		string str = "";
		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				if(i >= max){
					max ++;
					if(max > width){

					} else {
						str = str + "\n"  + (gridList[i,j]);
					}
				} else {
					count ++;
					if(count == 1){
						str = str + (gridList[i,j]);
					} else 
						str = str + "," + (gridList[i,j]);
				}
			}
		}
		StreamWriter sr = File.CreateText (Application.persistentDataPath + "/grid.txt");
		sr.WriteLine (str);
		sr.Close ();
		//print (Application.persistentDataPath + "/grid.txt");
	}

	void ReadGridFile(){
		string reader = File.ReadAllText(Application.persistentDataPath + "/grid.txt");
		//print (reader);

		int[,] mapArray = new int[width,height];
		int i = 0, j = 0;
		foreach (var row in reader.Split('\n')) {
			foreach (var col in row.Trim().Split(',')) {
				//mapArray[i,j] = int.Parse(col.Trim());
				//gridList[i,j] = int.Parse(col.Trim());
				print("i : " + i + " j: " + j + "  " + int.Parse(col.Trim()));
				gridList[i,j] = int.Parse(col.Trim());
				j ++;
				if(j >= width ){
					j = 0;
				}
				//print ("j: " + j);
			}
			i++;
			//print ("i: " + i);
		}
	}
}
