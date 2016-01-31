using UnityEngine;
using System.Collections;

public class CollisionDetection : MonoBehaviour {
    GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");

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
        player.GetComponent<ScoreScript>().objectsDestroyed++;
        var rigidBodies = this.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody R in rigidBodies){
			R.isKinematic = false;
		}
        GetComponent<Collider>().enabled = false;
        if(this.gameObject.tag=="Garbage")
        {
            print("Garbage");
            player.GetComponent<ScoreScript>().totalDamage += 100;
            GetComponentInParent<AudioSource>().Play();
        }
        if (this.gameObject.tag == "Bench")
        {
            print("Bench");
            player.GetComponent<ScoreScript>().totalDamage += 250;
            GetComponentInParent<AudioSource>().Play();
        }
        if (this.gameObject.tag == "Shallot")
        {
            print("Shallot");
            player.GetComponent<ScoreScript>().totalDamage += 3250;
            GetComponentInParent<AudioSource>().Play();
        }
        if (this.gameObject.tag == "Showcase")
        {
            print("Showcase");
            player.GetComponent<ScoreScript>().totalDamage += 11500;
            GetComponentInParent<AudioSource>().Play();
        }
        if (this.gameObject.tag == "ModernArt")
        {
            print("ModernArt");
            player.GetComponent<ScoreScript>().totalDamage += 1325;
            GetComponentInParent<AudioSource>().Play();
        }
        if (this.gameObject.tag == "Stanchion")
        {
            print("Stancion");
            player.GetComponent<ScoreScript>().totalDamage += 1325;
            GetComponentInParent<AudioSource>().Play();
        }

    }
}
