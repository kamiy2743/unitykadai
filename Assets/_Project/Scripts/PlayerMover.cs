using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float moveSpeed;
    private Rigidbody rigidbody;

    private InputAction moveAction;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        moveAction = playerInput.currentActionMap["Move"];
    }

    // Update is called once per frame
    void Update()
    {
        var inputVector = moveAction.ReadValue<Vector2>().normalized;
        var moveVector = new Vector3(inputVector.x * moveSpeed, -9.8f, inputVector.y * moveSpeed);

        rigidbody.velocity = moveVector;
    }
}
