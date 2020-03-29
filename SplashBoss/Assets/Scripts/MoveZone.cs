using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.parent = null;
    }
}
