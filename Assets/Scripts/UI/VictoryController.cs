using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryController : MonoBehaviour {

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
