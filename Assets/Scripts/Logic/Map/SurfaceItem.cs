using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceItem : BaseItem {

	public void AddChild(BaseItem item)
	{
		if(item!=null)
		item.transform.parent = transform;
	}

	public void AddChild(BaseItem item ,Vector3 localPosition)
	{
		if(item!=null)
		{
			item.transform.localPosition = Vector3.zero;
			item.transform.parent = transform;
			item.transform.localEulerAngles = Vector3.zero;
			item.transform.localPosition = localPosition;
		}
	}
}
