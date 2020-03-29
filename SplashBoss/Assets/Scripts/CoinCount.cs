using UnityEngine;
using UnityEngine.UI;

public class CoinCount : MonoBehaviour
{
    public static CoinCount Singleton { get; private set; }

    public int CointValue = 0;
    Text coin;


    private void Awake()
    {
        Singleton = this;
    }
    private void Start()
    {
        coin = GetComponent<Text>();
    }

    private void Update()
    {
        coin.text = CointValue.ToString();
    }
}
