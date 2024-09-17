using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int sceneToLoad;
    private int totalScenes;

    private void Start()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex;
        totalScenes = SceneManager.sceneCountInBuildSettings;
    }

    private void OnGUI()
    {
        // Display the current scene name
        GUI.Label(new Rect(1020, 10, 600, 60), "Current Scene: " + SceneManager.GetActiveScene().name);

        // Calculate the next scene index
        int nextSceneIndex = sceneToLoad + 1;
        int previousSceneIndex = sceneToLoad - 1;
        if (nextSceneIndex >= totalScenes)  // Wrap around if it's the last scene
            nextSceneIndex = 0;
        if (previousSceneIndex <= 0)
            previousSceneIndex = 3;

        switch (SceneManager.GetActiveScene().name)
        {
            case "MainMenu":
                if (GUI.Button(new Rect(1020, 290, 600, 60), "Level 1"))
                    SceneManager.LoadScene(1);
                if (GUI.Button(new Rect(1020, 360, 600, 60), "Level 2"))
                    SceneManager.LoadScene(2);
                if (GUI.Button(new Rect(1020, 430, 600, 60), "Level 3"))
                    SceneManager.LoadScene(3);
                break;

            case "Level_1":
                if (GUI.Button(new Rect(1020, 290, 600, 60), "Main Menu"))
                    SceneManager.LoadScene(0);
                if (GUI.Button(new Rect(1020, 360, 600, 60), "Level 2"))
                    SceneManager.LoadScene(2);
                if (GUI.Button(new Rect(1020, 430, 600, 60), "Level 3"))
                    SceneManager.LoadScene(3);
                break;

            case "Level_2":
                if (GUI.Button(new Rect(1020, 290, 600, 60), "Main Menu"))
                    SceneManager.LoadScene(0);
                if (GUI.Button(new Rect(1020, 360, 600, 60), "Level 1"))
                    SceneManager.LoadScene(1);
                if (GUI.Button(new Rect(1020, 430, 600, 60), "Level 3"))
                    SceneManager.LoadScene(3);
                break;

            case "Level_3":
                if (GUI.Button(new Rect(1020, 290, 600, 60), "Main Menu"))
                    SceneManager.LoadScene(0);
                if (GUI.Button(new Rect(1020, 360, 600, 60), "Level 1"))
                    SceneManager.LoadScene(1);
                if (GUI.Button(new Rect(1020, 430, 600, 60), "Level 2"))
                    SceneManager.LoadScene(2);
                break;
        }

        // Display the button with the correct scene index
        if (GUI.Button(new Rect(1020, 80, 600, 60), "Load Scene: " + nextSceneIndex))
        {
            sceneToLoad = nextSceneIndex;
            SceneManager.LoadScene(sceneToLoad);
        }
        if (GUI.Button(new Rect(1020, 150, 600, 60), "Previous Scene: " + previousSceneIndex))
        {
            sceneToLoad = previousSceneIndex;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
