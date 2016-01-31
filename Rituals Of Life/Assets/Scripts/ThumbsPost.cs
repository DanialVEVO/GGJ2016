using UnityEngine;
using System.Collections;

public class ThumbsPost : TouchReceiver {

    [HideInInspector]
    public int toHeight = -1200;

    bool lastTurnActiveState = false;

    // Use this for initialization
    void Start () {
	
	}

    void checkForHit()
    {
        Ray ray = new Ray(new Vector3(fingerPlacement.x, fingerPlacement.y, 1), Vector3.back);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit))
        {

            if (hit.collider.gameObject == GetComponentInChildren<Collider>().gameObject)
                GetComponentInParent<ThumbsApp>().DeletePost(gameObject);
            
        }
        
    }

    void ChangeHeight()
    {
        GetComponent<RectTransform>().anchoredPosition = Vector3.Slerp(GetComponent<RectTransform>().anchoredPosition, Vector3.up * toHeight, Time.deltaTime);
    }



    new public void LateUpdate()
    {
        if (GetComponent<RectTransform>().position.y != toHeight)
            ChangeHeight();

        if (fingerActive && !lastTurnActiveState)
            checkForHit();

        lastTurnActiveState = fingerActive;


        base.LateUpdate();
    }
}
