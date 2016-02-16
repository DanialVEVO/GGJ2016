﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    
    [SerializeField]
    float acceleration = 10f;

    [SerializeField]
    Vector2 maxSpeed = new Vector2(5.0f, 5.0f);

    [SerializeField]
    float maxCameraAngle = 45.0f;

    [SerializeField]
    float lookUpSpeed = 4.0f;

    [SerializeField]
    public Image phoneImage;

    [SerializeField]
    Image finger;

    [SerializeField]
    float fingerSpeed = 3.0f;

    Vector4 fingerBorder = new Vector4(-200, 200, 0, 1000);

    bool fingerActive = false;
    
    float phoneLook = 0.0f;

    bool stop = false;

	// Use this for initialization
	void Start () {


        finger.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0);

    }

    void Walking()
    {
        Vector2 maxSpeedUpdated = new Vector2(maxSpeed.x * Mathf.Abs(Input.GetAxis("LeftX")), maxSpeed.y * Mathf.Abs(1-Mathf.Clamp(Input.GetAxis("LeftY"), 0.0f, 0.5f)));

        Vector2 nextPos = Vector2.zero;

        if(Mathf.Abs(GetComponent<Rigidbody>().velocity.x) < maxSpeedUpdated.x)
            nextPos += new Vector2(Input.GetAxis("LeftX"), 0);

        if (GetComponent<Rigidbody>().velocity.z < maxSpeedUpdated.y)
            nextPos += new Vector2(0, 1 - Mathf.Clamp(Input.GetAxis("LeftY"), 0.0f, 0.5f));
       

        GetComponent<Rigidbody>().AddForce(new Vector3(nextPos.x,0,nextPos.y) * acceleration * 100 * Time.deltaTime);
    }

    void PhoneActive()
    {
        Vector2 nextPos = Vector2.zero;

        if (Input.GetAxis("RightBump") == 1)
        {

            fingerActive = true;

            finger.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
            finger.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else if (fingerActive == true)
        {

            fingerActive = false;

            finger.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            finger.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }

       // if (Mathf.Abs(Input.GetAxis("RightX")) == 1)
            nextPos += new Vector2(Input.GetAxis("RightX"),0);

       // if (Mathf.Abs(Input.GetAxis("RightY")) == 1)
            nextPos -= new Vector2(0,Input.GetAxis("RightY"));


        
        //nextpos is defined, now make sure it doesn't go beyond limit and set the rest.
        nextPos = finger.GetComponent<RectTransform>().anchoredPosition + (nextPos * fingerSpeed * Time.deltaTime);

        if (nextPos.x < fingerBorder.x)
            nextPos.x = fingerBorder.x;

        if (nextPos.x > fingerBorder.y)
            nextPos.x = fingerBorder.y;

        if (nextPos.y < fingerBorder.z)
            nextPos.y = fingerBorder.z;

        if (nextPos.y > fingerBorder.w)
            nextPos.y = fingerBorder.w;


        finger.GetComponent<RectTransform>().anchoredPosition = nextPos;



        if (!fingerActive)
            return;

        var activeTouchObjects = phoneImage.GetComponentsInChildren<TouchReceiver>();

        foreach (TouchReceiver t in activeTouchObjects)
        {
            t.FingerPlacement(finger.GetComponent<RectTransform>().position, finger.GetComponent<RectTransform>().anchoredPosition);
        }
    }

    void Phone()
    {
        if (Input.GetAxis("LeftBump") < 1.0f && phoneLook < 1.0f)
        {
            phoneLook += lookUpSpeed * Time.deltaTime;
            if (phoneLook > 1)
                phoneLook = 1;

            Camera.main.transform.Rotate((maxCameraAngle * phoneLook) - Camera.main.transform.rotation.eulerAngles.x, 0, 0);
            phoneImage.GetComponent<RectTransform>().anchoredPosition = Vector3.down * 1080 * (1-phoneLook);
        }

        if (Input.GetAxis("LeftBump") > 0.0f && phoneLook > 0.0f)
        {
            phoneLook -= lookUpSpeed * Time.deltaTime;
            if (phoneLook < 0)
                phoneLook = 0;

            Camera.main.transform.Rotate((maxCameraAngle * phoneLook) - Camera.main.transform.rotation.eulerAngles.x, 0, 0);
            phoneImage.GetComponent<RectTransform>().anchoredPosition = Vector3.down * 1080 * (1-phoneLook);
        }

        if (phoneLook >= 1.0f)
        {
            PhoneActive();
            Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = true;
            if (Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().blurSpread <= 0.5f)
            {
                Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().blurSpread += 0.1f * Time.deltaTime*10;
            }
            Camera.main.GetComponent<PhoneNeglectEffect>().insaneValue = 0;
            Camera.main.transform.eulerAngles = new Vector3(45, 0, 0);
        }
        else
        {
            if (Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().blurSpread >= 0.1f)
            {
                Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().blurSpread -= 0.1f * Time.deltaTime*10;
            }
            else if(Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled)
            {
                Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = false;
                //Camera.main.GetComponent<PhoneNeglectEffect>().insaneValue += Time.deltaTime*0.5f;
                int newValue = 0;
                phoneImage.GetComponent<Phone>().GetNotifications(out newValue);
                Camera.main.GetComponent<PhoneNeglectEffect>().insaneValue = Mathf.Clamp(newValue / 2.0f, 0.0f, 10.0f);

            }
        }
        if (phoneLook ==0.0f) Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);

    }


	// Update is called once per frame
	void Update () {

        if (stop)
            return;

        Walking();

        Phone();
	}
}
