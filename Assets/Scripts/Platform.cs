using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isScaling = false;
    
    Scalar Scalar;

    void Awake()
    {
        Scalar = FindObjectOfType<Scalar>();
    }

    public void ScaleUp()
    {
        StartCoroutine(ScaleBlockUp(Scalar.TimeToScale));
    }

    public void ScaleDown()
    {
        StartCoroutine(ScaleBlockDown(Scalar.TimeToScale));
    }

    IEnumerator ScaleBlockUp(float time)
    {
        isScaling = true;
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale + new Vector3(Scalar.ScaleAmount, Scalar.ScaleAmount, Scalar.ScaleAmount);

        float i = 0f;
        float rate = (1f / time);

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(originalScale, newScale, i);
            yield return null;
        }
        isScaling = false;
    }

    IEnumerator ScaleBlockDown(float time)
    {
        isScaling = true;
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale - new Vector3(Scalar.ScaleAmount, Scalar.ScaleAmount, Scalar.ScaleAmount);

        float i = 0f;
        float rate = (1f / time);

        while (i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(originalScale, newScale, i);
            yield return null;
        }
        isScaling = false;
    }

}
