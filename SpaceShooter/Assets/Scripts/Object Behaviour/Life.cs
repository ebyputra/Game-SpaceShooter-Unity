using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [HideInInspector] public int life;
    [HideInInspector] public int maxLife;

    [HideInInspector] public ScriptableInteger lifeScriptable;
    [HideInInspector] public ScriptableInteger maxLifeScriptable;

    [HideInInspector] public bool useScriptable;

    public UnityEvent onLifeReachZero;

    public void OnHit()
    {
        if (useScriptable)
        {
            lifeScriptable.value = lifeScriptable.value - 1 < 0 ? 0 : lifeScriptable.value - 1;

            if (lifeScriptable.value <= 0)
            {
                // call even reach hp value 0
                onLifeReachZero?.Invoke();
            }
        }
        else
        {
            life = life - 1 < 0 ? 0 : life - 1;

            if (life <= 0)
            {
                // call even reach hp value 0
                onLifeReachZero?.Invoke();
            }
        }
    }

    public void OnGain()
    {
        if (useScriptable)
        {
            lifeScriptable.value = lifeScriptable.value++ > maxLifeScriptable.value++
                ? maxLifeScriptable.value
                : lifeScriptable.value++;
        }
        else
        {
            life = life++ > maxLife ? maxLife : life++;
        }
    }
}