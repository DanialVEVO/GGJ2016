using UnityEngine;
using System.Collections;

public class TouchReceiver : MonoBehaviour {

    [HideInInspector]
    public Vector2 fingerPlacement = Vector2.zero;

    [HideInInspector]
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
