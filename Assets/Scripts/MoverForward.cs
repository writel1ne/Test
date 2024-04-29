using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverForward : MonoBehaviour
{
	[SerializeField, Range(0, 10)] private float _speed = 0.1f;

	private void FixedUpdate()
	{
		transform.Translate(new Vector3(_speed, 0, 0) * Time.fixedDeltaTime);
	}
}
