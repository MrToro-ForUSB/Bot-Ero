using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public PlayerStats Stats { get; set; }
    // public CharacterController AttachedCharacterController { get; private set; }
    // public Animator AttachedAnimator { get; private set; }


    // public float Velocity { get; set; }
    // public bool IsPointing { get; set; }
    // public float PointingWeight { get; set; }
    // public UnityEvent OnFire { get; private set; } = new();
    // public UnityEvent<int> OnProtect { get; private set; } = new();



    private void Awake()
    {
        DOTween.SetTweensCapacity(2000, 100);

        // AttachedCharacterController = GetComponent<CharacterController>();
        // AttachedAnimator = GetComponent<Animator>();
    }
}
