using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadData : MonoBehaviour {

	public PlayerData playerData;
	
	void Start(){
		print (Application.persistentDataPath + "/Save.dat");
	}
	
	public void Save () {
		/*Binary formatter maakt de saved data binair waardoor het moeilijk te hacken
		 is voor de user*/
		BinaryFormatter binaryFormatter = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/Save.dat");
		
		SaveData saveData = new SaveData();
		saveData.score = playerData.bodyColor;
		
		binaryFormatter.Serialize (file, saveData);
		file.Close ();
		
		Debug.Log ("Saved" + " | " + playerData.bodyColor);
	}
	
	public void Load () {
		if (File.Exists (Application.persistentDataPath + "/Save.dat")) {
			BinaryFormatter binaryFormatter = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + "/Save.dat", FileMode.Open);
			
			SaveData saveData = (SaveData)binaryFormatter.Deserialize(file);
			playerData.bodyColor = saveData.score;
			Debug.Log ("Loaded" + " | " + playerData.bodyColor);
		}
		
	}
}

[System.Serializable] // zorgt ervoor dat je die kan wegschrijven naar unity
public class SaveData{
	public int score;
}