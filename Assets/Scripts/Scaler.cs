using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
	[SerializeField, Range(0, 1f)] private float _scaleOffset = 0;

	private void FixedUpdate()
	{
		transform.localScale += Vector3.one * _scaleOffset * Time.fixedDeltaTime;
	}
}
