using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float mSpeed;
    public Rigidbody2D target;

    private bool isLive; // 생존여부
    private Rigidbody2D mRigid;
    private SpriteRenderer mSprite;
    void Awake()
    {
        mRigid = GetComponent<Rigidbody2D>();
        mSprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 dirVec = target.position - mRigid.position;
        Vector2 nextVec = dirVec.normalized * mSpeed * Time.fixedDeltaTime;
        mRigid.MovePosition(mRigid.position + nextVec);
        mRigid.velocity = Vector2.zero;
    }

    private void LateUpdate()
    {
        mSprite.flipX = target.position.x < mRigid.position.x;
    }
}
