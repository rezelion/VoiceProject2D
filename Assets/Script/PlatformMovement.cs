using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Vector3 posA;
    private Vector3 posB;
    private Vector3 posC;
    private Vector3 nextPos;
    private bool moving;

    [SerializeField]
    private bool AutoMode;
    [SerializeField]
    private float speed;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformTarget;

    [SerializeField]
    private Transform transformReturn;
    // Start is called before the first frame update
    void Start()
    {
        posA = childTransform.localPosition;
        posB = transformTarget.localPosition;
        posC = transformReturn.localPosition;
        nextPos = posB;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = false;
        }
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        if (AutoMode)
        {
            AutomaticMove();
        }
        else
        {
            if (moving)
            {
                move();
            }
            else
            {
                back();
            }
        }      
    }
    private void move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
        
    }
    private void back()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, posC, speed * Time.deltaTime);

    }

    private void AutomaticMove()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            //changeDestination
            nextPos = nextPos != posA ? posA : posB;
        }
    }
}
