using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Enum_Players
{
	None,
	p1,
	p2
}

public class Player : MoveItem {

	public Enum_Players EnumPlayers = Enum_Players.None;

	private string m_MovementAxisName;          // The name of the input axis for moving forward and back.
	private string m_TurnAxisName;              // The name of the input axis for turning.
	private string m_FireButton;                // The input axis that is used for launching shells.

	private float m_MovementInputValue;         // The current value of the movement input.
	private float m_TurnInputValue;             // The current value of the turn input.

	CharacterController m_CharacterController;

	public float m_Speed = 12f;                 // How fast the tank moves forward and back.
	public float m_TurnSpeed = 180f;            // How fast the tank turns in degrees per second.

	const string ShellPath = "Shell/Shell";

	public Transform ShootPos;

	public Transform CenterPos;

	public int ActorID =0;

	// Use this for initialization
	void Start () {
		
	}


	public void Init(Enum_Players players)
	{
		if(m_CharacterController==null)
		m_CharacterController = GetComponent<CharacterController> ();

		EnumPlayers = players;
		gameObject.name = players.ToString ();
		ItemName = players.ToString ();
		ItemType = EnumItemType.Actor;

		switch (players) 
		{
		case Enum_Players.p1:
			m_MovementAxisName = "Vertical1";
			m_TurnAxisName = "Horizontal1";
			m_FireButton ="Fire1";
			break;
		case Enum_Players.p2:
			m_MovementAxisName = "Vertical2";
			m_TurnAxisName = "Horizontal2";
			m_FireButton ="Fire2";
			break;
		default:
			break;
		}
	}

	void Update()
	{
		if(!string.IsNullOrEmpty(m_MovementAxisName))
		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
		
		if(!string.IsNullOrEmpty(m_TurnAxisName))
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);

		if (!string.IsNullOrEmpty(m_FireButton) && Input.GetButtonDown (m_FireButton))
		{
			Fire ();
		}

		Move ();
	}

	private void FixedUpdate ()
	{
		// Adjust the rigidbodies position and orientation in FixedUpdate.
		Move ();
		Turn ();
	}

	private void Move ()
	{
		if(m_CharacterController!=null)
		{
			
			Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;

			m_CharacterController.Move (movement);

			if(m_MovementInputValue<0)
			{
				Vector3 myPos = transform.localPosition;
				if(myPos.x<-50)
				{
					transform.localPosition = new Vector3 (-50, myPos.y, myPos.z);
				}

				if(myPos.x>50)
				{
					transform.localPosition= new Vector3  (50,myPos.y, myPos.z);
				}

				if(myPos.z<-50)
				{
					transform.localPosition= new Vector3  (myPos.x,myPos.y, -50);
				}

				if(myPos.z>50)
				{
					transform.localPosition= new Vector3  (myPos.x,myPos.y, 50);
				}
			}
		}
	}

	private void Turn ()
	{
		// Determine the number of degrees to be turned based on the input, speed and time between frames.
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		transform.Rotate (0f, turn, 0f);
	}

	void Fire ()
	{
		GameObject target = Instantiate (Resources.Load (ShellPath)) as GameObject;
		Shell shell = target.GetComponent<Shell> ();
		shell.CurSurface = CurSurface;
		shell.SelfActorID = ActorID;
		shell.transform.parent = WorldMgr.Instance.GetSurfaceItem (shell.CurSurface).transform;

		shell.transform.position = ShootPos.position;
		shell.transform.localRotation = transform.localRotation;
		shell.transform.forward = transform.forward;
	}
}
