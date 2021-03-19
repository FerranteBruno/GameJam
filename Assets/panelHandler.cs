using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Panel;

    public static bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.P))
        {

            if (GameIsPaused)
            {

                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        Panel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        Panel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("menu");
    }

    void Salirl()
    {
        Application.Quit();
    }

    public void Controles()
    {
        SceneManager.LoadScene("controles");
    }
}
