using UnityEngine;
using System.Collections;

public class ISingleton<T> : PreLoadBase where T : PreLoadBase
{
    private static GameObject m_Container = null;  
	private static T instance;
	public static T Instance
	{
		get
		{
            if (!instance)
            {
                instance = GameObject.FindObjectOfType<T>();  
            }
            if (!instance)
            {
				#if Profile
				Profiler.BeginSample("Singleton.NewGameObject");
				#endif
                GameObject obj = new GameObject(typeof(T).ToString());
                instance = obj.AddComponent<T>();
				#if Profile
				Profiler.EndSample();
				#endif
            }
			return instance;
		}
	}



	public static T Initialize() { return Instance; }
	public static bool IsCreated() { return (instance != null); }
}
