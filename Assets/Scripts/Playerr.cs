using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerr : MonoBehaviour
{
    public float speed; // 플레이어 이동속도
    public Vector2 inputVec;
    public int pHealth;//현재체력
    public int maxpHealth;//최대체력
    Rigidbody2D pRigid;
    SpriteRenderer pSprite;
    
    // 컴포넌트 가져오기
    private void Awake()
    {
        pRigid = GetComponent<Rigidbody2D>();
        pSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        pRigid.MovePosition(pRigid.position + nextVec);
    }

    private void LateUpdate()
    {
        if(inputVec.x != 0)
        {
            pSprite.flipX = inputVec.x < 0;
        }
    }
    private void OnEnable()
    {
       
        maxpHealth = 1000;
        pHealth = maxpHealth;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster"))
            return;
       


        pHealth -= collision.GetComponent<Monster>().mDamage;


        if (pHealth > 0)
        {

        }
        else
        {
            Dead();
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
