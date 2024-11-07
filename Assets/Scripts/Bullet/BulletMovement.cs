using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 distance = transform.parent.up;
        transform.parent.position = new Vector3(transform.parent.position.x + distance.x * speed, transform.parent.position.y + distance.y * speed, transform.parent.position.z + distance.z * speed);
    }
}
