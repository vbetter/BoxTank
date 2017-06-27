using UnityEngine;
using System.Collections;
using System.IO;

public class PreLoadBase : MonoBehaviour
{
    protected float m_dProgress;
    [HideInInspector]
    public string m_strProgressingTips;


    public virtual IEnumerator LoadData()
    {
        m_dProgress = 0f;
        yield return null;
        m_dProgress = 1f;
    }

	protected string GetFullSaveFilePath(string strPath)
	{
		string fileName = Application.persistentDataPath + Path.DirectorySeparatorChar + strPath;
		return fileName;
	}
}
