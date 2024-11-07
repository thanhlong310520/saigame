using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 50f;
    [SerializeField] protected float distance = 0f;
    [SerializeField] Transform mainCam;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCamera();
    }
    protected virtual void LoadCamera()
    {
        mainCam = Camera.main.transform;
    }
    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(transform.position,mainCam.position);
        if (distance > disLimit) return true;
        return false;
    }
}
