using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action OnFinishedScaling;

    [SerializeField] float minimumScale = 0.5f;

    [HideInInspector] public bool isScaling = false;
    [HideInInspector] public bool canScaleDown = true;

    Scalar Scalar;

    void Awake()
    {
        Scalar = FindObjectOfType<Scalar>();
    }

    private void Update()
    {
        if (transform.localScale.x == minimumScale)
        {
            canScaleDown = false;
        }
        else
        {
            canScaleDown = true;
        }
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
        OnFinishedScaling?.Invoke();
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
        OnFinishedScaling?.Invoke();
    }
}
