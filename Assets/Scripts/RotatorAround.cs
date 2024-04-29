using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorAround : MonoBehaviour
{
	[SerializeField, Range(0, 100)] private float _rotationOffset = 0.1f;

	private void FixedUpdate()
	{
		transform.Rotate(new Vector3(0, _rotationOffset, 0) * Time.fixedDeltaTime);
	}
}
