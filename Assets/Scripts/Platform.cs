using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PlatformScalar scalar;

    void Awake()
    {
        scalar = FindObjectOfType<PlatformScalar>();
    }

    void Start()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale + new Vector3(scalar.ScaleAmount, scalar.ScaleAmount, scalar.ScaleAmount);
        StartCoroutine(ScaleBlock(originalScale, newScale, scalar.TimeToScale));
    }

    public IEnumerator ScaleBlock(Vector3 originalScale, Vector3 newScale, float time)
    {
        float i = 0f;
        float rate = (1f / time);

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(originalScale, newScale, i);
            yield return null;
        }
    }
}
