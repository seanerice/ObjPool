using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmitter : MonoBehaviour {

	public GameObject Projectile;
	public float Impulse = 5.0f;
	public float MaxTime = .25f;

	private float timer = 0f;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {
		timer += Time.deltaTime;
		if (timer > MaxTime) {
			timer = 0f;
			Emit();
		}
	}

	public void Emit() {
		GameObject projectile = GameObject.Instantiate(Projectile);
		projectile.transform.position = transform.position + new Vector3(0, 1, 0);
		Rigidbody rb = projectile.GetComponent<Rigidbody>();
		rb.AddForce(gameObject.transform.forward * Impulse + new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)), ForceMode.Impulse);
	}

	public void SetMaxTime (float t) {
		MaxTime = t;
	}

	public void SetImpulse (float i) {
		Impulse = i;
	}
}
