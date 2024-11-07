using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ShipMovement : MonoBehaviour
{
    public Vector3 targetPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        GetTargetPos();
        LookAtTarget();
        Moving();
    }
    void GetTargetPos()
    {
        targetPos = InputManager.Instance.GetMousePos();
        targetPos.z = 0;
    }

    void LookAtTarget()
    {
        if (targetPos == transform.position) return;
        var diff = targetPos - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z - 90);
    }
    void Moving()
    {
        var newPos = Vector3.Lerp(transform.parent.position, targetPos, speed);
        transform.parent.position = newPos;   

    }
}
