using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private string nextScene;

    public void goToNextScene()
    {
        Debug.Log("was press");
        SceneManager.LoadScene(nextScene);
    }
}
