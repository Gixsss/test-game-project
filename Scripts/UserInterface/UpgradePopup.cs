using Entity;
using PlayerUpgrades;
using PlayerUpgrades.Common;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterface
{
    public class UpgradePopup : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private GameObject upgradePopup;
        [SerializeField] private Button[] upgradeButtons;
        
        private readonly MovementSpeedUpgrade _movementSpeedUpgrade =  new()
        {
            Description = "Gives your character bonus speed", Name = "Bonus Speed"
        };
        
        private void Awake()
        {
            upgradePopup.SetActive(false);
            player.Experience.OnLevelUp += SetActive;
            Shrine.OnProgressCompleted += SetActive;
        }

        private void SetActive()
        {
            foreach (var upgradeButton in upgradeButtons)
            {
                upgradeButton.GetComponentInChildren<TextMeshProUGUI>().text = _movementSpeedUpgrade.Name;
                upgradeButton.onClick.RemoveAllListeners();
                upgradeButton.onClick.AddListener(() => ApplyUpgrade(_movementSpeedUpgrade));
            }
            upgradePopup.SetActive(true);
            Time.timeScale = 0f;
            GameState.IsPaused = true;
        }
        
        private void SetInactive()
        {
            upgradePopup.SetActive(false);
            Time.timeScale = 1f;
            GameState.IsPaused = false;
        }

        private void ApplyUpgrade(Upgrade upgrade)
        {
            upgrade.Apply(player.Stats);
            upgradePopup.SetActive(false);
            Time.timeScale = 1f;
            GameState.IsPaused = false;
        }
    }
}