using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFight : MonoBehaviour {

	[SerializeField]
	Text _p1_hp,_p1_power,_p1_name;

	[SerializeField]
	Text _p2_hp,_p2_power,_p2_name;

	[SerializeField]
	Text _score;

	// Use this for initialization
	void Start () {
		
	}
	
	public void SetScore(string value)
	{
		_score.text = value;
	}

	public void SetHP(Enum_Players playerType,string value)
	{
		switch (playerType) {
		case Enum_Players.p1:
			_p1_hp.text = value;
			break;
		case Enum_Players.p2:
			_p2_hp.text = value;
			break;
		default:
			break;
		}
	}

	public void SetPower(Enum_Players playerType,string value)
	{
		switch (playerType) {
		case Enum_Players.p1:
			_p1_power.text = value;
			break;
		case Enum_Players.p2:
			_p2_power.text = value;
			break;
		default:
			break;
		}
	}

	public void SetPlayerName(Enum_Players playerType,string value)
	{
		switch (playerType) {
		case Enum_Players.p1:
			_p1_name.text = value;
			break;
		case Enum_Players.p2:
			_p2_name.text = value;
			break;
		default:
			break;
		}
	}
}
