using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int Life { get; set; } = 2;
    public float HealthPoints { get; set; } = 7;
    public float EnergyPoints { get; set; } = 0;
    public int VoidFlowersCount { get; set; } = 3;
}
