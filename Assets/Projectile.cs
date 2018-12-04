using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	Rigidbody physics;

	void Awake()
	{
		physics = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision collision)
	{
		physics.AddForce(-physics.velocity, ForceMode.VelocityChange);
	}
}
