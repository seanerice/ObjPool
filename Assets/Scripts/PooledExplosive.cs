using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledExplosive : MonoBehaviour {
	public GameObject Model;
	public float Impulse = 5f;
	public int Size = 100;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftControl)) {
			Explode();	
		}
	}

	public void Explode () {
		for (int i = 0; i < Size; i++) {
			GameObject projectile = ProjectilePool.Get();
			projectile.SetActive(true);
			projectile.transform.position = transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.AddForce(Impulse * new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), ForceMode.Impulse);
		}
	}
}
