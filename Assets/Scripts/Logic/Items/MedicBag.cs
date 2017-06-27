using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicBag : BaseItem {

	void Start()
	{
		Init ();
	}

	public override void Init ()
	{
		base.Init ();
	}

	protected override void OnMyTriggerEnter (Collider collider)
	{
		BaseItem item = collider.GetComponent<BaseItem> ();

		if(item==null)
		{
			Debug.LogError ("item is null,Collider :"+ collider.name);
			return;
		}

		if(item.ItemType == EnumItemType.Actor)
		{
			//治疗单位

			//移除自己
			Remove ();
		}

		base.OnMyTriggerEnter (collider);
	}
}
