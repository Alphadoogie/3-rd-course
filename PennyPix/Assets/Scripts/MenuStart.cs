using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour
{
   public void StartPressed()
    {
        SceneManager.LoadScene("First");
        CharacterInfo.SaveData("First");
        CallPauseMenu.exInput = true;
    }

    public void ContinuePressed()
    {
        PennyDeath.IsDead = true;
        CharacterInfo characterInfo = new CharacterInfo();
        characterInfo = SaveHandler.Deserialize();
        SceneManager.LoadScene(characterInfo.sceneName);
        PlayerSpawn.position = new Vector3(characterInfo.x, characterInfo.y, characterInfo.z);
        AddingScore.count = characterInfo.scoreCount;
        CallPauseMenu.exInput = true;
    }

    public void ShowManual()
    {
        Process.Start("C:/Mamzel.chm");
    }

    public void ExitPressed()
    {
        Application.Quit();
    }
}