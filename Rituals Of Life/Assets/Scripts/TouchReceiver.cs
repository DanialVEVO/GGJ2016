using UnityEngine;
using System.Collections;

public class TouchReceiver : MonoBehaviour {

    public Vector2 fingerPlacement = Vector2.zero;
    public bool fingerActive = false;

   

    public void FingerPlacement(Vector3 newPlacement)
    {
        fingerPlacement = newPlacement;
        fingerActive = true;
    }

    public void LateUpdate()
    {        
        fingerActive = false;
    }
}
