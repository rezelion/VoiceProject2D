using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowScript : MonoBehaviour, IPointerDownHandler
{
    float[] rotates = {0, 90, 180, 270};
    float rotateZ;

    public float[] correctRotate;
    //public int testvar;
    public string findGameObj;

    [SerializeField]
    bool isCorrect;

    public bool randomRotatesActivate;
    public bool tightRotate; // 
    public bool flip = false;

    int possRotate = 1;
    public int corrAgain = 0, wrongAgain = 0;

    FlowController flowController;

    private void Awake()
    {
        flowController = GameObject.Find(findGameObj).GetComponent<FlowController>();
    }
    void Start()
    {
        possRotate = correctRotate.Length;

        if(randomRotatesActivate == true) // if true Random State Activate.
        {
            //Set random rotates
            int rand = Random.Range(0, rotates.Length);
            transform.eulerAngles = new Vector3(0, 0, rotates[rand]);
        }
        

        //Get current Z Rotates on -180 to 180;
        if (this.gameObject.GetComponent<Transform>().eulerAngles.z <= 180f)
        {
            rotateZ = this.gameObject.GetComponent<Transform>().eulerAngles.z;   
        }
        else
        {
            rotateZ = this.gameObject.GetComponent<Transform>().eulerAngles.z - 360f;
        }



        if (possRotate == 1 && tightRotate == false && flip == false)
        {
            if (rotateZ == correctRotate[0])
            {
                isCorrect = true;
                flowController.correctMove();
            }
            else if (rotateZ != correctRotate[0])
            {
                isCorrect = false;

            }

        }
        else if (possRotate == 2 && tightRotate == false && flip == false)
        {
            if (rotateZ == correctRotate[0] || rotateZ == correctRotate[1])
            {
                isCorrect = true;
                flowController.correctMove();
            }
            else if (rotateZ != correctRotate[0] || rotateZ != correctRotate[1])
            {
                isCorrect = false;
            }
        }
        else if (possRotate == 2 && tightRotate == true && flip == false)
        {
            if (rotateZ == correctRotate[0] || rotateZ == correctRotate[1])
            {
                isCorrect = true;
                flowController.correctMove();
                //testvar += 1;

                if (rotateZ == 0 || rotateZ == 180)
                {
                    corrAgain = 0;
                }
                else
                {
                    corrAgain += 1;
                }

            }
            else if (rotateZ != correctRotate[0] || rotateZ != correctRotate[1])
            {
                isCorrect = false;
                //testvar = 0;

                if (rotateZ == 0 || rotateZ == 180)
                {
                    wrongAgain = 0;
                }
                else
                {
                    wrongAgain += 1;
                }

            }
            
        }
        else if (possRotate == 2 && tightRotate == true && flip == true)
        {
            if (rotateZ == correctRotate[0] || rotateZ == correctRotate[1])
            {
                isCorrect = true;
                flowController.correctMove();
                //testvar += 1;

                if (rotateZ == 0 || rotateZ == 180)
                {
                    corrAgain += 1;
                }
                else
                {
                    corrAgain = 0;
                }

            }
            else if (rotateZ != correctRotate[0] || rotateZ != correctRotate[1])
            {
                isCorrect = false;
                //testvar = 0;

                if (rotateZ == 0 || rotateZ == 180)
                {
                    wrongAgain += 1;
                }
                else
                {
                    wrongAgain = 0;
                }

            }
        }
        else if (possRotate < 1)
        {
            isCorrect = false;
        }
        else
        {
            Debug.LogError("Max Correct Rotates is 2");
        }

        

    }
    // Update is called once per frame
    public void OnPointerDown(PointerEventData eventData)
    {

        transform.Rotate(new Vector3(0, 0, 90));

        if (this.gameObject.GetComponent<Transform>().eulerAngles.z <= 180f)
        {
            rotateZ = this.gameObject.GetComponent<Transform>().eulerAngles.z;
        }
        else
        {
            rotateZ = this.gameObject.GetComponent<Transform>().eulerAngles.z - 360f;
        }

        int rotZ = (int)rotateZ;
        //Debug.Log(rotZ);

        if (possRotate == 1 && tightRotate == false)
        {
            if (rotZ == correctRotate[0])
            {
                isCorrect = true;
                flowController.correctMove();
                //testvar += 1;

                
            }
            else if (isCorrect == true)
            {
                isCorrect = false;
                //testvar -= 1;
                flowController.wrongMove();
            }
            //else if (rotZ != correctRotate[0])
            //{
            //    isCorrect = false;
            //    flowController.wrongMove();
            //}

        }
        else if (possRotate == 2 && tightRotate == false)
        {
            if (rotZ == correctRotate[0] || rotZ == correctRotate[1])
            {
                isCorrect = true;
                flowController.correctMove();
            }
            else if (rotZ != correctRotate[0] || rotZ != correctRotate[1])
            {
                isCorrect = false;
                flowController.wrongMove();
            }
        }
        else if (possRotate == 2 && tightRotate == true) // for block type T
        {
            
            if (rotZ == correctRotate[0] || rotZ == correctRotate[1])
            {
                isCorrect = true;
                corrAgain += 1;

                if (corrAgain > 1)
                {
                    corrAgain = 0;
                    //testvar += 0;
                    flowController.duplicateMove();
                }
                else
                {
                    //testvar += 1;
                    flowController.correctMove();
                }

            }
            else if (rotZ != correctRotate[0] || rotZ != correctRotate[1])
            {
                isCorrect = false;
                wrongAgain += 1;

                if (wrongAgain > 1)
                {
                    wrongAgain = 0;
                    //testvar += 0;
                    flowController.duplicateMove();
                }
                else
                {
                    //testvar -= 1;
                    flowController.wrongMove();
                }
            }
        }
        
        else if (possRotate < 1)
        {
            isCorrect = false;
        }
        else
        {
            Debug.LogError("Max Correct Rotates is 2");
        }
    }
}
