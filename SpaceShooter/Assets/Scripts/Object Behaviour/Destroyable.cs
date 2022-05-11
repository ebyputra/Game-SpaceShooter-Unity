using UnityEngine;

namespace Object_Behaviour
{
    public class Destroyable : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
