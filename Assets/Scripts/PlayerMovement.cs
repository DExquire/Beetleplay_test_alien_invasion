using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f;
    public float rotationSpeed = 180f;
    public Transform model;

    public FighterAnimationDemoFREE animationControl;

    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement, Space.Self);

        if (movement != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            model.rotation = Quaternion.RotateTowards(model.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (horizontalInput != 0 || verticalInput != 0)
        {
            animationControl.WalkAnim();
        }
        else
        {
            animationControl.animator.SetBool("Walk Backward", false);
        }
    }
}
