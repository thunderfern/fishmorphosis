using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string nextScene;

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
