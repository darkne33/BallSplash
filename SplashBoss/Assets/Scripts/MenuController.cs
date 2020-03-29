using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("First_Scene", LoadSceneMode.Single);
    }
}
