using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 애니매이션 적용후 sprite flip 로직 보완
public class Monster : MonoBehaviour
{
    public float mSpeed;
    public Rigidbody2D target;

    private float distance;
    private Vector2 currentPosition;
    private bool isLive; // 생존여부
    private Rigidbody2D mRigid;
    private SpriteRenderer mSprite;
    void Awake()
    {
        mRigid = GetComponent<Rigidbody2D>();
        mSprite = GetComponent<SpriteRenderer>();
        currentPosition = mRigid.position; 
    }

    private void FixedUpdate()
    {
        distance = Vector2.Distance(target.position, mRigid.position); // 플레이어와 몬스터의 거리를 계산
        
        //일정 거리 이상일 때는 멈춤
        if(distance< 3)
        {
            Vector2 dirVec = target.position - mRigid.position; // 플레이어의 위치 - 몬스터의 위치 = 변위 벡터
            Vector2 nextVec = dirVec.normalized * mSpeed * Time.fixedDeltaTime; // 변위를 normalized, 속도에 맞게 이동할 위치를 계산
            mRigid.MovePosition(mRigid.position + nextVec); // 현재 몬스터의 위치에서 다음 위치로 이동
            mRigid.velocity = Vector2.zero; // 위치를 바꿔주는 이동이기 때문에 속도의 영향을 받지 않기 하기 위해 0으로 초기화
            mSprite.flipX = target.position.x < mRigid.position.x; // 방향 전환에 따른 모션 변화
        }
        else
        {
            Vector2 dirVec = currentPosition - mRigid.position;
            Vector2 nextvec = dirVec.normalized * mSpeed * Time.fixedDeltaTime;
            if (Vector2.Distance(mRigid.position, currentPosition) <=0.1)
            {

            }
            else
            {
                mRigid.MovePosition(mRigid.position+nextvec);
                mRigid.velocity = Vector2.zero;
                mSprite.flipX = currentPosition.x < mRigid.position.x; // 방향 전환에 따른 모션 변화
            }
        }
    }

}
