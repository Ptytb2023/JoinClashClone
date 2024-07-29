using UnityEditor.Animations;
using UnityEngine;

namespace CompositionRoot.Extensions
{

    public static class AnimatorExtensions 
    {
        public static GameObject BindController(this Animator animator, AnimatorController controller)
        {
            animator.runtimeAnimatorController = controller;
            return animator.gameObject;
        }
    }
}