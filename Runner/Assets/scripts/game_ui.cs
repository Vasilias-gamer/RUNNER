using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_ui : MonoBehaviour
{
    [SerializeField]
    private GameObject pause_button;
    [SerializeField]
    private GameObject result_panal;
    [SerializeField]
    TextMeshProUGUI result_t;
    [SerializeField]
    TextMeshProUGUI score_t;
    [SerializeField]
    TextMeshProUGUI life_t;
    [SerializeField]
    private player_data data;
    // Start is called before the first frame update
    void Start()
    {
        reset();
    }

    public void reset()
    {
        pause_button.SetActive(true);
        result_panal.SetActive(false);
        data.reset();
    }

    // Update is called once per frame
    void Update()
    {
        life_t.text = "LIFE: " + data.life.ToString();
        score_t.text = "COIN:" + data.coin.ToString();
    }
    public void show_result()
    {
        result_t.text = "SCORE: " + data.score + "\n TIME: " + (int)data.time + "sec\n COIN:" + data.coin + "\n DISTANCE:" + (int)data.distance + "m";
        result_panal.SetActive(true);
        pause_button.SetActive(false);
    }
}
