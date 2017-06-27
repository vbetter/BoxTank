using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : ISingleton<PlayerMgr> 
{
	public static int ActorCounter =1;//角色id计数器，每生成一个id++

	public EnumSurface CurSurface = EnumSurface.A;//当前所在平面

	public Player Player1;
	public Player Player2;

	const string P1ModelPath ="Player/Player";
	const string P2ModelPath ="Player/Player";

	public override IEnumerator LoadData ()
	{
		InitPlayer1 ();
		InitPlayer2 ();

		return base.LoadData ();
	}

	void InitPlayer1()
	{
		GameObject player = Instantiate(Resources.Load (P1ModelPath)) as GameObject;
		if(player!=null)
		{
			Player1=player.GetComponent<Player> ();
			if(Player1!=null)
			{
				Player1.Init (Enum_Players.p1);
				Player1.ActorID = ActorCounter++;

				CameraMgr.Instance.AddPlayer (Player1);

				WorldMgr.Instance.AddPlayer (Player1,EnumSurface.A);
			}
		}
	}

	void InitPlayer2()
	{
		GameObject player = Instantiate(Resources.Load (P2ModelPath)) as GameObject;
		if(player!=null)
		{
			Player2=player.GetComponent<Player> ();
			if(Player2!=null)
			{
				Player2.Init (Enum_Players.p2);
				Player2.ActorID = ActorCounter++;

				CameraMgr.Instance.AddPlayer (Player2);

				WorldMgr.Instance.AddPlayer (Player2,EnumSurface.C);
			}
		}
	}
}
