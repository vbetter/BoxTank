using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnumItemType
{
	None,
	Actor,		//角色
	Trigger,	//触发器
	Shell,		//子弹
	Prop,		//关卡道具
	FixedItem,	//固定道具，不可移动
	Max
}

public class BaseItem : MonoBehaviour {

	public EnumSurface CurSurface = EnumSurface.None;//当前属于哪个面

	public EnumItemType ItemType = EnumItemType.None;

	bool[] TriggerBuffs = new bool[(int)EnumTriggerType.Max];//对象上作用的触发效果

	public Vector3  BaseAngle = Vector3.zero;//记录初始角度，转角时重设

	public string ItemName="";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void Init()
	{
		BaseAngle = transform.localEulerAngles;
	}

	/// <summary>
	/// 判断是否当前处于buff态中
	/// </summary>
	/// <returns><c>true</c> if this instance has trigger buff the specified triggerType; otherwise, <c>false</c>.</returns>
	/// <param name="triggerType">Trigger type.</param>
	public virtual bool HasTriggerBuff(EnumTriggerType triggerType)
	{
		return TriggerBuffs[(int)triggerType];
	}

	/// <summary>
	/// 清楚身上的触发效果
	/// </summary>
	public void ClearTriggerBuffs()
	{
		for (int i = 0; i < TriggerBuffs.Length; i++) 
		{
			TriggerBuffs [i] = false;
		}
	}

	/// <summary>
	/// 设置对象身上的触发效果
	/// </summary>
	/// <param name="state">State.</param>
	/// <param name="value">If set to <c>true</c> value.</param>
	public void SetTriggerBuff(EnumTriggerType state,bool value)
	{
		//Debug.Log ("state:" + value);

		TriggerBuffs [(int)state] = value;
	}

	void OnTriggerEnter(Collider collider)
	{
		OnMyTriggerEnter (collider);
	}

	void OnTriggerExit(Collider collider)
	{
		OnMyTriggerExit (collider);
	}

	protected virtual void OnMyTriggerEnter(Collider collider)
	{

	}

	protected virtual void OnMyTriggerExit(Collider collider)
	{

	}

	public virtual bool CanTrigger(GameObject go)
	{
		return false;
	}

	public virtual void Remove()
	{
		Debug.Log (string.Format ("{0} is destroy", gameObject.name));

		Destroy (gameObject);
	}

	/// <summary>
	/// 对象换面后的回调
	/// </summary>
	/// <param name="to">To.</param>
	public virtual void OnSwitchToSurfaceItem(EnumSurface to)
	{
		
	}
}
