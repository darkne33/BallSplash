using UnityEngine.UI;
using UnityEngine;

public class ControllerUI : MonoBehaviour
{
    public GameObject Point;
    public GameObject Restart;

    private void Update()
    {
        if (PlayerController.Singleton.Death == true)
        {
            Point.SetActive(true);
            Restart.SetActive(true);
        }
    }
}
