using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{
    [Header("Life")]
    public GameObject[] LifeBox;
    public int LifePoint = 2;

    [Header("Required Object")]
    public GameObject Player;
    public TimeOutController timeOutController;
    [SerializeField]
    private Transform EarlySpawn;

    Player2DController playerController;
    
    private void Start()
    {
        playerController = Player.GetComponent<Player2DController>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(LifePoint < 1)
        {
            LifeBox[0].SetActive(false);
            this.gameObject.SetActive(false);
            timeOutController.timeActive(false);
        }
        else if(LifePoint == 1)
        {
            LifePoint -= 1;
            LifeBox[1].SetActive(false);
            Player.transform.position = EarlySpawn.position;
            timeOutController.timeAdd(30);
            playerController.isStop();
        }
        else if(LifePoint == 2)
        {
            LifePoint -= 1;
            LifeBox[2].SetActive(false);
            Player.transform.position = EarlySpawn.position;
            timeOutController.timeAdd(30);
            playerController.isStop();
        }
        else if(LifePoint > 2)
        {
            LifePoint -= 1;
            Player.transform.position = EarlySpawn.position;
            timeOutController.timeAdd(30);
            playerController.isStop();
        }
    }

}
