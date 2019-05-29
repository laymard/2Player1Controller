
using UnityEngine;

public enum EPlayerID
{
    EPlayer1,
    EPlayer2
}
public class PlayerController : MonoBehaviour
{
    //public properties
    public EPlayerID PlayerID;

    public Material[] materials;

    private int index;
    private MeshRenderer _meshRenderer;

    private Vector2 m_inputDirection;
    private string inputVerticalDirection;
    private string inputHorizontalDirection;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        _meshRenderer = GetComponent<MeshRenderer>();

        // input
        inputVerticalDirection = PlayerID == EPlayerID.EPlayer1 ? "Player1_Vertical" : "Player2_Vertical";
        inputHorizontalDirection = PlayerID == EPlayerID.EPlayer1 ? "Player1_Horizontal" : "Player2_Horizontal";
    }

    // Update is called once per frame
    void Update()
    {
        if (IsActionButtonDown())
        {
            SwitchMaterial();
        }
    }

    private void FixedUpdate()
    {
        UpdateInputDirection();
    }

    private bool IsActionButtonDown()
    {
        string ButtonName = PlayerID == EPlayerID.EPlayer1 ? "Player1_Action" : "Player2_Action";

        return Input.GetButtonDown(ButtonName);
    }

    private void SwitchMaterial()
    {
        int nextIndex;
        nextIndex = (index + 1) % materials.Length;

        Material nextMaterial = materials[nextIndex];
        _meshRenderer.material = nextMaterial;

        index = nextIndex;
    }

    private void UpdateInputDirection()
    {
        float verticalDirection = Input.GetAxis(inputVerticalDirection);
        float horizontalDirection = Input.GetAxis(inputHorizontalDirection);

        /// xbox controller specific
        verticalDirection *= -1.0f;

        m_inputDirection.Set(horizontalDirection, verticalDirection);
    }

    public Vector2 GetInputDirection()
    {
        return m_inputDirection;
    }
}
