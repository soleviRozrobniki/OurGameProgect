using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSkript : MonoBehaviour
{
    public int hp;
    public ParticleSystem broke;
    
    void Update()
    {
        if (hp <= 0)
        {
            broke.Play();
            Destroy(gameObject); 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "BulletFriend" || collision.transform.tag == "BulletEnemy")
        {
            hp--;
            Destroy(collision.gameObject);
        }
    }
}
