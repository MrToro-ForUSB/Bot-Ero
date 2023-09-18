using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Player))]
public class PlayerStats : MonoBehaviour
{
    private Player player;

    public int Lifes { get; set; } = 1;
    public int HealthPoints { get; private set; } = 7;
    public int VoidEnergyPoints { get; private set; } = 0;
    public int VoidFlowers { get; private set; } = 0;

    // private bool isProtected;




    private void Awake()
    {
        player = GetComponent<Player>();
        player.Stats = this;
    }
    private void Start()
    {
        HUDManager.Instance.UpdateHUD();
    }



    // public void AddVoidFlower()
    // {
    //     VoidFlowers++;

    //     if (VoidFlowers % 10 == 0)
    //     {
    //         Heal(false);
    //     }

    //     HUDManager.Instance.UpdateHUD();
    // }
    // public void AddVoidEnergyPoints(int value)
    // {
    //     VoidEnergyPoints += value;
    //     VoidEnergyPoints = Mathf.Clamp(VoidEnergyPoints, 0, 10);
        
    //     HUDManager.Instance.UpdateHUD();
    // }
    // public void AddHealthPoints(int value)
    // {
    //     if (HealthPoints == 0)
    //         return;

    //     if (isProtected)
    //         return;

    //     HealthPoints += value;
    //     HealthPoints = Mathf.Clamp(HealthPoints, 0, 10);

    //     if (HealthPoints == 0)
    //     {
    //         Lifes--;
            
    //         if (Lifes < 0)
    //         {
    //             SceneManager.LoadScene(0);
    //             return;
    //         }

    //         TryProtect(5, true);
    //     }
    //     else
    //     {
    //         TryProtect(1, false);
    //     }

    //     HUDManager.Instance.UpdateHUD();
    // }

    // public void Heal(bool update)
    // {
    //     Lifes++;
    //     Lifes = Mathf.Clamp(Lifes, 0, 3);
    //     HealthPoints = 10;

    //     if (update)
    //         HUDManager.Instance.UpdateHUD();
    // }
    
    // private void TryProtect(int time, bool heal)
    // {
    //     if (isProtected)
    //         return;

    //     StartCoroutine(Protect(time, heal));
    // }

    // private IEnumerator Protect(int time, bool heal)
    // {
    //     isProtected = true;
    //     player.OnProtect.Invoke(time);

    //     yield return new WaitForSeconds(time);

    //     if (heal) {
    //         HealthPoints = 10;
    //         HUDManager.Instance.UpdateHUD();
    //     }

    //     isProtected = false;
    // }
}
