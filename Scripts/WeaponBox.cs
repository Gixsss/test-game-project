using Entity;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponBox : MonoBehaviour
{
    [SerializeField] private GameObject[] projectileToShoot;

    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            other.GetComponent<Player>().projectileToShoot = projectileToShoot[Random.Range(0, projectileToShoot.Length)];
            _animator.SetBool("isOpened", true);
            Destroy(gameObject, 2.0f);
        }
    }
}
