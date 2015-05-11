using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour {
	
	private int _paintLevel;
	private int _bodyColor;
	
	private string _name;
	
	#region paintLevel
	public int paintLevel{
		get{
			return _paintLevel;
		}
		
		set{
			_paintLevel = value;
		}
	}
	#endregion
	
	#region bodyColor
	public int bodyColor{
		get{
			return _bodyColor;
		}
		
		set{
			_bodyColor = value;
		}
	}
	#endregion
	
	#region bodyColor
	public string name{
		get{
			return _name;
		}
		
		set{
			_name = value;
		}
	}
	#endregion
}
