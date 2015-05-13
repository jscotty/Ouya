using UnityEngine;
using System.Collections;

public class BackPack : MonoBehaviour {

	public static int choosItem;
	public static int amountLeft;

	public static int[] itemAmount = new int[12];

	public void Build(int item){
		choosItem = item;
		amountLeft = itemAmount[item];

		LoadingScreen.isLoading = true;
		Application.LoadLevel(Levels.BUILD_GRID);
	}
}
