using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Scalar Scalar;

    Transform pointA;
    Transform pointB;

    private void OnEnable()
    {
        lineRenderer.enabled = true;
    }

    public void RenderLine()
    {
        pointA.position = Scalar.minusSlot.transform.position;
        pointB.position = Scalar.plusSlot.transform.position;

        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, pointB.position);
    }

    private void OnDisable()
    {
        lineRenderer.enabled = false;
    }
}
