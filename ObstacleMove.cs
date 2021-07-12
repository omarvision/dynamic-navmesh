using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float MoveSpeed = 1.0f;

    private void Update()
    {
        this.transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
    }
}