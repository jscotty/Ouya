using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collision : MonoBehaviour {
	
	public StartMenu startMenu;
	public ChooseMenu chooseMenu;
	public BackPack backpack;

	private RaycastHit _hit;
	private string _hitName;
	private string a = "Fire1";

	void Update(){
		Vector3 pos = transform.position;	
		Vector3 rayPos = new Vector3(pos.x - 250f,pos.y - 120f,pos.z);
		Ray ray = new Ray(transform.position, transform.forward);
		//print(transform.position + transform.position);
		Debug.DrawRay(pos, transform.forward , Color.red);
		if (Physics.Raycast(ray, out _hit)){
			_hitName = _hit.transform.gameObject.name;
			print(_hitName);
			if(_hitName == Tags.PLAY){
				if(Input.GetButtonUp(InputButton.O))
					startMenu.StartButton();
			} else if(_hitName == Tags.OPTIONS){
				if(Input.GetButtonUp(InputButton.O))
					startMenu.OptionsButton();
			} else if(_hitName == Tags.BACK){
				if(Input.GetButtonUp(InputButton.O))
					startMenu.BackButton();
			} 
			// choose menu buttons
			else if(_hitName == Tags.PLAY_DRAW){
				if(Input.GetButtonUp(InputButton.O))
					chooseMenu.Play();
			} else if(_hitName == Tags.CREATE){
				if(Input.GetButtonUp(InputButton.O))
					chooseMenu.Create();
			} else if(_hitName == Tags.BACK_DRAW){
				if(Input.GetButtonUp(InputButton.O)){
					chooseMenu.Back();
				}
			} else if(_hitName == Tags.BACK_DRAW_MENU){
				if(Input.GetButtonUp(InputButton.O)){
					chooseMenu.Create();
				}
			}
			for (int i = 0; i < 16; i++) {
				if(_hitName == Tags.IMAGE + i){
					if(Input.GetButtonUp(InputButton.O))
						backpack.Build(i);
				}
			}

		}
	}
}
