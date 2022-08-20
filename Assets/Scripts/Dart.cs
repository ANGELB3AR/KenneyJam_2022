using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] bool isPlusDart;
    [SerializeField] Transform readyPosition;
    [SerializeField] float firePower = 10f;
    [SerializeField] float defaultFireDistance = 100f;

    Scalar Scalar;
    Camera mainCamera;
    bool hasFired;

    void Awake()
    {
        Scalar = FindObjectOfType<Scalar>();
        mainCamera = Camera.main;
    }

    private void Start()
    {
        ResetDart();
    }

    private void Update()
    {
        if (hasFired) { return; }
        ResetDart();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Platform>(out Platform platform))
        {
            if (isPlusDart)
            {
                Scalar.plusSlot = platform;
            }
            else if (!isPlusDart)
            {
                Scalar.minusSlot = platform;
            }
            hasFired = true;
        }
        else
        {
            ResetDart();
        }
    }

    void ResetDart()
    {
        transform.position = readyPosition.position;
        transform.rotation = readyPosition.rotation;
        hasFired = false;
    }

    public void LaunchDart()
    {
        hasFired = true;

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(defaultFireDistance);
        }

        GetComponent<Rigidbody>().velocity = (targetPoint - transform.position).normalized * firePower;
    }
}
