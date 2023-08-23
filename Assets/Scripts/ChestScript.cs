using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    [SerializeField]private WeaponData[]  weapons;
    [SerializeField] private Vector3 offset;
    private bool isOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& !isOpen)
        {
            isOpen = true;
            Instantiate(weapons[Random.Range(0, weapons.Length)].Model,transform.position + offset,Quaternion.identity);
        }
    }
}
