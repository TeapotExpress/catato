using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawEmitter : MonoBehaviour
{
    CatMovement parentCatMovement;
    ParticleSystem myParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        parentCatMovement = GetComponentInParent<CatMovement>();
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        // sets direction of new particles to parent's movement direction
        var main = myParticleSystem.main;
        Vector3 rotatedDirection = transform.rotation * parentCatMovement.direction;
        main.startRotation = -Mathf.Atan2(rotatedDirection.z, rotatedDirection.x) - (90f * Mathf.Deg2Rad);
    }
}