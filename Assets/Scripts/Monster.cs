using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ִϸ��̼� ������ sprite flip ���� ����
public class Monster : MonoBehaviour
{
    public float mSpeed;
    public Rigidbody2D target;

    private float distance;
    private Vector2 currentPosition;
    private bool isLive; // ��������
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
        distance = Vector2.Distance(target.position, mRigid.position); // �÷��̾�� ������ �Ÿ��� ���
        
        //���� �Ÿ� �̻��� ���� ����
        if(distance< 3)
        {
            Vector2 dirVec = target.position - mRigid.position; // �÷��̾��� ��ġ - ������ ��ġ = ���� ����
            Vector2 nextVec = dirVec.normalized * mSpeed * Time.fixedDeltaTime; // ������ normalized, �ӵ��� �°� �̵��� ��ġ�� ���
            mRigid.MovePosition(mRigid.position + nextVec); // ���� ������ ��ġ���� ���� ��ġ�� �̵�
            mRigid.velocity = Vector2.zero; // ��ġ�� �ٲ��ִ� �̵��̱� ������ �ӵ��� ������ ���� �ʱ� �ϱ� ���� 0���� �ʱ�ȭ
            mSprite.flipX = target.position.x < mRigid.position.x; // ���� ��ȯ�� ���� ��� ��ȭ
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
                mSprite.flipX = currentPosition.x < mRigid.position.x; // ���� ��ȯ�� ���� ��� ��ȭ
            }
        }
    }

}
