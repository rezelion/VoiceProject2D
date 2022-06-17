using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    public GameObject selectedUI;
    public Player2DController playerController;
    public TimeOutController Time;
    public Button btnRestart, btnExitOnLobby;

    [SerializeField]
    private bool finishMode;
    [SerializeField]
    private bool pauseMode;
    int d ;
    private void Start()
    {
        btnExitOnLobby.onClick.AddListener(() => actionSelect(0));
        btnRestart.onClick.AddListener(() => actionSelect(1));

    }

    private void Update()
    {
        
        if (pauseMode == true)
        {
            
            if (Input.GetButtonDown("Cancel"))
            {
                showPopup();

                if (d == 1)
                {
                    d -= 1;

                    Time.timeActive(true);
                    selectedUI.SetActive(false);
                    playerController.ctrlDisabled(false);
                }
                else
                {
                    d += 1;
                }
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        showPopup();
    }

    public void showPopup() {

        if(finishMode == true)
        {
            Time.timeActive(false);
        }
        

        selectedUI.SetActive(true);
        playerController.ctrlDisabled(true);
    }

    private void actionSelect(int actionSelected)
    {
        if (actionSelected == 0)
        {
            SceneManager.LoadScene("HomeScene");
        }
        else if(actionSelected == 1)
        {
             // reload
             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            Debug.LogError("Error Selection Uknown");
        }
    }
}
