using UnityEngine;

public class MovementPlatform_1 : MonoBehaviour
{
    public static MovementPlatform_1 Singleton { get; private set; }

    public GameObject platform_2;
    public GameObject First_Platform;

    public Transform targetSpawn;
    public Transform StartPos;
    public Transform MoveDown;
    public Transform PositionHidePlatform;

    public BoxCollider2D _collider;


    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        Singleton = this;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            platform_2.transform.position = targetSpawn.transform.position;
        }
    }

  

    private void FixedUpdate()
    {
        float step = 5 * Time.fixedDeltaTime;
        float step_slow_down = 1 * Time.fixedDeltaTime;

        if (platform_2.transform.position == MoveDown.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos.position, step);
        }

        if(platform_2.transform.position == targetSpawn.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, MoveDown.position, step);
        }

       if (platform_2.transform.position == StartPos.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PositionHidePlatform.position, step_slow_down);
        }

        if (transform.position == MoveDown.transform.position)
        {
            First_Platform.transform.position = Vector3.MoveTowards(First_Platform.transform.position, PositionHidePlatform.position, step);
        }

    }
}
