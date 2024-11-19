using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerManager : MonoBehaviour
{
    // Tower prefabs
    public GameObject arrowTowerPrefab;
    public GameObject iceTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject cannonTowerPrefab;

    private GameObject selectedTowerPrefab; // Currently selected tower prefab
    private Tower clickedTower; // Tower selected for upgrades

    // Gold management
    public TextMeshProUGUI goldText;
    private int playerGold = 500;

    public static TowerManager Instance; // Singleton instance

    private void Awake()
    {
        // Set up Singleton for easy access
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateGoldUI(); // Initialize the UI with starting gold
    }

    // Method to add gold
    public void AddGold(int amount)
    {
        playerGold += amount;
        UpdateGoldUI();
    }

    // Method to spend gold and return success status
    public bool SpendGold(int amount)
    {
        if (playerGold >= amount)
        {
            playerGold -= amount;
            UpdateGoldUI();
            return true; // Gold spent successfully
        }
        return false; // Not enough gold
    }

    // Update the gold display in the UI
    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + playerGold;
    }

    // Methods to select towers
    public void SelectArrowTower()
    {
        selectedTowerPrefab = arrowTowerPrefab;
    }

    public void SelectIceTower()
    {
        selectedTowerPrefab = iceTowerPrefab;
    }

    public void SelectFireTower()
    {
        selectedTowerPrefab = fireTowerPrefab;
    }

    public void SelectCannonTower()
    {
        selectedTowerPrefab = cannonTowerPrefab;
    }

    // Place the selected tower at the specified position
    public void PlaceTower(Vector3 position)
    {
        if (selectedTowerPrefab != null)
        {
            Tower tower = selectedTowerPrefab.GetComponent<Tower>();
            if (tower != null && SpendGold(tower.cost))
            { // Check gold and deduct if successful
                Instantiate(selectedTowerPrefab, position, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        // Handle mouse click for selecting or placing towers
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the clicked object is a tower
                Tower tower = hit.collider.GetComponent<Tower>();
                if (tower != null)
                {
                    clickedTower = tower;
                    UpgradeManager.Instance.OpenUpgradeMenu(clickedTower); // Open upgrade menu
                }
                else if (selectedTowerPrefab != null)
                {
                    // Place the selected tower if no existing tower is clicked
                    PlaceTower(hit.point);
                }
            }
        }
    }
}
