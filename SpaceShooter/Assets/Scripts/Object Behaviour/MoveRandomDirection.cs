using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Object_Behaviour
{
    [RequireComponent(typeof(Moveable))]
    public class MoveRandomDirection : MonoBehaviour
    {
        private Moveable _moveable;
        private void Awake()
        {
            _moveable = GetComponent<Moveable>();
        }
        // Start is called before the first frame update
        void Start()
        {
            _moveable.SetDirection(RandomDirection(), RandomDirection());
        }

        private float RandomDirection()
        {
            return Random.Range(-1f, 1);
        }
    }
}
