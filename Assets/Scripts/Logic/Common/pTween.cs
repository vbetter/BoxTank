using UnityEngine;
using System;
using System.Collections;

public class pTween {
	
	// Peter's Tweening Library.

    public static IEnumerator To(float duration, float startValue, float endValue, Action<float> callback, Action endCallback = null, bool IgnoreTimeScale = false)
	{
		float start = IgnoreTimeScale ? RealTime.time : Time.time;
		float end = start + duration;
        //float durationInv = 1f / duration;
        //float startMulDurationInv = start / duration;

        for (float t = start; t < end; t += (IgnoreTimeScale ? RealTime.deltaTime : Time.deltaTime))
		{
            float rate = (t - start) / duration;    
            callback(Mathf.Lerp(startValue, endValue, rate));
			yield return null;
		}
		callback(endValue);

        if (endCallback != null) 
        {
            endCallback();
        }
	}

    public static IEnumerator To(float duration, Vector3 startValue, Vector3 endValue, Action<Vector3> callback, Action endCallback = null, bool IgnoreTimeScale = false)
    {
        float start = Time.time;
        float end = start + duration;
        //float durationInv = 1f / duration;
        //float startMulDurationInv = start / duration;

        for (float t = start; t < end; t += (IgnoreTimeScale ? RealTime.deltaTime : Time.deltaTime))
        {
            float rate = (t - start) / duration;
            callback(Vector3.Lerp(startValue, endValue, rate));
            yield return null;
        }
        callback(endValue);

        if (endCallback != null)
        {
            endCallback();
        }
    }

    public static IEnumerator To(float duration, Action<float> callback, Action endCallback = null, bool IgnoreTimeScale = false)
	{
        return To(duration, 0f, 1f, callback, endCallback, IgnoreTimeScale);
	}

	public static float Bell(float x)
	{
		return Mathf.SmoothStep(0f, 1f, 1f - Mathf.Abs(x - 0.5f) / 0.5f);
	}
	
}


