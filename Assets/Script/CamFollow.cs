using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public Vector3 minVal, maxVal;
    //Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {

        Vector3 targetPosition = target.position + offset;
        Vector3 boundPos = new Vector3(Mathf.Clamp(targetPosition.x, minVal.x, maxVal.x),
                                       Mathf.Clamp(targetPosition.y, minVal.y, maxVal.y),
                                       Mathf.Clamp(targetPosition.z, minVal.z, maxVal.z));
        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPos, smoothFactor*Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
