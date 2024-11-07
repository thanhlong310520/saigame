using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float timeDelayShooting = 1f;
    float shootTime = 0;
    private void Start()
    {
        shootTime = timeDelayShooting;
    }
    private void FixedUpdate()
    {
        GetIsShooting();
        Shooting();
    }
    protected virtual void Shooting()
    {
        shootTime += Time.fixedDeltaTime;
        if (!isShooting) return;
        if (shootTime < timeDelayShooting) return;
        shootTime = 0;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,spawnPos,rotation);
        newBullet.gameObject.SetActive(true);
    }
    void GetIsShooting()
    {
        isShooting = InputManager.Instance.GetIsTouch();
    }

}
