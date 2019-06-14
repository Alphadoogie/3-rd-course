using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 2f);
    }
}