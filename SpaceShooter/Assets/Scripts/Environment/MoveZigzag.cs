using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Moveable))]
public class MoveZigzag : MonoBehaviour
{


    public Moveable moveable;
    public bool moveRight = true;

    public Vector3 limiitRight;
    public Vector3 limitLeft;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
    }
    // Start is called before the first frame update
    void Start()
    {
        limiitRight = gameObject.transform.position + new Vector3(-2, 0, 0);
        limitLeft = gameObject.transform.position + new Vector3(2, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            moveable.SetDirection(-1, -1);
            if (gameObject.transform.position.x <= limiitRight.x)
            {
                limitLeft = gameObject.transform.position + new Vector3(2, 0, 0);
                moveRight = false;
            }
        }
        else
        {
            moveable.SetDirection(1, -1);
            if (gameObject.transform.position.x >= limitLeft.x)
            {
                limiitRight = gameObject.transform.position + new Vector3(-2, 0, 0);
                moveRight = true;
            }
        }

    }
}

