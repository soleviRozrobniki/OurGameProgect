using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovmentScript : MonoBehaviour
{
    public float health;
    [SerializeField] private WeaponSkript weaponScript;
    public float moveSpeed = 5f;
    public GameObject pickUpText;
    public Transform weaponPoint;
    [SerializeField] private Inventory inventory;
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
                pickUpText.SetActive(false);
                for (int i = 0; i < inventory.isFull.Length; i++)
                {
                    if (inventory.isFull[i] == false)
                    {
                        inventory.isFull[i] = true;
                        inventory.weapons[i] = collision.GetComponent<Filling>().weapon;
                        inventory.slots[i].sprite = inventory.weapons[i].Sprite;
                        break;
                    }
                }

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
    public void TakedDamage(float damage)
    {

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        
    }
}
