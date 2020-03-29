using UnityEngine;

public class MovementPlatform_2 : MonoBehaviour
{
    public static MovementPlatform_2 Singleton { get; private set; }

    public GameObject platform_1;

    public Transform targetSpawn;
    public Transform StartPos;
    public Transform MoveDown;
    public Transform PositionHidePlatform;

    public  bool MoveDown_bool = false;

    public BoxCollider2D _collider;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            platform_1.transform.position = targetSpawn.transform.position;
            MoveDown_bool = true;
        }
    }

   

    private void FixedUpdate()
    {
        float step = 5 * Time.fixedDeltaTime;
        float step_slow_down = 1 * Time.fixedDeltaTime;

        if (platform_1.transform.position == MoveDown.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos.position, step);
        }

        if (transform.position == MoveDown.position)
        {
            MoveDown_bool = false;
        }

        if (MoveDown_bool == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, MoveDown.position, step);
        }

        if (platform_1.transform.position == StartPos.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PositionHidePlatform.position, step_slow_down);
        }

    }
}
