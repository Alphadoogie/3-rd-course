using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveHandler : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private CharacterInfo current;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        current = new CharacterInfo();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {
            if (current == null)
            {
                current = new CharacterInfo();
            }
            current.x = Player.transform.position.x;
            current.y = Player.transform.position.y;
            current.z = Player.transform.position.z;
            current.scoreCount = AddingScore.count;
            current.sceneName = SceneManager.GetActiveScene().name;
            CharacterInfo.SaveData(current);
        }
        Debug.LogWarning(Application.persistentDataPath);
        Debug.LogWarning(current.x);
        Debug.LogWarning(current.y);
        Debug.LogWarning(current.z);
        Debug.LogWarning(current.scoreCount);
        Debug.LogWarning(current.sceneName);
    }


   /* public void LoadData()
    {
        current = Deserialize();
        SceneManager.LoadScene(current.sceneName);
        AddingScore.count = current.scoreCount;
        Player.GetComponent<Transform>().position = new Vector3(current.x, current.y, current.z);
    }*/
    public static CharacterInfo Deserialize()
    {
        CharacterInfo obj = new CharacterInfo();
        if (File.Exists(Application.persistentDataPath + "/save.pp"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.pp", FileMode.Open);
            obj = (CharacterInfo)bf.Deserialize(file);
            file.Close();
        }
        return obj;
    }
}

[Serializable]
public class CharacterInfo
{
    public float x;
    public float y;
    public float z;
    public int scoreCount;
    public string sceneName;

    public CharacterInfo()
    {
        x = 0;
        y = 0;
        z = 0;
        scoreCount = 0;
        sceneName = "MainMenu";
    }

    public static void SaveData(CharacterInfo obj)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/save.pp");
        binaryFormatter.Serialize(file, obj);
        file.Close();
    }
}