using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private Player player;
    private Camera mainCamera;


    [SerializeField, Range(0, 10), Header("Movement")]
    private float movementSpeed = 1;
    [SerializeField, Range(0, 720)]
    private int angularSpeed = 180;


    private Vector3 gravityForce = new(0, -9.8f, 0);
    private Vector3 inputs;
    private Vector3 direction;
    private Vector3 velocity;
    private float angularVelocity;


    private void Start()
    {
        player = GetComponent<Player>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        LoadInputs();
        MoveAndTurn();
    }

    private void OnDestroy()
    {
        player.Velocity = 0;
    }


    private void LoadInputs()
    {
        inputs.x = InputManager.HorizontalInput;
        inputs.z = InputManager.VerticalInput;
        direction = Vector3.MoveTowards(direction, inputs, Time.deltaTime * 3);
    }

    private void MoveAndTurn()
    {
        // C�lculo de la direcci�n de la velocidad
        velocity = direction.z * mainCamera.transform.forward + direction.x * mainCamera.transform.right;

        if (velocity.magnitude > 1)
            velocity.Normalize();

        // C�lculo de la velocidad
        velocity = transform.InverseTransformDirection(velocity);
        angularVelocity = Mathf.Atan2(velocity.x, velocity.z) * angularSpeed * Time.deltaTime;
        velocity = transform.forward * velocity.magnitude * movementSpeed;
        player.Velocity = velocity.magnitude;

        // C�lculo de la gravedad
        velocity += gravityForce;

        player.AttachedCharacterController.Move(velocity * Time.deltaTime);
        transform.Rotate(0f, angularVelocity, 0f);
    }
}
