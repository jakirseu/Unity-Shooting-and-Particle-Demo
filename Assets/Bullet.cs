using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   
    public float speed = 3;

    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}