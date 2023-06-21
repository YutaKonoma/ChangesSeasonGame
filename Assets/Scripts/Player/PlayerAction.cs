using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    Player player;

    public void OnMove(InputAction.CallbackContext context)
    {
        float _moveInput = context.ReadValue<Vector2>().x;
        player.Move(_moveInput);
    }

    public void OnJunp(InputAction.CallbackContext context)
    {
            player.Jump();
    }

    public void OnChange(InputAction.CallbackContext context)
    {
        
    }
}
