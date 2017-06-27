using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  方向 4个
/// </summary>
public enum EnumOrientation
{
	None,
	Left,
	Right,
	Top,
	Down
}

/// <summary>
/// 平面 6个
/// </summary>
public enum EnumSurface
{
	None,
	A,
	B,
	C,
	D,
	E,
	F
}

/// <summary>
/// 切面触发器
/// </summary>
public class Trigger_Scroll : BaseTrigger {

	public EnumSurface ToSurface = EnumSurface.None;//移动到哪个面

	public EnumOrientation OrientationType = EnumOrientation.None;//当前出发触发器的方向

	public Trigger_Scroll NearTrigger;

	void Start()
	{
		Init ();
	}

	protected override void OnMyTriggerEnter (Collider collider)
	{
		//Debug.Log ("OnMyTriggerEnter");

		BaseItem item = collider.GetComponent<BaseItem> ();

		if(item==null)
		{
			Debug.LogError ("item is null,Collider :"+ collider.name);
			return;
		}

		if(item.CurSurface != CurSurface)
		{
			Debug.LogError (string.Format("not same surface, {0} is {1} ,{2} is {3}",item.ItemName,item.CurSurface,ItemName,CurSurface));
			//item.Remove();
			return;
		}

		if(IsSameDirection(item.gameObject))
		{
			//必须对立方向，不同向
			Debug.Log (string.Format("{0} 碰到 {1}面 触发器 {2} 由于非面向无法触发",item.ItemName, item.CurSurface, transform.name));

			return;
		}
			

		if(!item.HasTriggerBuff(EnumTriggerType.SwitchSuface))
		{
			//设置不可被其他SwitchSuface触发器作用
			item.SetTriggerBuff (EnumTriggerType.SwitchSuface, true);

		}

		base.OnMyTriggerEnter (collider);
	}

	protected override void OnMyTriggerExit (Collider collider)
	{
		//Debug.Log ("OnMyTriggerExit");

		BaseItem item = collider.GetComponent<BaseItem> ();

		if (item.HasTriggerBuff (EnumTriggerType.SwitchSuface) && item.CurSurface == CurSurface) 
		{
			SwitchToSurfaceItem (ToSurface, item);
		}
		else
		{
			item.CurSurface = CurSurface;
		}

		item.SetTriggerBuff (EnumTriggerType.SwitchSuface, false);

		base.OnMyTriggerExit (collider);
	}

	public override bool CanTrigger (GameObject go)
	{

		return true;
	}

	bool IsSameDirection(GameObject go)
	{
		if(go!=null)
		{
			//计算当前物体的transform.forward向量与 (otherObj.transform.position – transform.position)的点积即可， 
			//大于0则面对，否则则背对着
/*/			float y = go.transform.localEulerAngles.y;
			if(y<90 && y>-90)
			{
				float value = Vector3.Dot(go.transform.forward,go.transform.position-transform.position);
				int intValue = (int)value;
				return value>0?false :true;
			}else 
			{
				float value = Vector3.Dot(go.transform.forward,transform.position);
				int intValue = (int)value;
				return value>0?true :false;
			}*/

			Vector3 pos = transform.position - go.transform.position;
			float value = Vector3.Dot(go.transform.forward,pos);
			int intValue = (int)value;

			Debug.Log (pos);
			Debug.Log (value);
			Debug.Log (go.transform.localEulerAngles.y);
			Debug.Log (go.transform.localRotation.y);

			return value>=0?false :true;
		}
		return false;
	}

	/// <summary>
	/// 换面
	/// </summary>
	/// <returns><c>true</c>, if surface item was toed, <c>false</c> otherwise.</returns>
	/// <param name="to">To.</param>
	/// <param name="go">Go.</param>
	bool SwitchToSurfaceItem(EnumSurface to,BaseItem item)
	{
		SurfaceItem surfaceItem = WorldMgr.Instance.GetSurfaceItem (to);

		Debug.Log (string.Format("{0} 从 {1}面 切换到 {2}面",item.ItemName, item.CurSurface, surfaceItem.CurSurface));

		item.CurSurface = to;

		surfaceItem.AddChild (item);

		if(NearTrigger!=null)
		{
			item.transform.localEulerAngles = NearTrigger.transform.localEulerAngles;
		}

		item.OnSwitchToSurfaceItem(to);

		return true;
	}
}
