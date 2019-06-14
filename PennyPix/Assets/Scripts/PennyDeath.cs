using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class PennyDeath : MonoBehaviour
{
    public new ParticleSystem particleSystem;
    private float posX, posY, posZ;
    public GameObject Player;
    public static bool IsDead = false;
    private AudioSource audioSource;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            posX = Player.transform.position.x;
            posY = Player.transform.position.y;
            posZ = Player.transform.position.z;
            particleSystem.transform.position = new Vector3(posX, posY, posZ);
            particleSystem.Play();
            Destroy(Player);
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = Resources.Load<AudioClip>("Death");
            audioSource.volume = 1F;
            audioSource.Play();
            StartCoroutine(Timer());
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5f);
        CharacterInfo characterInfo = new CharacterInfo();
        characterInfo = SaveHandler.Deserialize();
        SceneManager.LoadScene(characterInfo.sceneName);
        PlayerSpawn.position = new Vector3(characterInfo.x, characterInfo.y, characterInfo.z);
        AddingScore.count = characterInfo.scoreCount;
        IsDead = true;
    }
}