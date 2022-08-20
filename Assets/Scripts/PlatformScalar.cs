using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScalar : MonoBehaviour
{
    [SerializeField] float scaleAmount = 0.5f;
    [SerializeField] float timeToScale = 1f;

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
        if (minusSlot == null || plusSlot == null) { return; }

        Vector3 minusSlotScale = minusSlot.transform.localScale;
        Vector3 plusSlotScale = plusSlot.transform.localScale;
        Vector3 minusOriginalScale = minusSlotScale;
        Vector3 minusNewScale = new Vector3(minusSlotScale.x -= scaleAmount, minusSlotScale.y -= scaleAmount, minusSlotScale.z -= scaleAmount);

        minusSlotScale = Vector3.Lerp(minusOriginalScale, minusNewScale, timeToScale * Time.deltaTime);

        //minusSlotScale = new Vector3(minusSlotScale.x -= scaleAmount, minusSlotScale.y -= scaleAmount, minusSlotScale.z -= scaleAmount);
        //plusSlotScale = new Vector3(plusSlotScale.x += scaleAmount, plusSlotScale.y += scaleAmount, plusSlotScale.z += scaleAmount);
        Debug.Log("Blocks should be scaled");
        //minusSlot = null;
        //plusSlot = null;
    }
}
