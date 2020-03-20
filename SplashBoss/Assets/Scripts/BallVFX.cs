using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallVFX : MonoBehaviour
{

    public GameObject dotPrefab;

    public int dotAmount;

    [Space]
    [Header("Line Varibles")]

    public AnimationCurve followCurve;
    public float followSpeed;

    private float m_dotGap;

    GameObject[] m_dotArray;

    void Start()
    {
        m_dotGap = 1f / dotAmount; // процент от одной точки по отношению к целому
        SpawnDots();
    }

    private void SpawnDots()
    {
        m_dotArray = new GameObject[dotAmount];

        for (int i = 0; i < dotAmount; i++)
        {
            GameObject _dot = Instantiate(dotPrefab);
            _dot.SetActive(false);
            m_dotArray[i] = _dot;
        }
    }

    public void SetDotPos(Vector3 startPos, Vector3 endPos)
    {
        for (int i = 0; i < dotAmount; i++)
        {
            Vector3 _dotPos = m_dotArray[i].transform.position;
            Vector3 _targetPos = Vector2.Lerp(startPos, endPos, i * m_dotGap);

            float _smoothSpeed = (1f - followCurve.Evaluate(i * m_dotGap)) * followSpeed;

            //m_dotArray[i].transform.position = _targetPos;

            m_dotArray[i].transform.position = Vector2.Lerp(_dotPos, _targetPos, _smoothSpeed * Time.deltaTime);
        }
    }

    public void ChangeDotActiveState(bool state)
    {
        for (int i = 0; i < dotAmount; i++)
        {
            m_dotArray[i].SetActive(state);
        }
    }

    public void SetDotStartPos (Vector3 pos)
    {
        for (int i = 0; i < dotAmount; i++)
        {
            m_dotArray[i].transform.position = pos;
        }
    }
}
