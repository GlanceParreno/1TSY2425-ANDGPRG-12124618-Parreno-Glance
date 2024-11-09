using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TowerManager : MonoBehaviour
{
    public GameObject arrowTowerPrefab;
    public GameObject iceTowerPrefab;
    public GameObject fireTowerPrefab;
    public GameObject cannonTowerPrefab;

    private GameObject selectedTowerPrefab;
    public TextMeshProUGUI goldText; 
    private int playerGold = 500;

    public static TowerManager Instance;

    private void Awake()
    {
        Instance = this; // Set up Singleton for easy access
    }

    private void Start()
    {
        UpdateGoldUI();
    }

    public void AddGold(int amount)
    {
        playerGold += amount;
        UpdateGoldUI();
    }

    private void UpdateGoldUI()
    {
        goldText.text = "Gold: " + playerGold;
    }

    public void SpendGold(int amount)
    {
        playerGold -= amount;
        UpdateGoldUI();
    }

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

    public void PlaceTower(Vector3 position)
    {
        if (selectedTowerPrefab != null)
        {
            Tower tower = selectedTowerPrefab.GetComponent<Tower>();
            if (tower.cost <= playerGold)
            {
                Instantiate(selectedTowerPrefab, position, Quaternion.identity);
                playerGold -= tower.cost;
            }
        }
    }

    private void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0) && selectedTowerPrefab != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if player has enough gold to build the tower
                Tower tower = selectedTowerPrefab.GetComponent<Tower>();
                if (tower != null && playerGold >= tower.cost)
                {
                    Instantiate(selectedTowerPrefab, hit.point, Quaternion.identity);
                    playerGold -= tower.cost; // Deduct gold after placing tower
                }
            }
        }
    }

}
