using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float min=2f;
    public float max=3f;
    public float speed = 1.0f;
    void Start()
    {
        min=transform.position.y;
        max=transform.position.y+3;
    }

    void Update()
    {
         transform.position =new Vector3 (transform.position.x, Mathf.PingPong(Time.time*2,max-min)+min, transform.position.z);
    }
}
