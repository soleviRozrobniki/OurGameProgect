using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovmentScript : MonoBehaviour
{
    public float moveSpeed = 5f,health;
    public GameObject pickUpText, portalText;
    public Transform weaponPoint;
    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed;
        transform.position += movement * Time.deltaTime;
    }
       
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag ("Weapon"))
        {
            pickUpText.SetActive(true);
            

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Transform curWeapon = collision.transform;
                curWeapon.position = weaponPoint.position;
                curWeapon.SetParent(weaponPoint);
                curWeapon.rotation = weaponPoint.rotation;
                curWeapon.tag = "Untagged";
                pickUpText.SetActive(false);
                for (int i = 0; i < inventory.isFull.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        inventory.weapons[i] = collision.GetComponent<NewBehaviourScript>().weapon;
                        inventory.slots[i].sprite = inventory.weapons[i].Sprite;
                        break;
                    }
                }

            }
        }    
        if(collision.CompareTag("Portal"))
        {
            portalText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            pickUpText.SetActive(false);
        }
    }
     public Inventory inventory;
    public int activeSlotIndex = 0;
    [SerializeField] private Transform frames;
    [SerializeField] private WeaponSkript weapon;
    [SerializeField] private SpriteRenderer model;

   
    public void SetSlot()
    {
        foreach(Transform frame in frames)
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
}
