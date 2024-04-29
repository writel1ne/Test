using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
	[SerializeField, Range(0, 0.1f)] private float _scaleOffset = 0;

    void FixedUpdate()
    {
		gameObject.transform.localScale += new Vector3(_scaleOffset, _scaleOffset, _scaleOffset);
    }
}
