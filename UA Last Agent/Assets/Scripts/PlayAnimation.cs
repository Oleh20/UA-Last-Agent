using UnityEngine;
using UnityEngine.UI;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject AnimationObject;

    public void PlayAnimationOnClick()
    {
        animator.SetTrigger("PlayAnimation");
    }
    public void ExcludeObject()
    {
        AnimationObject.SetActive(false);
    }
}
