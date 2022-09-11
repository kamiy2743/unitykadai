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

    public Vector2Int Coordinate => new Vector2Int(Mathf.FloorToInt(transform.position.x * MapObjectConstructor.StageScale), MapData.Height - 1 - Mathf.FloorToInt(transform.position.z * MapObjectConstructor.StageScale));

    private Rigidbody rigidbody;
    private InputAction moveAction;
    private CinemachinePOV cinemachinePOV;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        moveAction = playerInput.currentActionMap["Move"];
        cinemachinePOV = playerCamera.GetCinemachineComponent(CinemachineCore.Stage.Aim).GetComponent<CinemachinePOV>();

        enemyDetector.OnDetect.AddListener(GameOver);
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalMoveVector = moveAction.ReadValue<Vector2>().normalized * moveSpeed;
        var horizontalRotation = Quaternion.Euler(0, cinemachinePOV.m_HorizontalAxis.Value, 0);
        var moveVector = horizontalRotation * new Vector3(horizontalMoveVector.x, -9.8f, horizontalMoveVector.y);

        rigidbody.velocity = moveVector;
    }

    private void GameOver()
    {
        playerCamera.enabled = false;
        rigidbody.velocity = Vector3.zero;
        this.enabled = false;
    }
}
