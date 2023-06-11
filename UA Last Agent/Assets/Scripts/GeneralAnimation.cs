using UnityEngine;

public class GeneralAnimation : MonoBehaviour
{
    private Animator cafeAnimator;
    [SerializeField] private float drinkChance = 0f;
    private bool repeat = true;
    private void Awake()
    {
        cafeAnimator= GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        AnimatorStateInfo stateInfo = cafeAnimator.GetCurrentAnimatorStateInfo(0);
        if (repeat && stateInfo.IsName("IdleGenerealCafe") && stateInfo.normalizedTime >= 1f)
        {
            repeat = false;
            if (Random.value < drinkChance)
            {
                cafeAnimator.SetTrigger("drink");
                repeat = true;
            }
            else
            {
                cafeAnimator.SetTrigger("idle");
                repeat = true;
            }
        }
        if (stateInfo.IsName("Drink1GeneralCafe") && stateInfo.normalizedTime >= 1f)
        {
            cafeAnimator.SetTrigger("idle");
        }
    }
}