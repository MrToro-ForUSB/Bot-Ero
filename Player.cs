using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }
    public PlayerStats Stats { get; set; }



    private void Awake()
    {
        Instance = (Instance == null) ? this : Instance;
        Stats = GetComponent<PlayerStats>();
    }
}
