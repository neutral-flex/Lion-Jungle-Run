
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player pl;
    public bool Play = false;
    public float Speed;
    public float oneSec;
    Rigidbody2D rb;
    float EnemySpeed;

    public AudioSource soundHit;
    public AudioSource jump;

    private Vector2 startTouchPosition, endTouchPosition;
    private float jumpForce = 700f;
    private bool jumpAllowed = false;

    bool iamtocuhed = false;
    // Start is called before the first frame update
    void Start()
    {
        pl = this;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           

        }
        if (Play == true)
        {
            oneSec += Time.deltaTime;
            if (oneSec < 1f)
            {
                transform.Translate(new Vector2 (1,0) * Speed * Time.deltaTime);
                SwipeCheck();
            }
            
        }
        if (oneSec > 1f)
        {
            Enemy.instance.Speed = 17;
        }
     
    }

    private void FixedUpdate()
    {
        JumpIfAllowed();
    }

    public void Tap()
    {
        if (oneSec < 1f)
        {
            oneSec = 0;
        }
        if (Play == false)
        {
            Play = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Speed = 0;
            oneSec = 10;
            EnemySpeed = Enemy.instance.Speed;
            soundHit.Play();
            Enemy.instance.Speed = 17;
        }
        if (collision.gameObject.tag != "Finish")
        {
            iamtocuhed = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Enemy.instance.Speed = EnemySpeed;
        }

        if (collision.gameObject.tag != "Finish")
        {
            iamtocuhed = false;
        }
    }
    private void SwipeCheck()
    {
        
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            startTouchPosition = Input.GetTouch(0).position;


        startTouchPosition.y += 2f;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
            if (endTouchPosition.y > startTouchPosition.y && iamtocuhed == true)
                jumpAllowed = true;
        }
       
    }

    private void JumpIfAllowed()
    {
        if (jumpAllowed)
        {
            jump.Play();
            rb.AddForce(new Vector2(0, 12.5f), ForceMode2D.Impulse);
            jumpAllowed = false;
        }
    }

}
