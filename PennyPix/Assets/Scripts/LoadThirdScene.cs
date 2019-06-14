using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadThirdScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            PennyDeath.IsDead = false;
            SceneManager.LoadScene("Third");
            CharacterInfo.SaveData("Third");
        }
    }
}
