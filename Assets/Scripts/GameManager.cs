using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Playerr player;
    // Start is called before the first frame update
    public int mHealth;
    public int maxmHealth = 100;
    private void Awake()
    {
        instance = this;
    }
}
