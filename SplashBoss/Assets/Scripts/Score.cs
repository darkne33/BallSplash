using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text menuScore;

    private void Start()
    {
        menuScore = GetComponent<Text>();
    }
    private void Update()
    {
        menuScore.text = "Score " + PointCount.Singleton.PointValue.ToString();
    }
}
