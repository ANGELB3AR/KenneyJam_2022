using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action OnFinishedScaling;
    
    PlatformScalar scalar;

    void Awake()
    {
        scalar = FindObjectOfType<PlatformScalar>();
    }

    public IEnumerator ScaleBlockUp(float time)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale + new Vector3(scalar.ScaleAmount, scalar.ScaleAmount, scalar.ScaleAmount);

        float i = 0f;
        float rate = (1f / time);

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(originalScale, newScale, i);
            yield return null;
        }
        OnFinishedScaling?.Invoke();
    }

    public IEnumerator ScaleBlockDown(float time)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale - new Vector3(scalar.ScaleAmount, scalar.ScaleAmount, scalar.ScaleAmount);

        float i = 0f;
        float rate = (1f / time);

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(originalScale, newScale, i);
            yield return null;
        }
        OnFinishedScaling?.Invoke();
    }

}
