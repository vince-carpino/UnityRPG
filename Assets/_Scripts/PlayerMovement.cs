using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    private float originalForwardMoveSpeed = 7.5f;
    [SerializeField]
    private float originalBackwardMoveSpeed = 3f;
    [SerializeField]
    private float forwardMoveSpeed = 7.5f;
    [SerializeField]
    private float backwardMoveSpeed = 3;
    [SerializeField]
    private float forwardSprintSpeed = 10f;
    [SerializeField]
    private float backwardSprintSpeed = 5f;
    [SerializeField]
    private float turnSpeed = 150;

    private CharacterController characterController;
    private Animator animator;

    void Awake() {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        forwardMoveSpeed = originalForwardMoveSpeed;
        backwardMoveSpeed = originalBackwardMoveSpeed;
    }

    void Update() {
        var horizontal = Input.GetAxis("Mouse X");
        var vertical = Input.GetAxis("Vertical");

        var movement = new Vector3(horizontal, 0, vertical);

        animator.SetFloat("Speed", vertical);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if (vertical != 0) {
            var moveSpeedToUse = vertical > 0 ? forwardMoveSpeed : backwardMoveSpeed;
            characterController.SimpleMove(transform.forward * moveSpeedToUse * vertical);
        }

        ChangeMovementSpeedOnSprint();
    }

    private void ChangeMovementSpeedOnSprint() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            forwardMoveSpeed = forwardSprintSpeed;
            backwardMoveSpeed = backwardSprintSpeed;
        } else {
            forwardMoveSpeed = originalForwardMoveSpeed;
            backwardMoveSpeed = originalBackwardMoveSpeed;
        }
    }

    public void SetTurnSpeed(float speed) {
        turnSpeed *= speed;
    }
}
