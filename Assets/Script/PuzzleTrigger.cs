using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour
{
    public GameObject PuzzleType;

    private void Start()
    {
        
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PuzzleType.SetActive(true);
            //this.enabled = false;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PuzzleType.SetActive(false);
            //this.enabled = false;
        }
    }
}
