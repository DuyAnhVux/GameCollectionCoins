using UnityEngine;
public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isJumpingHash;
    void Start()
    {
        animator = GetComponent<Animator>();
        isJumpingHash = Animator.StringToHash("isJumping");
    }
    void Update()
    {
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isPressedSpace = Input.GetKey("space");
        //Jumping
        if (!isJumping && isPressedSpace)
        {
            animator.SetBool(isJumpingHash, true);
        }
        if (isJumping && !isPressedSpace)
        {
            animator.SetBool(isJumpingHash, false);
        }
    }
}
