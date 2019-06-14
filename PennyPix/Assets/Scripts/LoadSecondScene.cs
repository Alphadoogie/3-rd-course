using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSecondScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PennyDeath.IsDead = false;
            SceneManager.LoadScene("Second");
            CharacterInfo.SaveData("Second");
        }
    }
}
