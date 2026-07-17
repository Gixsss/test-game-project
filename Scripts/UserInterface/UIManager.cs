using Entity;
using UnityEngine;
using UserInterface.Bars;
using UserInterface.Inventory;

namespace UserInterface
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }
        public InventoryUI inventoryUI;
        public PauseMenuUI pauseMenuUI;
        [SerializeField] private Player player;
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private ExperienceBar experienceBar;

        public void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }
        
        public void Start()
        {
            healthBar.Initialize(player);
            experienceBar.Initialize(player);
        }
    }
}