using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // Start is called before the first frame update
    //프리펩 보관할 변수
    public GameObject[] prefabs;

    //풀 담당을 하는 리스트
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
