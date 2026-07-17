using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void Update()
    {
        transform.position = player.transform.position;
    }
}
