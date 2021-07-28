using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    [SerializeField]
    private game_ui ui;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0 && SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            else
                menu();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 0)
            Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void play()
    {
        if(ui!=null)
            ui.reset();
        SceneManager.LoadScene(1);

    }
}
