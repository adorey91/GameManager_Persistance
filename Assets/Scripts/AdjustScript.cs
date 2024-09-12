using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustScript : MonoBehaviour
{
    void OnGUI()
    {
        // variable buttons
        if (GUI.Button(new Rect(320, 10, 350, 60), "Health Up"))
            GameManager.manager.health += 10;
        if (GUI.Button(new Rect(320, 80, 350, 60), "Health Down"))
            GameManager.manager.health -= 10;
        if (GUI.Button(new Rect(320, 150, 350, 60), "Experience Up"))
            GameManager.manager.experience += 10;
        if (GUI.Button(new Rect(320, 220, 350, 60), "Experience Down"))
            GameManager.manager.experience -= 10;
        if (GUI.Button(new Rect(320, 290, 350, 60), "Score Up"))
            GameManager.manager.score = GameManager.manager.score + (GameManager.manager.multiplier * GameManager.manager.experience);
        if (GUI.Button(new Rect(320, 360, 350, 60), "Score Down"))
            GameManager.manager.score = GameManager.manager.score - (GameManager.manager.multiplier * GameManager.manager.experience);
        if (GUI.Button(new Rect(320, 430, 350, 60), "Multiplier Up"))
            GameManager.manager.multiplier += 1;
        if (GUI.Button(new Rect(320, 500, 350, 60), "Multiplier Down"))
            GameManager.manager.multiplier -= 1;
        if (GUI.Button(new Rect(320, 570, 350, 60), "Stamina Up"))
            GameManager.manager.stamina += 10;
        if (GUI.Button(new Rect(320, 640, 350, 60), "Stamina Down"))
            GameManager.manager.stamina -= 10;
        if (GUI.Button(new Rect(320, 710, 350, 60), "Ammo Up"))
            GameManager.manager.ammo += 10;
        if (GUI.Button(new Rect(320, 780, 350, 60), "Ammo Down"))
            GameManager.manager.ammo -= 10;


        // save buttons

        if (GUI.Button(new Rect(720, 80, 250, 60), "Save"))
            GameManager.manager.Save();
        if (GUI.Button(new Rect(720, 150, 250, 60), "Load"))
            GameManager.manager.Load();
    }
}
