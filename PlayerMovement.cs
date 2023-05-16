using UnityEngine;
using UnityEngine.InputSystem;

/**class PlayerMovement
 * Handles all the movement code for the player object.
 */
public class PlayerMovement : MonoBehaviour {
    private float playerSpeed = 0;
    private float playerTurnSpeed = 0;

    private PlayerInput playerControls;
    private InputAction move;
    private Vector2 moveDirection = Vector2.zero;

    private void Awake() {
        playerControls = new PlayerInput();
    }

    /**MovementSetup()
     * Called on instantiation in Playerinit
     * Takes stats from the playerStats arg
     */
    public void MovementSetup(PlayerStatsSO playerStats) {
        playerSpeed = playerStats.speed;
        playerTurnSpeed = playerStats.turnSpeed;
        move = playerControls.Player.Movement;
        move.Enable();
    }

    private void OnDisable() {
        playerSpeed = 0;
        playerTurnSpeed = 0;
        move.Disable();
    }
    //Basic Unity movement code
    public void turnLeft() {
        transform.Rotate(Vector3.forward * playerTurnSpeed);
    }
    public void turnRight() {
        transform.Rotate(Vector3.back * playerTurnSpeed);
    }

    public void Update() {
        moveDirection.x = move.ReadValue<Vector2>().x;
    }

    public void FixedUpdate() {
        if(moveDirection.x == -1) {
            turnLeft();
        }
        if(moveDirection.x == 1) {
            turnRight();
        }
        transform.position += transform.up * Time.deltaTime * playerSpeed;
    }
}
