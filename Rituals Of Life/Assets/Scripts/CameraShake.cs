using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    public bool Shaking;
    private float ShakeDecay;
    private float ShakeIntensity;
    private Vector3 OriginalPos;
    private Quaternion OriginalRot;

    void Start()
    {
        Shaking = false;
    }

    void Update()
    {
        if (ShakeIntensity > 0)
        {
            Camera.main.transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                            OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                            OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                                            OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f);

            ShakeIntensity -= ShakeDecay;
        }
        else if (Shaking)
        {
            Shaking = false;
        }


    }

    public void DoShake()
    {
        OriginalRot = Camera.main.transform.rotation;

        ShakeIntensity = 0.3f;
        ShakeDecay = 0.02f;
        Shaking = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>()==null)
        {
            DoShake();
            print("shake");
        }
    }
}