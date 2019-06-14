using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFifthScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PennyDeath.IsDead = false;
            SceneManager.LoadScene("Five");
            CharacterInfo.SaveData("Five");
        }
    }
}