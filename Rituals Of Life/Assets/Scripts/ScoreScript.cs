using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
    public int objectsDestroyed = 0;
    public int totalDamage = 0;
    public bool calcScore = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        print(objectsDestroyed);
        if (calcScore == true)
        {
            for (int i = 1; i <= objectsDestroyed; i++)
            {
                Score();
            }
            calcScore = false;
        }
	}

    void Score(){
        int damage = Random.Range(300, 2000);
        totalDamage = totalDamage + damage;
    }
}
