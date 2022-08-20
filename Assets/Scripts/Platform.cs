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
        ScaleBlockDown();
    }

    public void ScaleBlockDown()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale - new Vector3(scalar.ScaleAmount, scalar.ScaleAmount, scalar.ScaleAmount);

        transform.localScale = Vector3.Lerp(originalScale, newScale, scalar.TimeToScale * Time.deltaTime);
    }

    public void ScaleBlockUp()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 newScale = originalScale + new Vector3(scalar.ScaleAmount, scalar.ScaleAmount, scalar.ScaleAmount);

        transform.localScale = Vector3.Lerp(originalScale, newScale, scalar.TimeToScale * Time.deltaTime);
    }

}
