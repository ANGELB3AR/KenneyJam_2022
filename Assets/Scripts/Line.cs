using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Scalar Scalar;

    Transform pointA;
    Transform pointB;

    void Start()
    {
        pointA.position = Scalar.minusSlot.transform.position;
        pointB.position = Scalar.plusSlot.transform.position;
        RenderLine();
    }

    void RenderLine()
    {
        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, pointB.position);
    }
}
