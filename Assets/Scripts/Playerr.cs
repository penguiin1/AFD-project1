using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playerr : MonoBehaviour
{
    public float speed; // 플레이어 이동속도
    public Vector2 inputVec;

    Rigidbody2D pRigid;
    SpriteRenderer pSprite;
    
    // 컴포넌트 가져오기
    private void Awake()
    {
        pRigid = GetComponent<Rigidbody2D>();
        pSprite = GetComponent<SpriteRenderer>();
    }

    // 위치이동으로 구현
    private void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        pRigid.MovePosition(pRigid.position + nextVec);
    }

    private void LateUpdate()
    {
        if(inputVec.x != 0)
        {
            pSprite.flipX = inputVec.x > 0;
        }
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
