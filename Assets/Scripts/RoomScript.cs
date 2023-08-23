using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    [SerializeField] private DoorScript door;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int countOfEnemies;
    [SerializeField] private float border;
    private void SpawnEnemies()
    {
        for (int i = 0; i < countOfEnemies; i++) 
        {
            Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)],transform.position+new Vector3((Random.Range(-border,border)),Random.Range(-border,border)),Quaternion.identity,transform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&&!door.isOpened) 
        { 
            SpawnEnemies();
            door.isLocked = true;
        }
    }
}
