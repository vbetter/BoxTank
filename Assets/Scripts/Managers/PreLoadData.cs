using UnityEngine;
using System.Collections;

public class PreLoadData : MonoBehaviour {


	// Use this for initialization
    void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}

    IEnumerator WaitPreLoad() 
    {
        yield return new WaitForSeconds(0.1f);

		PreLoadBase[] arr = gameObject.GetComponentsInChildren<PreLoadBase>();
        int count = arr.Length;
        for (int i = 0; i < count; ++i)
        {
			StartCoroutine(arr[i].LoadData());
        }
    }

    void Start()
    {
		StartCoroutine(WaitPreLoad());
    }
}
