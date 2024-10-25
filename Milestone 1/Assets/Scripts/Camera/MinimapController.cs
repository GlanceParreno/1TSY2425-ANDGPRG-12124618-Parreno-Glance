using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Transform MinimapCamera; // Reference to the minimap camera
    public GameObject monsterIconPrefab; // Prefab for monster icons on the minimap
    public GameObject towerIconPrefab; // Prefab for tower icons

    // Update icons in the minimap view based on world positions
    private void LateUpdate()
    {
        // Example logic for updating monster and tower icons
        foreach (var monster in FindObjectsOfType<Monster>())
        {
            Vector3 iconPosition = MinimapCamera.GetComponent<Camera>().WorldToViewportPoint(monster.transform.position);
            GameObject icon = Instantiate(monsterIconPrefab, iconPosition, Quaternion.identity, transform);
            icon.transform.position = new Vector3(iconPosition.x, iconPosition.y, 0);
        }
    }
}

