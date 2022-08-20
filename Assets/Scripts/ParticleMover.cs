using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 1f;
    [SerializeField] Transform particleHolder;

    Scalar Scalar;
    float distance;

    private void Awake()
    {
        Scalar = FindObjectOfType<Scalar>();
    }

    void OnEnable()
    {
        pointA.position = Scalar.minusSlot.transform.position;
        pointB.position = Scalar.plusSlot.transform.position;
        var emission = particles.emission;
        emission.enabled = true;
        distance = Vector3.Distance(pointA.position, pointB.position);
    }

    void OnDisable()
    {
        var emission = particles.emission;
        emission.enabled = false;
    }

    void Update()
    {
        MoveParticles();
    }

    void MoveParticles()
    {
        Debug.Log("Particles should be moving now");
        particleHolder.position = Vector3.MoveTowards(pointA.transform.position, pointB.transform.position, (speed / distance * Time.deltaTime));
    }
}
