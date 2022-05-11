using UnityEngine;
using UnityEngine.Events;

namespace Object_Behaviour
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class TriggerEvent : MonoBehaviour
    {
        public string targetTag;
        public UnityEvent onTrigger;
        public UnityEvent<GameObject> onTriggerWithGameObject;

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            // Debug.Log(col.gameObject.name);
            // Debug.Log("collider tag: " + col.tag + " hits target tag: " + targetTag);
            // ReSharper disable once Unity.ExplicitTagComparison
            if (col.tag == targetTag)
            {    
                // Debug.Log("Collider hits right tag " + targetTag);
                onTrigger?.Invoke();
                onTriggerWithGameObject?.Invoke(col.gameObject);
            }
        }
    }
}
