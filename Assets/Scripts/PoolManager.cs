using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Start is called before the first frame update
    //������ ������ ����
    public GameObject[] prefabs;

    //Ǯ ����� �ϴ� ����Ʈ
    List<GameObject>[] pools;

    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < pools.Length; i++){
            pools[i] = new List<GameObject>();
        }
        Debug.Log(pools.Length);
    }

}
