using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    // gui font size
    public int fontSize = 28;

    // variables
    public float health;
    public float experience;
    public float score;
    public float multiplier = 1;
    public float stamina;
    public float ammo;
    private static int gameManagerCount = 0; // game manager count
    public string levelName;



    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (manager != this)
            Destroy(gameObject);
    }


    private void Update()
    {
        if (levelName != SceneManager.GetActiveScene().name)
            levelName = SceneManager.GetActiveScene().name;

        gameManagerCount = GameObject.FindGameObjectsWithTag("GameManager").Length;
        if (Input.GetKeyDown(KeyCode.Alpha1)) SceneManager.LoadScene(0); // press 1
        if (Input.GetKeyDown(KeyCode.Alpha2)) SceneManager.LoadScene(1); // press 2
        if (Input.GetKeyDown(KeyCode.Alpha3)) SceneManager.LoadScene(2); // press 3
        if (Input.GetKeyDown(KeyCode.Alpha4)) SceneManager.LoadScene(3); // press 4
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = fontSize;

        GUI.Label(new Rect(10, 45, 300, 60), "Health: " + health);
        GUI.Label(new Rect(10, 185, 300, 60), "Experience: " + experience);
        GUI.Label(new Rect(10, 325, 300, 60), "Score: " + score);
        GUI.Label(new Rect(10, 465, 300, 60), "Multiplier: x" + multiplier);
        GUI.Label(new Rect(10, 605, 300, 60), "Stamina: " + stamina);
        GUI.Label(new Rect(10, 745, 300, 60), "Ammo: " + ammo);
        GUI.Label(new Rect(10, 845, 400, 60), "Game Manager Count: " + gameManagerCount);
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(GetSavePath() + "/playerInfo.dat");
        Debug.Log(Application.persistentDataPath);

        PlayerData data = new PlayerData();
        data.health = health;
        data.experience = experience;
        data.score = score;
        data.multiplier = multiplier;
        data.stamina = stamina;
        data.ammo = ammo;
        data.levelName = levelName;
        bf.Serialize(file, data);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(GetSavePath() + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            health = data.health;
            experience = data.experience;
            score = data.score;
            multiplier = data.multiplier;
            stamina = data.stamina;
            ammo = data.ammo;
            levelName = data.levelName;
        }

        // Could be used to load saved scene
        // if (levelName != SceneManager.GetActiveScene().name)
        //     SceneManager.LoadScene(levelName);
    }

    private static string GetSavePath()
    {
        return Application.persistentDataPath;
    }
}
