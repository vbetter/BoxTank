using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumTriggerType
{
	None,
	SwitchSuface,//切换平面
	Max
}

public class BaseTrigger : BaseItem 
{
	public EnumTriggerType TriggerType = EnumTriggerType.None;//触发器类型

	public bool IsEffective = true;//触发器是否能有效

	void Start()
	{
		
	}

	public override void Init ()
	{
		ItemType = EnumItemType.Trigger;
		ItemName = gameObject.name;

		base.Init ();
	}
}
