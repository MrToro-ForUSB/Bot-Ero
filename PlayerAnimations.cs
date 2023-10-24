using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerAnimations : MonoBehaviour
{
    private Player player;


    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        player.AttachedAnimator.SetFloat("Velocity", player.Velocity);
        player.AttachedAnimator.SetBool("IsShooting", InputManager.IsShootingPressed);
    }
}
