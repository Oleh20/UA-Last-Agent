using UnityEngine;

public class GeneralAnimation : MonoBehaviour
{
    private Animator cafeAnimator;
    [SerializeField] private float timeBeforeDrinkAnimation;
    private void Awake()
    {
        cafeAnimator= GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = cafeAnimator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("IdleGenerealCafe") && stateInfo.normalizedTime >= timeBeforeDrinkAnimation)
        {
                cafeAnimator.SetTrigger("drink");
        }
        if (stateInfo.IsName("Drink1GeneralCafe") && stateInfo.normalizedTime >= 1f)
        {
            cafeAnimator.SetTrigger("idle");
        }
    }
}