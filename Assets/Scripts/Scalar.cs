using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalar : MonoBehaviour
{
    [field: SerializeField] public float ScaleAmount { get; private set; } = 0.5f;
    [field: SerializeField] public float TimeToScale { get; private set; } = 1f;

    public Platform minusSlot = null;
    public Platform plusSlot = null;

    void Update()
    {
        if (minusSlot != null && plusSlot != null)
        {
            EnableTether();

            if (minusSlot.isScaling || plusSlot.isScaling)
            {
                DisableTether();
            }
        }
    }

    void ScalePlatforms()
    {
        Debug.Log("Scale platforms");
        minusSlot.ScaleDown();
        plusSlot.ScaleUp();
    }

    void EnableTether()
    {
        Debug.Log("Tether enabled");
        ScalePlatforms();
    }

    void DisableTether()
    {
        Debug.Log("Tether disabled");
        minusSlot = null;
        plusSlot = null;
        gameObject.SetActive(false);
    }
}
