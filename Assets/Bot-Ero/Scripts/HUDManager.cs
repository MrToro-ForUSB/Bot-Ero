using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [Serializable]
    private struct Life
    {
        public Slider bar;
        public List<Image> images;
        public List<GameObject> icons;
        public Color primaryColor;
        public Color blackColor;
    }

    [Serializable]
    private struct Energy
    {
        public Slider bar;
        public TextMeshProUGUI textMP;
    }

    // [Serializable]
    // private struct Enemy
    // {
    //     public CanvasGroup group;
    //     public Slider bar;
    //     public TextMeshProUGUI textMP;
    // }



    public static HUDManager Instance { get; private set; }

    [SerializeField, TitleGroup("Player Stats")]
    private Player player;

    [SerializeField, BoxGroup("HUD Elements: Life")]
    private Life life;

    [SerializeField, BoxGroup("HUD Elements: Energy"), Space]
    private Energy energy;

    // [SerializeField, BoxGroup("HUD Elements: Enemy"), Space]
    // private Enemy enemy;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }


    
    public void UpdateHUD()
    {
        life.bar.DOValue(((float)player.Stats.HealthPoints) / 10f, 1);

        for (int i = 0; i < life.icons.Count; i++)
        {
            life.images[i].color = life.blackColor;
            life.icons[i].SetActive(false);
        }

        for (int i = 0; i < player.Stats.Lifes; i++)
        {
            life.images[i].DOColor(life.primaryColor, 1);
            life.icons[i].SetActive(true);
        }

        energy.bar.DOValue(((float)player.Stats.VoidEnergyPoints) / 10f, 1);
        energy.textMP.text = $"Tienes {player.Stats.VoidFlowers} <b>Orquídeas del vacío</b>";
    }

    // public void UpdateHUD(EnemyStats enemyStats)
    // {   
    //     if (enemyStats.HealthPoints == 0)
    //         enemy.group.DOFade(0, 1.5f);
    //     else
    //         enemy.group.DOFade(1, 0.5f);

    //     enemy.bar.DOValue(((float)enemyStats.HealthPoints) / ((float)enemyStats.MaxHealthPoints), 0.25f);
    //     enemy.textMP.text = enemyStats.EnemyName;
    // }
}
