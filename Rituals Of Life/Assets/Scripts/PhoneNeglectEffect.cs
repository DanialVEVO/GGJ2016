using UnityEngine;
using System.Collections;

public class PhoneNeglectEffect : MonoBehaviour {
    public float bloomValue;
    public float maxBloomValue;
    public float blurValue1;
    public float maxBlur1;
    public float overlayValue;
    public float maxOverlay;
    public float speed;
    public float decreaseSpeed;
    public float insaneValue;
    public float recoverValue;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        

        if (insaneValue != 0)
        {
            maxOverlay = 0.02f * insaneValue;
            maxBloomValue = 0.01f * insaneValue;
            maxBlur1 = 0.02f * insaneValue;
            if (GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity <= (1*insaneValue))
            {
                bloomValue = bloomValue + maxBloomValue*Time.deltaTime*speed;
                GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = bloomValue;
            }
            if (GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize <= (0.2f*insaneValue))
            {
                blurValue1 = blurValue1 + maxBlur1*Time.deltaTime*speed;
                GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = blurValue1;
            }
            if (GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity <= (0.2f * insaneValue))
            {
                overlayValue = overlayValue + maxOverlay*Time.deltaTime*speed*2;
                GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = overlayValue;
            }
            recoverValue = insaneValue;
        }
        else
        {
            if (recoverValue >=0) recoverValue -= Time.deltaTime * 0.5f;
            if (recoverValue <= 0.01f) recoverValue = 0.0f;
            maxOverlay = 0.02f * recoverValue;
            maxBloomValue = 0.01f * recoverValue;
            maxBlur1 = 0.02f * recoverValue;
            if (bloomValue >=0.02f)
            {
                bloomValue = bloomValue - 0.01f * Time.deltaTime * decreaseSpeed*20;
                GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = bloomValue;
            }
            if (blurValue1>=0.1f)
            {
                blurValue1 = blurValue1 - maxBlur1 * Time.deltaTime * decreaseSpeed*2;
                GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = blurValue1;
            }
            if (overlayValue>=0.1f)
            {
                overlayValue = overlayValue - maxOverlay * Time.deltaTime * decreaseSpeed*0.5f;
                GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = overlayValue;
            }
            if (GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity <= 0.1f) GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = 0.02f;
            if (GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize <= 0.1f) GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 0.0f;
            if (GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity <= 0.1f) GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = 0.0f;
        }

        if (insaneValue >= 4) GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = true;
        else GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().enabled = false;

    }
}
