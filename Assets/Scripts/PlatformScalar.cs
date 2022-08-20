using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScalar : MonoBehaviour
{
    [field: SerializeField] public float ScaleAmount { get; private set; } = 0.5f;
    [field: SerializeField] public float TimeToScale { get; private set; } = 1f;

    [SerializeField] Platform minusSlot = null;
    [SerializeField] Platform plusSlot = null;

    private void Start()
    {
        ScalePlatforms();
    }

    void Update()
    {
        //if (minusSlot != null && plusSlot != null)
        //{
        //    Debug.Log("Time to scale some blocks!");
        //    ScalePlatforms();
        //}
    }

    void ScalePlatforms()
    {
        //if (minusSlot == null || plusSlot == null) { return; }

        //Vector3 minusSlotScale = minusSlot.transform.localScale;
        //Vector3 minusOriginalScale = minusSlotScale;
        //Vector3 minusNewScale = minusSlotScale - new Vector3(scaleAmount, scaleAmount, scaleAmount);

        //minusSlotScale = Vector3.Lerp(minusOriginalScale, minusNewScale, timeToScale * Time.deltaTime);

        Debug.Log("Blocks should be scaled");
        //minusSlot = null;
        //plusSlot = null;
    }
}
