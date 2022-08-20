using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalar : MonoBehaviour
{
    [field: SerializeField] public float ScaleAmount { get; private set; } = 0.5f;
    [field: SerializeField] public float TimeToScale { get; private set; } = 1f;

    public event Action OnDisableTether;

    public Platform minusSlot = null;
    public Platform plusSlot = null;

    void Update()
    {
        if (minusSlot != null && plusSlot != null)
        {
            if (minusSlot == plusSlot)
            {
                DisableTether();
                return;
            }

            ScalePlatforms();

            if (minusSlot.isScaling || plusSlot.isScaling)
            {
                DisableTether();
            }
        }
    }

    void ScalePlatforms()
    {
        minusSlot.ScaleDown();
        plusSlot.ScaleUp();
    }

    void DisableTether()
    {
        minusSlot = null;
        plusSlot = null;
        OnDisableTether?.Invoke();
    }
}
