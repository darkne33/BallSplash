using UnityEngine;

public class BallController : MonoBehaviour
{
    public InputData inputData;

    public float moveSpeed = 5f;

    Vector3 m_clickedPos;

    Vector3 m_releasePos;

    Vector3 m_dir;

    Rigidbody2D m_rigid2D;

    Camera m_cam;
    BallVFX m_ballVFX;
    private void Start()
    {
        GetComponents();
    }

    public void GetComponents()
    {
        m_rigid2D = GetComponent<Rigidbody2D>();
        m_cam = FindObjectOfType<Camera>();
        m_ballVFX = GetComponent<BallVFX>();
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (inputData.isPressed == true)
        {
            m_clickedPos = m_cam.ScreenToWorldPoint(Input.mousePosition);
            m_clickedPos = new Vector3(m_clickedPos.x, m_clickedPos.y, 0f);

            ResetBallPos();

            m_ballVFX.SetDotStartPos(m_clickedPos);
            m_ballVFX.ChangeDotActiveState(true);
        }

        if (inputData.isHeld == true)
        {
            m_ballVFX.SetDotPos(m_clickedPos, m_cam.ScreenToWorldPoint(Input.mousePosition));
        }

        if (inputData.isReleased == true)
        {
            m_releasePos = m_cam.ScreenToWorldPoint(Input.mousePosition);
            m_releasePos = new Vector3(m_releasePos.x, m_releasePos.y, 0f);

            m_ballVFX.ChangeDotActiveState(false);

            CalculateDirecation();
            MoveBallDirection();
        }  
    }

    private void CalculateDirecation()
    {
        m_dir = (m_releasePos - m_clickedPos).normalized;
    }

    private void MoveBallDirection()
    {
        m_rigid2D.velocity = m_dir * moveSpeed;
    }
    
    private void ResetBallPos()
    {
        transform.position = m_clickedPos;
        m_rigid2D.velocity = Vector3.zero;
    }
}
