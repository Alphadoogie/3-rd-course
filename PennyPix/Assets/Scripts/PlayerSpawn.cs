using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public static Vector3 position;
    private Transform transform;
    void Start()
    {
        transform = GetComponent<Transform>();
        if (PennyDeath.IsDead)
        {
            transform.position = position;
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
