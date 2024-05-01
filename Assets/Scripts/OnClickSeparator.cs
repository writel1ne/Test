using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class OnClickDivider : MonoBehaviour
{
	[SerializeField] private Camera _camera;

	[SerializeField] private float _explosionForceMultiplier = 30f;
	[SerializeField] private float _scaleMultiplier = 0.5f;
	[SerializeField] private float _divideChanceDivisor = 2f;

	[SerializeField] private int[] _newCubesAmountRange = new int[2] { 2, 6 };
	[SerializeField] private int[] _positionOffsetRange = new int[2] { -5, 5 };
	[SerializeField] private int[] _startTorqueRange = new int[2] { -300, 300 };

	private Ray _ray;
	private RaycastHit _hit;
	private float _divideChancePercent = 100f;

	public void SetSeparateChance(float separateChance)
	{
		_divideChancePercent = separateChance;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_ray = _camera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(_ray, out _hit, Mathf.Infinity) && _hit.transform == transform)
			{
				if (_divideChancePercent >= Random.Range(0f, 100f))
				{
					int newCubesAmount = Random.Range(_newCubesAmountRange.Min(), _newCubesAmountRange.Max());

					SpawnNewCubes(newCubesAmount);
				}

				Destroy(gameObject);
			}
		}
	}

	private void SpawnNewCubes(int amount)
	{
		GameObject clone;

		for (int i = 0; i < amount; i++)
		{
			clone = Instantiate(gameObject);
			Rigidbody rb = clone.GetComponent<Rigidbody>();

			float newX = transform.position.x + Random.Range(_positionOffsetRange.Min(), _positionOffsetRange.Max());
			float newY = transform.position.y + Random.Range(0, _positionOffsetRange.Max());
			float newZ = transform.position.z + Random.Range(_positionOffsetRange.Min(), _positionOffsetRange.Max());
			Vector3 spawnPosition = new Vector3(newX, newY, newZ);

			Vector3 startTurque = new Vector3(Random.Range(_startTorqueRange.Min(), _startTorqueRange.Max()),
											Random.Range(_startTorqueRange.Min(), _startTorqueRange.Max()),
											Random.Range(_startTorqueRange.Min(), _startTorqueRange.Max()));

			Vector3 explosionForce = (spawnPosition - transform.position) * _explosionForceMultiplier;

			clone.transform.localScale = transform.localScale * _scaleMultiplier;
			clone.transform.position = spawnPosition;
			clone.transform.rotation = Quaternion.Euler(startTurque);


			rb.AddTorque(startTurque, ForceMode.Impulse);
			rb.AddForce(explosionForce, ForceMode.Impulse);
			clone.GetComponent<OnClickDivider>().SetSeparateChance(_divideChancePercent / _divideChanceDivisor);
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawRay(_ray.origin, _ray.direction * 100);
	}
}
