using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private CinemachineVirtualCamera playerCamera;
    [SerializeField] private EnemyDetector enemyDetector;
    [SerializeField] private float moveSpeed;

    private Rigidbody rigidbody;
    private InputAction moveAction;
    private CinemachinePOV cinemachinePOV;

    public float RotateY => cinemachinePOV.m_HorizontalAxis.Value;

    public void StartInitial(Vector3 startPosition)
    {
        rigidbody = GetComponent<Rigidbody>();
        moveAction = playerInput.currentActionMap["Move"];
        cinemachinePOV = playerCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>();

        enemyDetector.OnDetect.AddListener(Dispose);

        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalMoveVector = moveAction.ReadValue<Vector2>().normalized * moveSpeed;
        var horizontalRotation = Quaternion.Euler(0, RotateY, 0);
        var moveVector = horizontalRotation * new Vector3(horizontalMoveVector.x, -9.8f, horizontalMoveVector.y);

        rigidbody.velocity = moveVector;
    }

    public void Dispose()
    {
        playerCamera.enabled = false;
        rigidbody.velocity = Vector3.zero;
        this.enabled = false;
    }
}
