using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    PlayerCamera playerCamera;
    [SerializeField]
    GameManger gameManger;

    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    SpriteRenderer spriteRenderer;   
    [SerializeField]
    Animator anim;

    [SerializeField]
    List<GameObject> healthImages = new List<GameObject>();

    [SerializeField]
    float hitCoolTimer = -0.1f;

    //[SerializeField]
    //int maxHealth = 5;
    [SerializeField]
    int minHealth = 1;
    [SerializeField]
    int currentHealth;

    bool isDie;

    void Start()
    {
        currentHealth = 5;
    }

    void Update()
    {
       
        healthImages[currentHealth].SetActive(true);
        
        if (currentHealth < minHealth)
        {
            if (!isDie)         
                Die();
            
            return;
        }
        if (hitCoolTimer > 0)
            hitCoolTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (currentHealth < minHealth)        
            return;

    }

    void ThornHitJudement(Collision2D hitPlayer)
    {
        //수정필요
        Vector2 attackedVelocity = Vector2.zero;
        Vector2 direction = hitPlayer.transform.position - transform.position;

        if (direction.x > 0)
        {
            attackedVelocity = new Vector2(-10f, 40f);
        }
        else if (direction.x < 0)
        {
            attackedVelocity = new Vector2(10f, 40f);
        }
        else
        {
            attackedVelocity = new Vector2(10f, 40f);
        }

        rigid.AddForce(attackedVelocity, ForceMode2D.Impulse);


        currentHealth--;

        if (currentHealth > 0)
            healthImages[currentHealth + 1].SetActive(false);
        else if (currentHealth == 0)
            healthImages[currentHealth].SetActive(false);

        playerCamera.ShakeCamera(1f);
        

        if (currentHealth > minHealth)
        {
            StartCoroutine(UnBeatTime());
        }
    }
       
    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 100);
            }

            yield return new WaitForSeconds(0.3f);

            countTime++;
        }
        spriteRenderer.color = new Color32(255,255,255,255);

        yield return null;
    }

    void Die()
    {
        isDie = true;



        //anim.SetTrigger("isDie");

        //사망 애니메이션 고려
        Invoke("RestartStage", 1f);
    }

    void RestartStage()
    {
        gameManger.RestartStage();
    }
    
    void OnTriggerEnter2D(Collider2D hitPlayer)
    {
        if (hitPlayer.gameObject.CompareTag("Bottom"))
        {
            currentHealth = 0;
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D hitPlayer)
    {
        if (hitPlayer.gameObject.CompareTag("Thorn") && hitCoolTimer <= 0)
        {
            hitCoolTimer = 0.5f;
            ThornHitJudement(hitPlayer);
        }        
    }
}
