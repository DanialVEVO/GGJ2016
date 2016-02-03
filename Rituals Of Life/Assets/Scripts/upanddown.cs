using UnityEngine;
using System.Collections;

public class upanddown : MonoBehaviour
{
	public float speed = 400f;
	public float openneer = 0f;

	void Update ()
	{
		
		openneer+=Time.deltaTime;
		this.gameObject.transform.position=new Vector3(this.transform.position.x, (Mathf.Sin(openneer)*0.1f)+0.85f,this.transform.position.z);
	}
}