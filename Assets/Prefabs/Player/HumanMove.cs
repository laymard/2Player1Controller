using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : MonoBehaviour
{
    public float MaxSpeed;

    private PlayerController m_PlayerController;
    private Rigidbody m_Rigidbody;

    private Vector3 MoveDirection;
    private Vector3 LookDirection;

    // Start is called before the first frame update
    void Start()
    {
        m_PlayerController = GetComponent<PlayerController>();
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMoveDirection();
        ApplySpeed();
    }

    private Vector2 GetInputDirection()
    {
        return m_PlayerController.GetInputDirection();
    }

    /// <summary>
    /// Transform the input from pad to camera space
    /// </summary>
    private void UpdateMoveDirection()
    {
        Vector2 inputDirection = GetInputDirection();

        MoveDirection.Set(inputDirection.x, 0.0f, inputDirection.y);

        float yCameraAngle = Camera.main.transform.rotation.eulerAngles.y;

        MoveDirection = Quaternion.AngleAxis(yCameraAngle, Vector3.up) * MoveDirection;
    }

    private void ApplySpeed()
    {
        /// apply velocity
        Vector3 velocity = MoveDirection * MaxSpeed;
        m_Rigidbody.velocity = velocity;

        /// change orientation only if player is moving
        if (MoveDirection.sqrMagnitude > 0.0f)
        {
            Quaternion rotation = Quaternion.LookRotation(MoveDirection, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
