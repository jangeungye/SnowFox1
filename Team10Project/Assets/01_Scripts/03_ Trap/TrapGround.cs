using UnityEngine;

public class TrapGround : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;

    bool isStep;

    float Timer;

    [SerializeField]
    int speed;

    void FixedUpdate()
    {
        if (isStep)
        {
            Vector2 newVelocity = new Vector2(0, rigid.velocity.y * -speed * Time.deltaTime);
            rigid.velocity = Vector2.Lerp(rigid.velocity, newVelocity, speed);
        }

        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (Timer < 0)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D stepPlayer)
    {
        if (stepPlayer.gameObject.CompareTag("Player"))
        {
            print("yes");
            isStep = true;
            Timer = 3f;
        }
    }
}
