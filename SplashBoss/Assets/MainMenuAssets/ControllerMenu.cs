using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingMenu;

    public void ExitButton()
    {
        Application.Quit();
    }
    


    public void SettingButton()
    {
        MainMenu.SetActive(false);
        SettingMenu.SetActive(true);
    }

    public void StartButton()
    {
        MainMenu.SetActive(false);
        SceneManager.LoadScene("Training");
    }

}
