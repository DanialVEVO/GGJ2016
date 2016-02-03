using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour
{
	public float speed = 40f;


	void Update ()
	{
		transform.Rotate(Vector3.up, speed * Time.deltaTime);
		transform.Rotate(Vector3.left, speed/3 * Time.deltaTime);
	}
}