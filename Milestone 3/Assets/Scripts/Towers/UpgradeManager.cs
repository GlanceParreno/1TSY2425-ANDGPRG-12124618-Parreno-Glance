using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public GameObject towerSelectionMenu; // Panel for tower selection and upgrades
    public TextMeshProUGUI damageText; // Displays tower damage
    public TextMeshProUGUI rangeText; // Displays tower range
    public TextMeshProUGUI fireRateText; // Displays tower fire rate
    public TextMeshProUGUI upgradeCostText; // Displays upgrade cost
    public GameObject upgradeButtons; // Parent object for upgrade buttons

    private Tower selectedTower; // Currently selected tower

    public static UpgradeManager Instance; // Singleton instance

    private void Awake()
    {
        Instance = this;
    }

    // Open the menu with the selected tower's data
    public void OpenUpgradeMenu(Tower tower)
    {
        if (tower == null)
        {
            Debug.LogWarning("No tower selected to upgrade.");
            return;
        }
        selectedTower = tower;
        UpdateUI();
        towerSelectionMenu.SetActive(true); // Show the upgrade menu
    }

    // Open the menu from the Open Button (optional behavior)
    public void OpenUpgradeMenu()
    {
        if (selectedTower == null)
        {
            Debug.LogWarning("No tower is currently selected.");
            return;
        }
        UpdateUI();
        towerSelectionMenu.SetActive(true); // Show the upgrade menu
    }

    // Close the upgrade menu
    public void CloseUpgradeMenu()
    {
        towerSelectionMenu.SetActive(false); // Hide the upgrade menu
        selectedTower = null; // Clear the selected tower
    }

    // Upgrade paths
    public void UpgradePath1()
    {
        if (selectedTower != null && TowerManager.Instance.SpendGold(selectedTower.GetUpgradeCost()))
        {
            selectedTower.UpgradePath1();
            UpdateUI();
        }
    }

    public void UpgradePath2()
    {
        if (selectedTower != null && TowerManager.Instance.SpendGold(selectedTower.GetUpgradeCost()))
        {
            selectedTower.UpgradePath2();
            UpdateUI();
        }
    }

    public void UpgradePath3()
    {
        if (selectedTower != null && TowerManager.Instance.SpendGold(selectedTower.GetUpgradeCost()))
        {
            selectedTower.UpgradePath3();
            UpdateUI();
        }
    }

    // Update the UI with selected tower's stats
    private void UpdateUI()
    {
        if (selectedTower != null)
        {
            damageText.text = $"Damage: {selectedTower.damage}";
            rangeText.text = $"Range: {selectedTower.range}";
            fireRateText.text = $"Fire Rate: {selectedTower.fireRate}";
            upgradeCostText.text = $"Upgrade Cost: ${selectedTower.GetUpgradeCost()}";

            // Enable or disable upgrade buttons based on max upgrade level
            upgradeButtons.SetActive(selectedTower.upgradeLevel < selectedTower.maxUpgradeLevel);
        }
    }
}
