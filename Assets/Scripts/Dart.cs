using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour
{
    Scalar scalar;

    void Awake()
    {
        scalar = FindObjectOfType<Scalar>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Platform>(out Platform platform))
        {
            Debug.Log("Hit the block");
        }
    }
}
