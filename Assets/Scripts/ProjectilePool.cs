using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour {
	private static GameObject Model;
	private static List<GameObject> InUse;
	private static List<GameObject> Avail;

	public int Number = 250;

	void Start() {
		Model = (GameObject)Resources.Load("Prefabs/PooledProjectile");
		InitializePool(Number, Model);
	}

	private static void InitializePool(int num, GameObject model) {
		InUse = new List<GameObject>();
		Avail = new List<GameObject>();
		for (int i = 0; i < num; i++) {
			GameObject go = GameObject.Instantiate(model);
			go.SetActive(false);
			Avail.Add(go);
		}
	}

	public static GameObject Get() {
		lock(Avail) {
			if (Avail.Count > 0) {
				// Give free object
				GameObject go = Avail[0];
				Avail.RemoveAt(0);
				InUse.Add(go);
				return go;
			} else {
				// Give an object which is already in use
				GameObject go = InUse[0];
				InUse.RemoveAt(0);
				go.SetActive(false);
				InUse.Add(go);
				return go;
			}
		}
	}

	public static void Release(GameObject go) {
		if (InUse.Contains(go)) {
			go.SetActive(false);
			InUse.Remove(go);
			Avail.Add(go);
		}
	}

	public static int Available() {
		return Avail.Count;
	}

	public static int NumInUse() {
		return InUse.Count;
	}
}
