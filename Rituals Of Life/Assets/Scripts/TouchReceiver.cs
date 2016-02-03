using UnityEngine;
using System.Collections;

public class TouchReceiver : MonoBehaviour {

    [HideInInspector]
    public Vector2 fingerPlacement = Vector2.zero;

    [HideInInspector]
    public Vector2 fingerAnchoredPlacement = Vector2.zero;

    [HideInInspector]
    public bool fingerActive = false;

   

    public void FingerPlacement(Vector3 newPlacement, Vector2 newAnchoredPlacement)
    {
        fingerPlacement = newPlacement;
        fingerAnchoredPlacement = newAnchoredPlacement;
        fingerActive = true;
    }

    public void LateUpdate()
    {        
        fingerActive = false;
    }
}
