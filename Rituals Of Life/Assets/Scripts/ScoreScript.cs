using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {
    public int objectsDestroyed = 0;
    public int notificationsLeft = 0;
    public int totalDamage = 0;
    public bool calcScore = false;

    GameObject thumb;
    public GameObject Endscreen;
	// Use this for initialization
	void Start () {
        thumb = Endscreen.transform.GetChild(0).gameObject;
        thumb.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void showThumb()
    {
        thumb.SetActive(true);
    }

    public void CalcAndShowScore()
    {
        Endscreen.SetActive(true);
        Endscreen.transform.GetChild(1).GetComponent<Text>().text = "Total Damage Cost: € " + totalDamage;
        Endscreen.transform.GetChild(2).GetComponent<Text>().text = "Total Objects Destroyed " + objectsDestroyed;
        Endscreen.transform.GetChild(3).GetComponent<Text>().text = "Notifications Missed " + notificationsLeft;
    }
}
