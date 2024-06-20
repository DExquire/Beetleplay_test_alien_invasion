using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    public FighterAnimationDemoFREE animationControl;
    public float moveSpeed = 5f;

    public Joystick joystick;

    void Update()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        transform.position += new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed * Time.deltaTime;

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            animationControl.WalkAnim();
        }
        else
        {
            animationControl.animator.SetBool("Walk Backward", false);
        }
    }
}
