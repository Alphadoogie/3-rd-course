using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

/*[Serializable]
public class SaveHandler
{    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (current == null)
            {
                current = new SaveHandler();
            }
            current.x = Player.transform.position.x;
            current.y = Player.transform.position.y;
            current.z = Player.transform.position.z;
            current.scoreCount = AddingScore.count;
            current.sceneName = SceneManager.GetActiveScene().name;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/save.pp");
            binaryFormatter.Serialize(file, current);
        }
        Debug.LogWarning(Application.persistentDataPath);
        Debug.LogWarning(current.x);
        Debug.LogWarning(current.y);
        Debug.LogWarning(current.z);
        Debug.LogWarning(current.scoreCount);
        Debug.LogWarning(current.sceneName);
    }
}

public class CharacterInfo
{
    private double x;
    private double y;
    private double z;
    private int scoreCount;
    private string sceneName;

}

public class Game
{
    public static Game current;
    public CharacterInfo character;

    public Game()
    {
        character = new CharacterInfo();
    }

}*/