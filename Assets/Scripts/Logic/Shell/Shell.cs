using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MoveItem {

	public float m_Speed = 12f;//移动速度

	public bool Stop = false;

	public bool IsAttackSelf = false;//能否攻击到自己

	public int SelfActorID = 0;//谁发射的子弹

	// Use this for initialization
	void Start () {
		Init ();
	}

	public override void Init ()
	{
		ItemType = EnumItemType.Shell;
		ItemName = name;
		base.Init ();
	}

	protected override void OnMyTriggerEnter (Collider collider)
	{
		BaseItem targetItem = collider.GetComponent<BaseItem> ();

		if(targetItem!=null)
		{
			if(targetItem.ItemType != EnumItemType.Trigger)
			Debug.Log (string.Format ("{0} is Hit : {1}", gameObject.name,collider.name));

			switch (targetItem.ItemType) 
			{
			case EnumItemType.Actor:
				{
					Player player = targetItem as Player;

					if(SelfActorID == player.ActorID && !IsAttackSelf)
					{
						//在当前面不允许攻击到自己，避免移动速度过快，炮弹生成后就打到自己了
						return ;
					}

					SurfaceItem surfaceItem = WorldMgr.Instance.GetSurfaceItem (player.CurSurface);

					Transform effect = EffectMgr.Instance.CreateEffect (eEffectType.explosion_stylized_medium_template, surfaceItem.transform, 2f);
					if(effect!=null)
					{
						effect.position = player.CenterPos.position;
					}
					Remove ();
				}
				break;
			case EnumItemType.FixedItem:
				{
					Transform effect = EffectMgr.Instance.CreateEffect (eEffectType.explosion_stylized_large_template,null,2f);
					if(effect!=null)
					{
						effect.position = transform.position;
					}
					//移除子弹
					Remove ();
					//移除目标
					targetItem.Remove ();
				}
				break;
			case EnumItemType.Shell:
				Remove ();
				break;
			case EnumItemType.Trigger:
				break;
			default:
				Debug.LogError ("有bug,ItemType未知," +targetItem.ItemType);
				//未知情况销毁自己
				//Remove ();
				break;
			}
		}

		base.OnMyTriggerEnter (collider);
	}
		
	void Update()
	{
		Move ();
	}

	void Move()
	{
		if(!Stop)
		{
			//Vector3 movement = transform.forward * m_Speed;
			//transform.localPosition += movement;
		}
			
		transform.Translate (Vector3.forward.normalized * Time.deltaTime * m_Speed,Space.Self);

	}

	public override void OnSwitchToSurfaceItem (EnumSurface to)
	{
		if(IsAttackSelf) IsAttackSelf = false;//切面后，就可以攻击到自己了
			
		base.OnSwitchToSurfaceItem (to);
	}
}
