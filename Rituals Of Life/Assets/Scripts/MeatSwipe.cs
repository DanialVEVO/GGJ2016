using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeatSwipe : TouchReceiver
{
    public Sprite[] faces;

    GameObject facePrefab;

    //GameObject[] posts = new GameObject[0];
       
    int notif = 0;

    bool lastTurnActiveState = false;

    bool reset = false;

    float startSwipePos = 0;

    
    /*void AddPost()
    {
        GameObject[] postsClone = new GameObject[posts.Length];

        for (int i = 0; i < posts.Length; i++)
            postsClone[i] = posts[i];


        posts = new GameObject[postsClone.Length + 1];

        for (int i = 0; i < postsClone.Length; i++)
            posts[i] = postsClone[i];

        GameObject newPost = Instantiate(postPrefab, Vector3.down * 1200, Quaternion.identity) as GameObject;
        newPost.transform.SetParent(transform, false);

        newPost.GetComponent<ThumbsPost>().toHeight = -95 - (150 * (posts.Length - 1));

        posts[posts.Length - 1] = newPost;

        notif++;
    }

    public void DeletePost(GameObject delPost)
    {
        GameObject[] postsClone = posts;

        posts = new GameObject[postsClone.Length - 1];

        int count = 0;

        for (int i = 0; i < postsClone.Length; i++)
        {
            if (postsClone[i] != delPost)
            {
                posts[count] = postsClone[i];
                count++;

                postsClone[i].GetComponent<ThumbsPost>().toHeight = -95 - (150 * (count - 1));
            }
        }

        GetComponentInParent<Phone>().SetNotifications(gameObject, -1);

        notif--;

        Destroy(delPost);
    }*/

    void Swiping()
    {
        GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2((fingerAnchoredPlacement.x - startSwipePos), 0);

        if (fingerAnchoredPlacement.x - startSwipePos > 200)
        {            

            GetComponentInParent<Phone>().SetNotifications(gameObject, -1);

            notif--;

            reset = true;

            startSwipePos = 2000000;

        }
    }


    void OnEnable()
    {
       // int newNotif = 0;
        //int oldNotif = notif;

        GetComponentInParent<Phone>().GetNotifications(out notif, gameObject);

        if (notif == 0)
        {
            GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().sprite = null;

            GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().color = new Vector4(1,1,1,0);

        }
        else
        { 
            GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().sprite = faces[Random.Range(0, faces.Length)];

            GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().color = new Vector4(1, 1, 1, 1);

        }

        //Debug.Log("new motif = " + newNotif + ". notif = " + notif);

        //for (int i = 0; i < newNotif - oldNotif; i++)
        //   AddPost();

    }

    new public void LateUpdate()
    {


        if (fingerActive && !lastTurnActiveState)
        {
            lastTurnActiveState = true;
            startSwipePos = fingerAnchoredPlacement.x;
        }

        if (fingerActive && reset == false && startSwipePos < 20000)
            Swiping();
        else if (reset == false)
        {
            GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector3.Slerp(GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition, Vector3.zero, 8 * Time.deltaTime);
        }
        else if (reset == true && GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().sprite != null)
        {
            //Debug.Log(GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x);

            if (GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x > 0)
                GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition += new Vector2(1000, 0) * Time.deltaTime;
            if (GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x > 400)
            {
                GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-400, 0);


                if (notif == 0)
                {
                    GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().sprite = null;

                    GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().color = new Vector4(1, 1, 1, 0);

                }
                else
                {
                    GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().sprite = faces[Random.Range(0, faces.Length)];

                    GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<Image>().color = new Vector4(1, 1, 1, 1);

                }

            }
            if (GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x < -100)
                GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector3.Slerp(GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition, Vector3.zero, 8 * Time.deltaTime);
            else if (GetComponentInChildren<Mask>().transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.x < 0)
                reset = false;

        }



        lastTurnActiveState = fingerActive;


        base.LateUpdate();
    }

}

