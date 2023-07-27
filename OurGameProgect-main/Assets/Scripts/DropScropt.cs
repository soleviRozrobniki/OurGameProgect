using System.Runtime.CompilerServices;
using UnityEngine;

public class DropScropt : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private SlotsChange inventory;
    
    private void SpawnDroppedItem()
    { 
        if (!inventory.inventory.isFull[inventory.activeSlotIndex]) return;
        Instantiate(inventory.inventory.weapons[inventory.activeSlotIndex].Model, transform.position+offset, Quaternion.identity);
        inventory.inventory.weapons[inventory.activeSlotIndex] = null;
        inventory.inventory.slots[inventory.activeSlotIndex].sprite = null;
        inventory.inventory.isFull[inventory.activeSlotIndex] = false;
        inventory.SetSlot();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
            SpawnDroppedItem();
    }
}
 