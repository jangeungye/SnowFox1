using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;//좌우 이동은 현재 리지드 안 쓰임 점프만
    [SerializeField]
    Animator anim;//애니메이터
  
    [SerializeField]
    int jumpForce;//점프 힘 

    [SerializeField]
    float fallMultiplayer = 2;
    [SerializeField]
    float lowjumpMultiplayer = 1;

    bool isGround;
    bool isLongJump = false;

    void Update()
    {
        Jump();

        if (rigid.velocity.y < 0)
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplayer * Time.deltaTime;
        }
        if (rigid.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigid.velocity += Vector2.up * Physics2D.gravity.y * lowjumpMultiplayer * Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        JumpVelocity();        
    }
    void Jump()
    {
        if (isGround && InputManager.GetKeyDown(Key.Jump))
        {
            JumpAddForce();
        }
        // 스페이스바를 누르고 있으면 isLongJump = true가 된다
        if (Input.GetKey(KeyCode.Space))
        {
            isLongJump = true;
        }
        // 스페이스바에서 손 때면 false값이 된다.
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            isLongJump = false;
        }

    }
    void JumpAddForce()
    {
        rigid.velocity = Vector2.up * jumpForce;
        anim.SetBool("isJumping", true);
    }
    void JumpVelocity()
    {
        // 낮은 점프와 높은 점프를 구현을 위해 중력 계수 (gravityScale) 조절 
        if (isLongJump && rigid.velocity.y > 0 )//높이 제한
        {
            rigid.gravityScale = 3f;
        }
        else
        {
            rigid.gravityScale = 5f;
        }
    }
    public void IsGround()
    {
        isGround = true;
        anim.SetBool("isJumping", false);
    }
    public void IsNotGround()
    {
        isGround = false;
    }
    
    
}
