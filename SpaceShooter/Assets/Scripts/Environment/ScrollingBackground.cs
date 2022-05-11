using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
        {
            public float speed;
            public Transform[] background;
            private Vector3 _direction;
    
            // Start is called before the first frame update
            void Start()
            {
                _direction = new Vector3(0,-1,0);
            }
    
            // Update is called once per frame
            void Update()
            {
                PositionUpdate();
                CheckPosition();
            }
    
            private void CheckPosition()
            {
                if (background[0].position.y <= -72f)
                {
                    MoveToTop(0);
                }
            
                if (background[1].position.y <= -72f)
                {
                    MoveToTop(1);
                }
            }
    
            private void MoveToTop(int index)
            {
                if (index == 0)
                {
                    background[0].position = background[1].position + new Vector3(0, 72, 0);    
                }
                else
                {
                    background[1].position = background[0].position + new Vector3(0, 72, 0);
                }
            
            }
    
            private void PositionUpdate()
            {
                background[0].position += _direction * (Time.deltaTime * speed);
                background[1].position += _direction * (Time.deltaTime * speed);
                background[2].position += _direction * (Time.deltaTime * speed);
    }
        }
