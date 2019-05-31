using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFourthLevel : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Fourth");
            CharacterInfo.SaveData("Fourth");
        }
    }
}