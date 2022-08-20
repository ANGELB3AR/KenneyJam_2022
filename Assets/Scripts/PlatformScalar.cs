using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScalar : MonoBehaviour
{
    [field: SerializeField] public float ScaleAmount { get; private set; } = 0.5f;
    [SerializeField] float timeToScale = 1f;

    [SerializeField] Platform minusSlot = null;
    [SerializeField] Platform plusSlot = null;

    private void OnEnable()
    {
        minusSlot.OnFinishedScaling += DisableTether;
        plusSlot.OnFinishedScaling += DisableTether;
    }

    void Update()
    {
        if (minusSlot != null && plusSlot != null)
        {
            ScalePlatforms();
        }
    }

    void ScalePlatforms()
    {
        StartCoroutine(minusSlot.ScaleBlockDown(timeToScale));
        StartCoroutine(plusSlot.ScaleBlockUp(timeToScale));
    }

    void DisableTether()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        minusSlot.OnFinishedScaling -= DisableTether;
        plusSlot.OnFinishedScaling -= DisableTether;
    }
}
