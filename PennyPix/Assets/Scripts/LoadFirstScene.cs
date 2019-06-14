using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFirstScene : MonoBehaviour
{
    private AudioSource audioSource;
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PennyDeath.IsDead = false;
            SceneManager.LoadScene("First");
            CharacterInfo.SaveData("First");
        }
    }
}