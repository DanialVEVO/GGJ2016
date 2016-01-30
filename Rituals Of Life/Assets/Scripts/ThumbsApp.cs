using UnityEngine;
using System.Collections;

public class ThumbsApp : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnEnable()
    {
        Debug.Log("we are in foreground again.");
    }

    /*void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            // we are in background
            Debug.Log("we are in background");
        }
        else
        {
            // we are in foreground again.
            Debug.Log("we are in foreground again.");
        }
    }*/

}
