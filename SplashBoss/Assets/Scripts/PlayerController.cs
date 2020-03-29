using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int CollisionCount_1 = 0;
    public int CollisionCount_2 = 0;

    public static PlayerController Singleton { get; private set; }

    public Rigidbody2D _rigid;
    private RaycastHit2D isGround;
    public Animator _animator;

    private bool ShowFirstPlatform = false;

    public Transform PositionFirstPlatform;

    public GameObject FirstPlatform;

    public bool Death = false;

    public float JumpPower;
    public float JumpTime;

    [Header("Settings")]
    public LayerMask _layerGround;
    public float LengthLine;

    [Header("MovementEffect")]
    public float startTimeSpawn;
    public GameObject Effect;
    private float timeSpawn;

    public GameObject Dust;
    public Transform DustPosition;

    private void Awake()
    {
        Singleton = this;
    }
    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }


    public void Update()
    {
        isGround = Physics2D.Raycast(transform.position, Vector3.down, 1 * LengthLine, _layerGround); //испускаем невидимый луч для нахождения нужного слоя (в частности земли)

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary && JumpTime >= 0 || Input.GetMouseButton(0))
        {
            JumpTime += Time.deltaTime;
            if (JumpTime >= 3f)
            {
                JumpTime = 3f;
            }
        }
           

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isGround || Input.GetMouseButtonUp(0))
        {
            _rigid.AddForce(new Vector2(0, JumpPower * JumpTime), ForceMode2D.Impulse); //использовал импульсивность, хотя можно было просто силовой толчок
            JumpTime = 0f;
        }

        if (!isGround)
        {
            MovementEffect();
        }  

        if (ShowFirstPlatform)
        {
            float step = 5 * Time.deltaTime;
            FirstPlatform.transform.position = Vector3.MoveTowards(FirstPlatform.transform.position, PositionFirstPlatform.position, step);
        }

        
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * LengthLine)); //отображение луча в эдиторе
    }

    private void MovementEffect() //эффект прыжка как в игре
    {
        if (timeSpawn <= 0)
        {
            GameObject _effect = Instantiate(Effect, new Vector3(transform.position.x, transform.position.y, -1), Quaternion.identity) as GameObject;
            timeSpawn = startTimeSpawn;
            Destroy(_effect, 1f);
        }
        else
        {
            timeSpawn -= Time.deltaTime;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            _rigid.isKinematic = true;
            Death = true;
        }

        if (collision.gameObject.CompareTag("Platform_1") && _rigid.velocity.magnitude == 0)
        {
            //Instantiate(Dust, DustPosition.transform.position, Quaternion.identity); // не очень красиво получилось, решил закомментить
            PointCount.Singleton.PointValue++;
            CollisionCount_2 = 0;
            CollisionCount_1++;
            if (CollisionCount_1 == 2)
            {
                PointCount.Singleton.PointValue--;
                MovementPlatform_1.Singleton._collider.enabled = false;
            }
        }

        if (collision.gameObject.CompareTag("Platform_2") && _rigid.velocity.magnitude == 0)
        {
            //Instantiate(Dust, DustPosition.transform.position, Quaternion.identity);
            PointCount.Singleton.PointValue++;
            CollisionCount_1 = 0;
            CollisionCount_2++;
            if (CollisionCount_2 == 2)
            {
                PointCount.Singleton.PointValue--;
                MovementPlatform_2.Singleton._collider.enabled = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinCount.Singleton.CointValue++;
            Destroy(collision.gameObject);
        }
    }


    //на платформах нет анимации разрушения, поэтому я просто отключал коллайдер если не достал до верхней и упал вниз
}
