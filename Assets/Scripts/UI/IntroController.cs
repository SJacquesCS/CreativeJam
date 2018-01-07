using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

    void Awake()
    {
        Cursor.visible = false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(2);
    }
}
