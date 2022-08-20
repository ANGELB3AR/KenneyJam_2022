using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] bool isPlusDart;

    Scalar Scalar;

    void Awake()
    {
        Scalar = FindObjectOfType<Scalar>();
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
        }
    }
}
