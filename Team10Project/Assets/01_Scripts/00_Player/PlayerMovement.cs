using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Scripts:")]
    [SerializeField]
    PlayerJump playerJump;

    [Header("Components:")]
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    Animator anim;

    [Header("Settings:")]
    [SerializeField]
    float runSpeed;

    [SerializeField]
    float downTimer;

    int playerLayer, groundLayer, slowGroundLayer, fastGroundLayer;

    bool isfacingRight;
    bool isDownLayer;
    bool isGround;

    void Start()
    {
        transform.position = Vector3.zero;

        isfacingRight = true;

        playerLayer = LayerMask.NameToLayer("Player");
        groundLayer = LayerMask.NameToLayer("Ground");
        slowGroundLayer = LayerMask.NameToLayer("SlowGround");
        fastGroundLayer = LayerMask.NameToLayer("FastGround");
    }
    
    void Update()
    {
        


        if (!isDownLayer)
        {
            if (rigid.velocity.y > 0)
            {
                IgnoreGround();
            }
            else if (rigid.velocity.y < 0)
            {
                NotIgnoreGround();
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            downTimer = 0.5f;
        }

        if (downTimer > 0f)
        {
            downTimer -= Time.deltaTime;
            isDownLayer = true;
            playerJump.enabled = false;
            IgnoreGround();
        }
        else if (downTimer < 0f)
        {
            NotIgnoreGround();
            playerJump.enabled = true;
            isDownLayer = false;

            downTimer = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 direction = new Vector2(x, y);
        Run(direction);

        anim.SetFloat("HorizontalAxis", direction.x);

        if (x > 0)
        {
            Vector3 theScale = transform.localScale;
            if (!isfacingRight)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
                isfacingRight = true;
            }
        }

        if (x < 0)
        {
            Vector3 theScale = transform.localScale;
            if (isfacingRight)
            {
                theScale.x *= -1;
                transform.localScale = theScale;
                isfacingRight = false;
            }
        }
    }

    void Run(Vector2 dir)
    {
        rigid.velocity = new Vector2(dir.x * runSpeed, rigid.velocity.y);
    }

    void IgnoreGround()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
        Physics2D.IgnoreLayerCollision(playerLayer, slowGroundLayer, true);
        Physics2D.IgnoreLayerCollision(playerLayer, fastGroundLayer, true);
    }
    void NotIgnoreGround()
    {
        Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);
        Physics2D.IgnoreLayerCollision(playerLayer, slowGroundLayer, false);
        Physics2D.IgnoreLayerCollision(playerLayer, fastGroundLayer, false);
    }

    void OnCollisionEnter2D(Collision2D hitPlayer)
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        int slowgroundLayer = LayerMask.NameToLayer("SlowGround");
        int fastgroundLayer = LayerMask.NameToLayer("FastGround");
        if (hitPlayer.gameObject.layer == groundLayer)
        {
            isGround = true;
            playerJump.IsGround();
        }
        else if (hitPlayer.gameObject.layer == slowgroundLayer)
        {
            isGround = true;
            playerJump.IsGround();
            runSpeed -= 15;
        }
        else if (hitPlayer.gameObject.layer == fastgroundLayer)
        {
            isGround = true;
            playerJump.IsGround();
            runSpeed += 15;
        }
    }
    void OnCollisionExit2D(Collision2D hitPlayer)
    {
        int groundLayer = LayerMask.NameToLayer("Ground");
        int slowgroundLayer = LayerMask.NameToLayer("SlowGround");
        int fastgroundLayer = LayerMask.NameToLayer("FastGround");
        if (hitPlayer.gameObject.layer == groundLayer)
        {
            isGround = false;
            playerJump.IsNotGround();
        }
        else if (hitPlayer.gameObject.layer == slowgroundLayer)
        {
            isGround = false;
            playerJump.IsNotGround();
            runSpeed += 15;
        }
        else if (hitPlayer.gameObject.layer == fastgroundLayer)
        {
            isGround = false;
            playerJump.IsNotGround();
            runSpeed -= 15;
        }

    }
    [SerializeField]
    InGameUI gameUI;
    void Scene2()
    {
        SceneManager.LoadScene("GameScene2");
    }
    void Scene3()
    {
        SceneManager.LoadScene("GameScene3");
    }
    void Scene4()
    {
        SceneManager.LoadScene("GameScene4");
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Portal1"))
        {
            gameUI.Plustitle();
            gameUI.StartTitle();
            Invoke("Scene2", 4);
        }
        if (collision.gameObject.CompareTag("Portal2"))
        {
            gameUI.Plustitle();
            gameUI.StartTitle();
            Invoke("Scene3", 4);
        }
        if (collision.gameObject.CompareTag("Portal3"))
        {
            gameUI.Plustitle();
            gameUI.StartTitle();
            Invoke("Scene4", 4);
        }
        
    }

    
}
