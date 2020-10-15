using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    public void LoadScene(int index)
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        SceneManager.LoadScene(index);
    }

    public void EnableControlsPanel(GameObject controlsPanel)
    {
        controlsPanel.SetActive(true);
    }
}
