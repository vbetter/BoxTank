using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldMgr : ISingleton<WorldMgr> {

	public SurfaceItem[] SurfaceItems;

	public List<BaseItem> _allActors = new List<BaseItem> ();
	public List<BaseItem> _allShells = new List<BaseItem> ();
	// Use this for initialization
	void Start () {
		
	}

	public SurfaceItem GetSurfaceItem(EnumSurface surface)
	{
		foreach (var item in SurfaceItems) {
			if (item.CurSurface == surface)
				return item;
		}
		return null;
	}

	public void AddPlayer(Player item ,EnumSurface surface)
	{
		SurfaceItem surfaceItem = GetSurfaceItem (surface);
		if(surfaceItem!=null)
		{
			item.CurSurface = surface;
			surfaceItem.AddChild (item,Vector3.zero);
		}
	}

	public void AddShells(BaseItem item)
	{
		_allShells.Add (item);
	}
}
