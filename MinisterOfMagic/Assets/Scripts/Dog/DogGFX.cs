using UnityEngine;
using Pathfinding;

public class DogGFX : MonoBehaviour
{
    public AIPath aIPath;

    private Animator animator;

    [SerializeField] private float changeDirectionForce;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 dir = Vector2.zero;
        if (aIPath.desiredVelocity.x <= changeDirectionForce)
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (aIPath.desiredVelocity.x >= -changeDirectionForce)
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }
 
        if (aIPath.desiredVelocity.y >= changeDirectionForce)
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (aIPath.desiredVelocity.y <= -changeDirectionForce)
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);
    }
}
