using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    public GameObject FlowContainer;
    //public GameObject[] BlockFlow;
    //public GameObject MP;
    //public GameObject TriggerToHide;
    public GameObject ClearUI;
    public TimeOutController Time;
    

    //[SerializeField]
    //int totalFlow = 0;

    [SerializeField]
    int totalCorrectFlow;
    [SerializeField]
    int correctedFlow = 0;

    // Start is called before the first frame update
    //void Start()
    //{
    //    totalFlow = FlowContainer.transform.childCount;

    //    BlockFlow = new GameObject[totalFlow];

    //    for (int i = 0; i < BlockFlow.Length; i++)
    //    {
    //        BlockFlow[i] = FlowContainer.transform.GetChild(i).gameObject;
    //    }
    //}

    public void correctMove()
    {
        correctedFlow += 1;

        if(correctedFlow == totalCorrectFlow)
        {
            //Debug.Log("Activate Object!");
            //MP.SetActive(true);
            //TriggerToHide.SetActive(false);
            Time.timeAdd(30);
            ClearUI.SetActive(true);
        }
    }

    public void duplicateMove()
    {
        correctedFlow += 0;
    }

    public void wrongMove()
    {
        correctedFlow -= 1;
    }
}
