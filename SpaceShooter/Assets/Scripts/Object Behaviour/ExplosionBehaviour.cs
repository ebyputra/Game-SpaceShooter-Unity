using UnityEngine;

namespace Object_Behaviour
{
    public class ExplosionBehaviour : MonoBehaviour
    {
        private Animator _animator;
        private PoolObject _poolObject;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _poolObject = GetComponent<PoolObject>();
        }

        void Update()
        {
            if (_poolObject.IsActive())
            {
                if (AnimationIsDone())
                {
                    _poolObject.Deactivate();
                }
            }
        }
        private bool AnimationIsDone()
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !_animator.IsInTransition(0))
            {
                return true;
            }
            return false;
        }
    } 
}