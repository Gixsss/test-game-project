using Entity;
using UnityEngine;

public class ExperienceShard : MonoBehaviour
{
    private const int ExperienceProvided = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.Experience.GainExperience(ExperienceProvided);
            Destroy(gameObject);
        }
    }
}