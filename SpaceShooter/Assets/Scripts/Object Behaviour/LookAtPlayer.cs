using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        LookAt();
    }
    private void LookAt()
    {
        if (GameManager.GetInstance().activePlayer != null)
        {
            transform.up = GameManager.GetInstance().activePlayer.transform.position - transform.position;
        }
    }
}