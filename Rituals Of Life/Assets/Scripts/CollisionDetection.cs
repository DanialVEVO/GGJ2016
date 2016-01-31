using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
		
	void OnTriggerEnter(Collider other) {
		if (!other.GetComponent<Rigidbody>()){
			return;
		}
		if (other.GetComponent<Rigidbody>().isKinematic == true){
			return;
		}
		var rigidBodies = this.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody R in rigidBodies){
			R.isKinematic = false;
		}
        GetComponent<Collider>().enabled = false;

    }
}
