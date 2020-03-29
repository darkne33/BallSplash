using System.Collections;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject Coin;
    

    IEnumerator Spawner_Timer()
    {
        if (GameObject.Find("Coin(Clone)") == null)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(Coin, transform.position, Quaternion.identity);
        }
    }

    public void Spawner()
    {
        StartCoroutine(Spawner_Timer());
    }

    private void Start()
    {
        InvokeRepeating("Spawner", 5f, 6f);
    }

}
