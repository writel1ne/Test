using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _speed = 0.1f;

    void FixedUpdate()
    {
        gameObject.transform.Translate(_speed, 0, 0);
    }
}
