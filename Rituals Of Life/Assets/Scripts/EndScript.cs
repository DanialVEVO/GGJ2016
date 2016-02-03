using UnityEngine;
using System.Collections;

public class EndScript : MonoBehaviour {

    bool rotateCamera = false;
    bool moveCamera = false;
    public GameObject player;
    public GameObject phone;

    bool triggered = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (triggered)
        {
            Camera.main.GetComponent<PhoneNeglectEffect>().enabled = false;
            Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Bloom>().bloomIntensity = 0.02f;
            Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 0.0f;
            Camera.main.GetComponent<UnityStandardAssets.ImageEffects.ScreenOverlay>().intensity = 0.0f;
            if (rotateCamera == true && Camera.main.transform.eulerAngles.y <= 180.0f)
            {
                if (Camera.main.transform.eulerAngles.x !=0)Camera.main.transform.eulerAngles = new Vector3(0, 0, 0);
                Camera.main.transform.Rotate(0, 1.0f * Time.deltaTime * 40, 0);
            }
            else if (Camera.main.transform.eulerAngles.y >= 180.0f)
            {
                Camera.main.transform.eulerAngles = new Vector3(0, 180, 0);
                moveCamera = true;
                player.GetComponent<Rigidbody>().isKinematic = true;
                player.GetComponent<Collider>().enabled = false;
                
            }
        }
        if (moveCamera == true && player.transform.position.z >= 0)
        {
            player.transform.Translate(0, 0, -1.0f * Time.deltaTime * 5);
        }
        if (moveCamera == true && player.transform.position.z <=0.1f) player.GetComponent<ScoreScript>().showThumb();
    }
    void OnTriggerEnter(Collider other)
    {
        int rest = 0;
        phone.GetComponent<Phone>().GetNotifications(out rest);
        other.GetComponent<ScoreScript>().notificationsLeft = rest;
        phone.GetComponent<Phone>().NotificationWarning.SetActive(false);
        phone.SetActive(false);
        other.GetComponent<CameraShake>().enabled = false;
        other.GetComponent<PlayerScript>().enabled = false;
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = false;
        Camera.main.transform.Rotate(-45.0f, 0, 0);
        var phoneImage = other.GetComponent<PlayerScript>().phoneImage;
        phoneImage.GetComponent<RectTransform>().anchoredPosition = Vector3.down * 1080;
        rotateCamera = true;
        triggered = true;
        other.GetComponent<ScoreScript>().CalcAndShowScore();
    }
}
