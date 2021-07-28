using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    [SerializeField]
    private player_data data;
    [SerializeField]
    private game_ui ui;
    private bool gameover = false;
    private player_movement p_move;
    private bool hit = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("obsticals") && !hit)
        {
            hit = true;
            hit_obstical();
        }
        else if (collision.gameObject.tag.Equals("coin"))
        {
            data.coin++;
        }
    }

    private void Start()
    {
        gameover = false;
        hit = false;
        Time.timeScale = 1;
        p_move = GetComponent<player_movement>();
    }

    public void pause_play()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
    }


    private void hit_obstical()
    {
        p_move.hit();
        data.life--;
        StartCoroutine(respwan_player());
    }

    IEnumerator respwan_player()
    {
        yield return new WaitForSeconds(1.2f);
        //GetComponent<Rigidbody>().useGravity = false;
        transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        yield return new WaitForSeconds(.4f);
        p_move.run();
        hit = false;
        yield return new WaitForSeconds(.05f);
        p_move.controlBlocked = false;
    }


    private void Update()
    {
        if(hit)
            p_move.controlBlocked = true;
        if (data != null)
        {
            if (data.life == 0)
            {
                gameover = true;
                StartCoroutine(game_end());
            }
        }
       
    }

    IEnumerator game_end()
    {
        yield return new WaitForSeconds(1.2f);
        Time.timeScale = 0;
        ui.show_result();
    }

    

}
