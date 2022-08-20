using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] bool isPlusDart;
    [SerializeField] Transform readyPosition;

    Scalar Scalar;
    bool hasFired;

    void Awake()
    {
        Scalar = FindObjectOfType<Scalar>();
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
}
