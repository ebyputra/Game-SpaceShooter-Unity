using System.Collections;
using UnityEngine;

public class InvisibleFrame : MonoBehaviour
{
    public float duration;

    private float _timer;
    void Start()
    {

    }


    void Update()
    {
        _timer = _timer - Time.deltaTime < 0 ? 0 : _timer - Time.deltaTime;
    }

    public void Activate()
    {
        _timer = duration;
        StartCoroutine(Blinking());
        DeactivateCollider();
    }
    private IEnumerator Blinking()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Color defaultColor = sr.color;
        Color hitColor = defaultColor;
        hitColor.a = 0.5f;

        while (_timer > 0)
        {
            sr.color = hitColor;
            yield return new WaitForSeconds(0.1f);
            // ReSharper disable once Unity.InefficientPropertyAccess
            sr.color = defaultColor;
            yield return new WaitForSeconds(0.1f);
        }
        sr.color = defaultColor;
        ActivateCollider();
    }
    private void ActivateCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }
    private void DeactivateCollider()
    {
        GetComponent<Collider2D>().enabled = false;
    }
}