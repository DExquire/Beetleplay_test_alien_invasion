using UnityEngine;

public class FighterAnimationDemoFREE : MonoBehaviour {
	
	public Animator animator;


	public void AttackAnim()
    {
		animator.SetTrigger("PunchTrigger");
	}

	public void WalkAnim()
    {
		animator.SetBool("Walk Backward", true);
	}
}