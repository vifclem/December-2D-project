
using UnityEngine;

public class Player_spawn : MonoBehaviour
{
    private void Awake()
    {
            GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}
