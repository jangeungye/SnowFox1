using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;//�¿� �̵��� ���� ������ �� ���� ������
    [SerializeField]
    Animator anim;//�ִϸ�����
  
    [SerializeField]
    int jumpForce;//���� �� 

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
        // �����̽��ٸ� ������ ������ isLongJump = true�� �ȴ�
        if (Input.GetKey(KeyCode.Space))
        {
            isLongJump = true;
        }
        // �����̽��ٿ��� �� ���� false���� �ȴ�.
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
        // ���� ������ ���� ������ ������ ���� �߷� ��� (gravityScale) ���� 
        if (isLongJump && rigid.velocity.y > 0 )//���� ����
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
