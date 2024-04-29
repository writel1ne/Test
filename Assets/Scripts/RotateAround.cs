using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
	[SerializeField, Range(0, 10)] private float _rotationOffset = 0.1f;

    void FixedUpdate()
    {
        gameObject.transform.Rotate(0, _rotationOffset, 0);
    }
}
