using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
	public Rigidbody projectilePrefab;
	public float angle;
	public float force;

	void OnEnable()
	{
		Rigidbody projectile = Instantiate(projectilePrefab, transform);
		Quaternion elevation = Quaternion.Euler(0.0f, 0.0f, angle);
		projectile.AddForce(elevation * Vector3.right * force, ForceMode.Impulse);
		enabled = false;
	}
}
