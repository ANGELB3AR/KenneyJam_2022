using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] float speed = 1f;

    Scalar Scalar;

    private void Awake()
    {
        Scalar = FindObjectOfType<Scalar>();
    }

    void OnEnable()
    {
        pointA.transform.position = Scalar.minusSlot.transform.position;
        pointB.transform.position = Scalar.plusSlot.transform.position;
        var emission = particles.emission;
        emission.enabled = true;
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
        particles.transform.position = Vector3.MoveTowards(pointA.transform.position, pointB.transform.position, speed * Time.deltaTime);
    }
}
