using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledProjectile : MonoBehaviour {
	public float MaxTime = 10f;
	public bool Queued = false;

	private float timer = 0f;
	private Rigidbody rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (rb.IsSleeping()) {
			ProjectilePool.Release(gameObject);
		}

		timer += Time.deltaTime;
		if (timer > MaxTime) {
			timer = 0f;
			//ProjectilePool.Release(gameObject);
		}
	}

	public void SetTime (float t) {
		MaxTime = t;
	}

	public void SetQueued(bool q) {
		Queued = q;
	}
}
