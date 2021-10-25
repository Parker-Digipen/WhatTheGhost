/**********************
*By: Parker Ives
*date: 10/25/21
*desc: makes selected scene load
***********************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad;

    // Changes the scene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
