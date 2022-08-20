using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] bool isPlusDart;
    [SerializeField] Transform readyPosition;
    [SerializeField] float firePower = 10f;
    [SerializeField] float defaultFireDistance = 100f;

    Rigidbody rb;
    Collider myCollider;
    Scalar Scalar;
    Camera mainCamera;
    Platform currentPlatform = null;
    bool hasFired;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
        Scalar = FindObjectOfType<Scalar>();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        Scalar.OnDisableTether += ResetDart;
    }

    private void Start()
    {
        ResetDart();
    }

    private void LateUpdate()
    {
        if (hasFired) { return; }
        ResetDart();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Platform>(out Platform platform))
        {
            rb.isKinematic = true;
            rb.useGravity = false;

            currentPlatform = platform;
            currentPlatform.OnFinishedScaling += ResetDart;

            if (isPlusDart)
            {
                Scalar.plusSlot = platform;

                if (!Scalar.isActiveAndEnabled)
                {
                    Scalar.enabled = true;
                }
            }
            else if (!isPlusDart)
            {
                Scalar.minusSlot = platform;

                if (!Scalar.isActiveAndEnabled)
                {
                    Scalar.enabled = true;
                }
            }
        }
        else
        {
            ResetDart();
        }
    }

    public void ResetDart()
    {
        transform.position = readyPosition.position;
        transform.rotation = readyPosition.rotation;
        myCollider.enabled = false;
        hasFired = false;
    }

    public void LaunchDart()
    {
        hasFired = true;
        myCollider.enabled = true;

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

        rb.useGravity = true;
        rb.isKinematic = false;
        rb.velocity = (targetPoint - transform.position).normalized * firePower;
    }

    private void OnDisable()
    {
        //currentPlatform.OnFinishedScaling -= ResetDart;
        Scalar.OnDisableTether -= ResetDart;
    }
}
