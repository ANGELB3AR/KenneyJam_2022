using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    [SerializeField] Image reticle;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<Platform>())
            {
                TurnReticleRed();
            }
            else
            {
                TurnReticleWhite();
            }
        }
    }

    private void TurnReticleWhite()
    {
        reticle.color = Color.white;
    }

    private void TurnReticleRed()
    {
        reticle.color = Color.red;
    }
}
