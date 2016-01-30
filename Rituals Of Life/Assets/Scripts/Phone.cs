using UnityEngine;
using System.Collections;

public class Phone : TouchReceiver {

    [SerializeField]
    Vector2 notificationSpeed = new Vector2(0.1f, 3.0f);

    float timeTillNextNot = 3.0f;

    [SerializeField]
    GameObject[] Apps;

    [SerializeField]
    GameObject[] TouchAreas;

    int[] notifications;

    int currentApp = 0;



    // Use this for initialization
    void Start () {

        notifications = new int[Apps.Length];

        for (int i = 0; i < notifications.Length; i++)
            notifications[i] = 0;
	}
	
	// Update is called once per frame
	void Update () {

        timeTillNextNot -= Time.deltaTime;
        if (timeTillNextNot < 0)
        {
            notifications[Random.Range(0, notifications.Length)] += 1;

            for (int i = 0; i < notifications.Length; i++)
                Debug.Log(notifications[i]);

            timeTillNextNot = Random.Range(notificationSpeed.x, notificationSpeed.y);
        }
	}

    void ChangeApp(int nextApp)
    {
       

        for (int i = 0; i < Apps.Length; i++)
            if (i == nextApp)
                Apps[i].SetActive(true);
            else
                Apps[i].SetActive(false);

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
                    ChangeApp(i);
            }
        }

       /* for (int i = 0; i < TouchAreas.Length; i++)
        {
            Debug.Log(fingerPlacement);

            // if (fingerPlacement.x < TouchAreas[i].GetComponent<Collider>().bounds.max.x && fingerPlacement.x > TouchAreas[i].GetComponent<Collider>().bounds.min.x )//&&
            //fingerPlacement.y < TouchAreas[i].GetComponent<Collider>().bounds.max.y && fingerPlacement.y > TouchAreas[i].GetComponent<Collider>().bounds.min.y)
            

            
        }*/

    }

    public void update()
    {

    }

    new public void LateUpdate()
    {

        if (fingerActive)
            checkForHit();
        

        base.LateUpdate();
    }

  



}

