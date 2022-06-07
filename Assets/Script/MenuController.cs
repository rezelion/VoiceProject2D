using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resDropdown;
    Resolution[] resolutions;

    [Header("Menu Button")]
    public Button btnStart;
    public Button btnOption;
    public Button btnAbout;
    public Button btnExit;

    [Header("Exit Button")]
    public Button btnM_Yes;
    public Button btnM_No;

    [Header("Stage Button")]
    public Button btnStage1;

    [Header("Menu")]
    public GameObject mStart;
    public GameObject mOption;
    public GameObject mAbout;
    public GameObject mExit;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        List<string> options = new List<string>();

        int curResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + "x" + resolutions[i].height;

            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = curResIndex;
        resDropdown.RefreshShownValue();

        //Menu Button
        btnStart.onClick.AddListener(() => btnSelect(0));
        btnOption.onClick.AddListener(() => btnSelect(1));
        btnAbout.onClick.AddListener(() => btnSelect(2));
        btnExit.onClick.AddListener(() => btnSelect(3));

        //Exit Button
        btnM_Yes.onClick.AddListener(() => btnSelect(5));
        btnM_No.onClick.AddListener(() => btnSelect(4));

        //Stage Button
        btnStage1.onClick.AddListener(() => btnSelect(6));
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("vol", vol);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void btnSelect(int btnSelected)
    {
        if(btnSelected == 0)
        {
            mStart.SetActive(true);
            mOption.SetActive(false);
            mAbout.SetActive(false);
        }
        else if (btnSelected == 1)
        {
            mStart.SetActive(false);
            mOption.SetActive(true);
            mAbout.SetActive(false);
        }
        else if (btnSelected == 2)
        {
            mStart.SetActive(false);
            mOption.SetActive(false);
            mAbout.SetActive(true);
        }
        else if (btnSelected == 3)
        {
            mExit.SetActive(true);
            mStart.SetActive(false);
            mOption.SetActive(false);
            mAbout.SetActive(false);
        }
        else if (btnSelected == 4)
        {
            mExit.SetActive(false);
        }
        else if (btnSelected == 5)
        {
            Debug.Log("Selection Success : Exit!");
            Application.Quit();
        }
        else if (btnSelected == 6)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            Debug.LogError("Error Selection Menu not Found!");
        }
    }
}
