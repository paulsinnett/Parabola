using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
	public Rigidbody projectilePrefab;
	public Transform vertex;
	public Transform target;
	public float range;
	public float height;

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			Rigidbody projectile = Instantiate(projectilePrefab);
			projectile.transform.position = transform.position;
			float angle = FindLaunchAngle(range, height);
			Quaternion elevation = Quaternion.Euler(0.0f, 0.0f, angle * Mathf.Rad2Deg);
			float velocity = FindLaunchVelocity(angle, range);
			projectile.AddForce(elevation * Vector3.right * velocity, ForceMode.VelocityChange);
		}
		if (vertex != null)
		{
			vertex.transform.position = transform.position + new Vector3(range / 2.0f, height, 0.0f);
		}

		if (target != null)
		{
			target.transform.position = transform.position + new Vector3(range, 0.0f, 0.0f);
		}
	}

	float FindLaunchAngle(float range, float height)
	{
		// if θ = angle, h = height, and R = range:
		// h = (R·tanθ)÷4
		// 4h = R·tanθ
		// 4h÷R = tanθ
		// θ = tan⁻¹(4h÷R)
		return Mathf.Atan(4.0f * height / range);
	}

	float FindLaunchVelocity(float angle, float range)
	{
		// if R = range, θ = angle, v= velocity, and g = gravity
		// R = v²sin(2θ)÷g
		// R·g = v²sin(2θ)
		// (R·g)÷sin(2θ) = v²
		// √((R·g)÷sin(2θ)) = v
		return Mathf.Sqrt((range*Physics.gravity.magnitude)/Mathf.Sin(2.0f * angle));
	}
}
