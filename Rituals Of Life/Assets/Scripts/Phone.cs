using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Phone : TouchReceiver {

    [SerializeField]
    Vector2 notificationSpeed = new Vector2(0.1f, 3.0f);

    float timeTillNextNot = 3.0f;

    [SerializeField]
    GameObject[] Apps;

    [SerializeField]
    GameObject[] TouchAreas;

    int[] notifications;

    [SerializeField]
    int currentApp = 0;

    //[SerializeField]
    public GameObject NotificationWarning;

    bool lastTurnActiveState = false;

    float warningTimer = 1.0f;

    [HideInInspector]
    public bool stop = true;

    // Use this for initialization
    void Start () {

        NotificationWarning.SetActive(false);

        notifications = new int[Apps.Length];

        for (int i = 0; i < notifications.Length; i++)
            notifications[i] = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (stop)
            return;

        timeTillNextNot -= Time.deltaTime;
        if (timeTillNextNot < 0)
        {
            notifications[Random.Range(0, notifications.Length)] += 1;

            NotificationWarning.SetActive(true);

            GetComponent<AudioSource>().Play();
            //for (int i = 0; i < notifications.Length; i++)
             //   Debug.Log(notifications[i]);

            if(currentApp == 0)
                UpdateNotifications();

            timeTillNextNot = Random.Range(notificationSpeed.x, notificationSpeed.y);
        }

        if (NotificationWarning.activeSelf == true)
        {
            warningTimer -= Time.deltaTime;

            if (warningTimer < 0)
            {
                warningTimer = 1.0f;
                NotificationWarning.SetActive(false);
            }
        }
	}

    void ChangeApp(int nextApp)
    {

        currentApp = 0;

        for (int i = 0; i < Apps.Length; i++)
            if (i == nextApp)
            {
                Apps[i].SetActive(true);
                currentApp = i+1;
            }
            else
                Apps[i].SetActive(false);

        if (currentApp == 0)
        {
            for (int i = 0; i < TouchAreas.Length; i++)
                TouchAreas[i].SetActive(true);

            TouchAreas[TouchAreas.Length-1].GetComponent<BoxCollider>().size = new Vector2(450, 130);

            //TouchAreas[TouchAreas.Length-1].GetComponentInChildren<Text>().enabled = false;
            //TouchAreas[TouchAreas.Length-1].GetComponentInChildren<Image>().enabled = false;
            TouchAreas[TouchAreas.Length - 1].transform.GetChild(0).GetComponent<Image>().enabled = false;
            TouchAreas[TouchAreas.Length - 1].transform.GetChild(1).GetComponent<Image>().enabled = false;

            UpdateNotifications();
        }
        else
            for (int i = 0; i < TouchAreas.Length-1; i++)
                TouchAreas[i].SetActive(false);
    }

    void checkForHit()
    {
        Ray ray = new Ray(new Vector3(fingerPlacement.x, fingerPlacement.y, 1), Vector3.back);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit))
        {
            for (int i = 0; i < TouchAreas.Length; i++)
            {
                if (hit.collider.gameObject == TouchAreas[i])
                    if(currentApp == 0 || i == TouchAreas.Length-1)
                        ChangeApp(i);
            }
        }             

    }

    public void ExpandHomeButton()
    {

        TouchAreas[TouchAreas.Length-1].GetComponent<BoxCollider>().size = new Vector2(450, 1830);

        //TouchAreas[TouchAreas.Length-1].GetComponentInChildren<Text>().enabled = true;
        //TouchAreas[TouchAreas.Length-1].GetComponentInChildren<Image>().enabled = true;

        TouchAreas[TouchAreas.Length - 1].transform.GetChild(0).GetComponent<Image>().enabled = true;
        TouchAreas[TouchAreas.Length - 1].transform.GetChild(1).GetComponent<Image>().enabled = true;

    }


    public void SetNotifications(GameObject App, int difference)
    {
        for (int i = 0; i < Apps.Length; i++)
            if (Apps[i] == App)
                notifications[i] += difference;
    }

    public void GetNotifications(out int NotifAmount, GameObject App = null)
    {
        
        int amount = 0;

        if (App == null)
        {
            for (int i = 0; i < Apps.Length; i++)
                amount += notifications[i];

            NotifAmount = amount;

            return;
        }

        for (int i = 0; i < Apps.Length; i++)
        {
            if (Apps[i] == App)
                amount = notifications[i];

        }

        //Debug.Log("amount of notifications = " + amount);

        NotifAmount = amount;

        return;
    }

    void UpdateNotifications()
    {
        for (int i = 0; i < TouchAreas.Length - 1; i++)
            TouchAreas[i].GetComponentInChildren<Text>().text = (notifications[i].ToString());

        int newValue = 0;
        GetNotifications(out newValue);
        Camera.main.GetComponent<PhoneNeglectEffect>().insaneValue = Mathf.Clamp( newValue / 2.0f, 0.0f , 10.0f);
    }

    new public void LateUpdate()
    {

        if (fingerActive && !lastTurnActiveState)
            checkForHit();

        lastTurnActiveState = fingerActive;

        base.LateUpdate();
    }

  



}

