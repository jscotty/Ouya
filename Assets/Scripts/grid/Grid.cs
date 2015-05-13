using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class Grid : MonoBehaviour {
	public bool build;
	public GameObject[] planes;
	public PlayerGridDetection playerGridDetection;
	private int width = 10;
	private int height = 10;

	private float cellWidth = -1.0f;
	private float cellHeight = 1.0f;

	private int _playerX;
	private int _playerY;
	private int max = 1;
	private int count = 0;
	private int num;
	private bool res;

	private GameObject obj;

	private int[,] gridList = new int[,]{
		{-1, 0,-1,-1,-1,-1,-1,-1,-1,-2},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
		{-1,-1,-1,-1,-1,-1,-1,-1,-1,-1},
	};

	void Awake(){
		//SendGridFile();
		ReadGridFile();
		CreateGrid ();
		max = 1;
		count = 0;
	}

	public void CreateGrid(){
		if (obj != null) {
			Destroy(obj);
			obj = new GameObject ("gridHolder");
		} else 
			obj = new GameObject ("gridHolder");
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < height; z++) {
				
				//print("x: " + x + " | z: " + z);
				if(gridList[z,x] == -1){
					if(build){
						GameObject gridPlane = (GameObject)Instantiate(planes[0]);
						gridPlane.transform.SetParent(obj.transform);
						Vector3 gridV = gridPlane.transform.position;
						
						gridV.x = x * cellWidth * -1;
						gridV.z = z * cellHeight * -1;
						gridPlane.transform.position = gridV;
					}
				} else if(gridList[z,x] == -2) {
					//print ("jo");
					GameObject gridPlane = (GameObject)Instantiate(planes[1]);
					gridPlane.transform.SetParent(obj.transform);
					Vector3 gridV = gridPlane.transform.position;
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
				} else if(gridList[z,x] == 0) {
					//print ("jo");
					GameObject gridPlane = (GameObject)Instantiate(planes[2]);
					gridPlane.transform.SetParent(obj.transform);
					Vector3 gridV = gridPlane.transform.position;
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
				} else if(gridList[z,x] == 1) {
					//print ("jo");
					GameObject gridPlane = (GameObject)Instantiate(planes[3]);
					gridPlane.transform.SetParent(obj.transform);
					Vector3 gridV = gridPlane.transform.position;
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
				} else if(gridList[z,x] == 2) {
					//print ("jo");
					GameObject gridPlane = (GameObject)Instantiate(planes[4]);
					gridPlane.transform.SetParent(obj.transform);
					Vector3 gridV = gridPlane.transform.position;
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
				} else if(gridList[z,x] == 3) {
					//print ("jo");
					GameObject gridPlane = (GameObject)Instantiate(planes[5]);
					gridPlane.transform.SetParent(obj.transform);
					Vector3 gridV = gridPlane.transform.position;
					gridV.x = x * cellWidth * -1;
					gridV.z = z * cellHeight * -1;
					gridPlane.transform.position = gridV;
				} else {

				}
			}
		}

	}

	void Update (){
		_playerX = Mathf.FloorToInt(playerGridDetection.indexX);
		_playerY = Mathf.FloorToInt(playerGridDetection.indexY);


		GridDetect ();
	}

	void GridDetect(){
		//print (gridList[_playerY,_playerX]);
		if (gridList [_playerY, _playerX] == -2) {
			if(build){

			} else {
				LoadingScreen.isLoading = true;
				Application.LoadLevel(Levels.CHOOSE_MENU);
			}
		}
		if(build){
			print(gridList [_playerY, _playerX]);
			if (gridList [_playerY, _playerX] == -1 && Input.GetButtonUp(InputButton.O)) {
				//if(Input.GetButtonUp(InputButton.A)){
					//print("hoi" + BackPack.choosItem);
					gridList [_playerY, _playerX] = BackPack.choosItem;
					SendGridFile();
					CreateGrid();
					max = 1;
					count = 0;
				//}

			} else if (Input.GetButtonUp(InputButton.U)) {
				//if(Input.GetButtonUp(InputButton.A)){
				print("h");
				if(gridList [_playerY, _playerX] >= 0){
					gridList [_playerY, _playerX] = -1;
					SendGridFile();
					CreateGrid();
					max = 1;
					count = 0;
				}
				//}
				
			}
		}
	}

	void SendGridFile(){
		
		/*if (File.Exists (Application.persistentDataPath + "/grid.txt")) 
			File.Delete(Application.persistentDataPath + "/grid.txt");*/
		string str = "";
		for(int i = 0; i < width; i++) {
			for(int j = 0; j < height; j++) {
				if(i >= max){
					max ++;
					if(max > width){
					} else {
						str = str + "\r\n"  + (gridList[i,j]);
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
		//print(Application.persistentDataPath + "/grid.txt");
		if (File.Exists (Application.persistentDataPath + "/grid.txt")) {
			string reader = File.ReadAllText(Application.persistentDataPath + "/grid.txt");

			int i = 0, j = 0;
			foreach (var row in reader.Split('\n')) {
				foreach (var col in row.Trim().Split(',')) {
					//print("i : " + i + " j: " + j + "  " + int.Parse(col.Trim()));
					res = int.TryParse(col.Trim(), out num);
					//print(res);
					if(res)
						gridList[i,j] = int.Parse(col.Trim());
					j ++;
					if(j >= width ){
						j = 0;
					}
				}
				i++;
			}
		} else {
			SendGridFile();
		}
	}
}
