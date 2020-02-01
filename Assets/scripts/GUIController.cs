using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIController : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] startMenuObjects;
    bool started;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        startMenuObjects = GameObject.FindGameObjectsWithTag("ShowOnStart");
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hidePaused();
        showStart();
        started = false;
    }

    public void onStart()
    {
        started = true;
        hideStart();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                    showPaused();
                }
                else if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    hidePaused();
                }
            }
        }
    }

    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            hidePaused();
        }
    }

    //shows objects with ShowOnPause tag
    public void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }
    

    //shows all objects for the start menu
    public void showStart()
    {
        foreach (GameObject g in startMenuObjects)
        {
            g.SetActive(true);
        }
    }

    public void hideStart()
    {
        foreach (GameObject g in startMenuObjects)
        {
            g.SetActive(false);
        }
        Time.timeScale = 1;
    }

    //hides objects with ShowOnPause tag
    public void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        Application.LoadLevel(level);
    }
}
