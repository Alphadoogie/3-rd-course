using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadFifthScene : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Five");
        }
    }
}