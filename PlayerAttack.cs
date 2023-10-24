using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Mathematics;
using System;

[RequireComponent(typeof(Player))]
public class PlayerAttack : MonoBehaviour
{
    private Player player;

    private AudioSource audioSource;

    [SerializeField, Header("Shooting")]
    private GameObject highRangeShotPrefab;
    [SerializeField]
    private GameObject lowRangeShotPrefab;
    [SerializeField]
    private Transform gunMuzzle;
    [SerializeField]
    private List<AudioClip> audioClips;

    private bool isHighRange = true;


    public bool IsHighRange { get => isHighRange; set => isHighRange = value; }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();
        player.Attack = this;
    }

    private void Start()
    {
        player.OnFire.AddListener(InstantiateShot);
    }

    private void Update()
    {
        if (InputManager.IsSwitchPressed)
        {
            isHighRange = !isHighRange;
            HUDManager.Instance.UpdateHUD();
        }
    }


    public void TryShoot(int shots)
    {
        StartCoroutine(Fire(shots));
    }

    private IEnumerator Fire(int shots)
    {
        audioSource.PlayOneShot(audioClips[UnityEngine.Random.Range(0, audioClips.Count)]);

        while (shots > 0)
        {
            shots--;
            player.OnFire.Invoke();

            yield return new WaitForFixedUpdate();
        }
    }

    private void InstantiateShot()
    {
        GameObject prefab = isHighRange ? highRangeShotPrefab : lowRangeShotPrefab;
        GameObject instance = Instantiate(prefab, gunMuzzle);
        instance.transform.SetParent(null);
    }
}
