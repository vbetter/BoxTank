using UnityEngine;

public class CameraControl : MonoBehaviour
{
	[SerializeField]
    Camera m_Camera;                        
    
	Player _player= null;

    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }


	public void Init(Player item)
	{
		_player = item;

		if(_player!=null)
		{
			switch (_player.EnumPlayers) {
			case Enum_Players.p1:
				m_Camera.rect = new Rect (0, 0, 0.5f, 1);
				break;
			case Enum_Players.p2:
				m_Camera.rect = new Rect (0.5f, 0, 0.5f, 1);
				break;
			default:
				break;
			}
		}
	}



}