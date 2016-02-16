using UnityEngine;
using System.Collections;

public class ThumbsApp : MonoBehaviour {

    public GameObject postPrefab;

    GameObject[] posts = new GameObject[0];

    [SerializeField]
    int notif = 0;

    

    void AddPost()
    {
        GameObject[] postsClone = new GameObject[posts.Length];

        for (int i = 0; i < posts.Length; i++)
             postsClone[i] = posts[i];


        posts = new GameObject[postsClone.Length+1];

        for (int i = 0; i < postsClone.Length; i++)
            posts[i] = postsClone[i];

        GameObject newPost = Instantiate(postPrefab, Vector3.down * 1200, Quaternion.identity) as GameObject;
        newPost.transform.SetParent(transform, false);

        newPost.GetComponent<ThumbsPost>().toHeight = -95 - (150 * (posts.Length - 1));    

        posts[posts.Length-1] = newPost;

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

                postsClone[i].GetComponent<ThumbsPost>().toHeight = -95 - (150 * (count-1));
            }
        }

        GetComponentInParent<Phone>().SetNotifications(gameObject, -1);

        notif--;

        Destroy(delPost);

        OnEnable();
    }


    void OnEnable()
    {
        int newNotif = 0;
        int oldNotif = notif;

        GetComponentInParent<Phone>().GetNotifications( out newNotif, gameObject);

        //Debug.Log("new motif = " + newNotif + ". notif = " + notif);
        if (newNotif == 0)
            GetComponentInParent<Phone>().ExpandHomeButton();

        for (int i = 0; i < newNotif - oldNotif; i++)
            AddPost();
                
    }

    

}
