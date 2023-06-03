using UnityEngine;

public class AnimationController : MonoBehaviour
{

    void Awake()
    {
        Animator animator = GetComponent<Animator>();
        animator.Update(Random.value);
        animator.speed = Mathf.Clamp(Random.value, 0.4f, 1f);
    }

}
