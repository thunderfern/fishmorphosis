using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
