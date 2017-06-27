using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedItem : BaseItem 
{
	public bool CanBroke = false;//是否能破坏

	public override void Remove ()
	{
		if(CanBroke)
		base.Remove ();
	}

}
