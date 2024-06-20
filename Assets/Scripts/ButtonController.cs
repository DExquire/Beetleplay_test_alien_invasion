using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button animButton;
    public Animator playerAnimator;

    private void Start()
    {
        if (animButton == null)
            animButton = GetComponent<Button>();

        if (playerAnimator == null)
            playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        bool isAttacking = stateInfo.IsName("Punch");

        animButton.interactable = !isAttacking;
    }
}
