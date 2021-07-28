using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player_data:MonoBehaviour
{
   
    public float score = 0;
    public int life=3;
    public int coin = 0;
    public float time = 0;
    public float distance = 0;
    public int speed = 10;
    private float time_counter = 0;

    private void Start()
    {
        reset();
    }

    public void reset()
    {
        score = 0;
        coin = 0;
        time = 0;
        distance = 0;
        speed = 10;
        time_counter = 0;
        life = 3;
       
    }

    private void Update()
    {
        

        
        distance = time / speed;
        score = (int)(distance * 5 + (coin * 10));
        if (life > 0)
        {
            time += Time.deltaTime;
        }
        if (time_counter > 20)
        {
            time_counter = 0;
            speed++;
        }
        time_counter += Time.deltaTime;
    }

   
}
