using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotChanger : MonoBehaviour
{
    public Inventory inventory;
    public int activeSlotIndex = 0;
    [SerializeField] private Transform frames;
    [SerializeField] private WeaponSkript weapon;
    [SerializeField] private SpriteRenderer model;

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll == 0)
        {
            // SwitchSlot((int)Mathf.Ceil(scroll));
        }
        else if (scroll > 0)
        {
            SwitchSlot((int)Mathf.Ceil(scroll));
        }
        else { SwitchSlot((int)Mathf.Floor(scroll)); }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeSlotIndex = 0;
            SetSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeSlotIndex = 1;
            SetSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activeSlotIndex = 2;
            SetSlot();
        }
    }
    public void SetSlot()
    {
        foreach (Transform frame in frames)
            frame.gameObject.SetActive(false);
        frames.GetChild(activeSlotIndex).gameObject.SetActive(true);
        if (inventory.isFull[activeSlotIndex])
        {
            weapon.damage = inventory.weapons[activeSlotIndex].Damage;
            model.sprite = inventory.weapons[activeSlotIndex].Sprite;
        }
        else
        {
            weapon.damage = 0;
            model.sprite = null;
        }
    }

    private void SwitchSlot(int direction)
    {
        activeSlotIndex += direction;

        if (activeSlotIndex < 0)
        {
            activeSlotIndex = inventory.slots.Length - 1;
        }
        else if (activeSlotIndex >= inventory.slots.Length)
        {
            activeSlotIndex = 0;
        }
        SetSlot();
    }
}
