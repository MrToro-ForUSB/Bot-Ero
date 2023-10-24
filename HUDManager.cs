using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public Slider HealthBar;
    public Slider EnergyBar;
    public List<Image> lifeIcons;
    public TextMeshProUGUI energyFullTMP;
    public TextMeshProUGUI voidFlowersTMP;



    private void Start()
    {
        UpdateHUD();
    }



    private void UpdateHUD()
    {
        voidFlowersTMP.text = $"Tienes {Player.Instance.Stats.VoidFlowersCount} flores del vacío.";
        HealthBar.value = Player.Instance.Stats.HealthPoints / 10f;
        EnergyBar.value = Player.Instance.Stats.EnergyPoints / 10f;
        energyFullTMP.gameObject.SetActive(Player.Instance.Stats.EnergyPoints >= 10);

        for (int i = 0; i < 3; i++)
        {
            lifeIcons[i].color = new(
                lifeIcons[i].color.r,
                lifeIcons[i].color.g,
                lifeIcons[i].color.b,
                0
            );
        }

        for (int i = 0; i < Player.Instance.Stats.Life; i++)
        {
            lifeIcons[i].color = new(
                lifeIcons[i].color.r,
                lifeIcons[i].color.g,
                lifeIcons[i].color.b,
                1
            );
        }
    }
}
