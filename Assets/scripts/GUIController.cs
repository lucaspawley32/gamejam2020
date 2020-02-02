using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIController : MonoBehaviour
{
    GameObject[] pauseObjects;
    GameObject[] startMenuObjects;
    GameObject[] hiddenOnPause;
    Image overlayImage;
    GameObject overlayObject;
    float r, g, b, a;
    bool started;
    bool fade = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        startMenuObjects = GameObject.FindGameObjectsWithTag("ShowOnStart");
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        hiddenOnPause = GameObject.FindGameObjectsWithTag("hideOnPause");
        overlayObject = GameObject.Find("ScreenOverlay");
        overlayImage = overlayObject.GetComponent<Image>();
        r = overlayImage.color.r;
        g = overlayImage.color.g;
        b = overlayImage.color.b;
        a = overlayImage.color.a;
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
        overlayObject.SetActive(true);
    }

    void updateOverlay()
    {
        a -= 0.0005f;
        overlayImage.color = new Color(r, g, b, a);
        if (a <= 0)
        {
            fade = true;
            overlayObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
				pauseControl();
            }
            if(!fade)
            {
                updateOverlay();
            }
        }
    }

    public void pauseControl()
    {
		Debug.Log("Fuck");
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
			Debug.Log("A");
            Time.timeScale = 1;
            Cursor.visible = false;
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
        foreach (GameObject g in hiddenOnPause)
        {
            g.SetActive(false);
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
        foreach (GameObject g in hiddenOnPause)
        {
            g.SetActive(true);
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
        foreach (GameObject g in hiddenOnPause)
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
