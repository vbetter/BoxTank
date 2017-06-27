using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMgr : ISingleton<CameraMgr> {

	const string CameraPath = "Camera/Camera_player";

	public override IEnumerator LoadData ()
	{
		return base.LoadData ();
	}
		
	public void AddPlayer(Player item)
	{
		if (item != null) 
		{
			GameObject go = Instantiate(Resources.Load (CameraPath)) as GameObject;
			go.transform.parent = item.transform;
			go.transform.localPosition = Vector3.zero;

			CameraControl cameraControl = go.GetComponent<CameraControl> ();
			if(cameraControl!=null)
			{
				cameraControl.Init (item);
			}
		}
	}
}
