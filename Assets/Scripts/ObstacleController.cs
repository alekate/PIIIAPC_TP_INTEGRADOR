using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ObstacleController : MonoBehaviour
{
    
    public float speed = 3f;

    public float initialXPosition = 25f;

    void Start()
    {
    }
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = initialXPosition + Mathf.Sin(Time.time * speed);
        transform.position = pos;

    }
}
