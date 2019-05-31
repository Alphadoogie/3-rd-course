using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
   public void StartPressed()
    {
        SceneManager.LoadScene("First");
        CharacterInfo.SaveData("First");
    }

    public void ContinuePressed()
    {
        PennyDeath.IsDead = true;
        CharacterInfo characterInfo = new CharacterInfo();
        characterInfo = SaveHandler.Deserialize();
        SceneManager.LoadScene(characterInfo.sceneName);
        PlayerSpawn.position = new Vector3(characterInfo.x, characterInfo.y, characterInfo.z);
        AddingScore.count = characterInfo.scoreCount;    
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}