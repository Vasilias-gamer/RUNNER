using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_input : MonoBehaviour
{
    [SerializeField]
    private player_movement move;
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;
    private bool start_running = false;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            if (!move.Run)
                move.run();

            theTouch = Input.GetTouch(0);

            if (theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }

            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;
                

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x > 0)
                        move.turn_right();
                    else
                        move.turn_left();
                }

                else
                {
                    if (y > 0)
                        move.jump();
                    else
                        move.slide();
                }
            }
        }
        
    }
} 
