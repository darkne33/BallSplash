using UnityEngine;
using UnityEngine.UI;
public class PointCount : MonoBehaviour
{
    public static PointCount Singleton { get; private set; }

    public int PointValue = 0;
    Text point;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        point = GetComponent<Text>();
    }

    private void Update()
    {
        point.text = PointValue.ToString();
    }
}
