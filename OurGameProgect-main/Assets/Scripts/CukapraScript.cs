using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdolfScript : MonoBehaviour
{
    [SerializeField] private float speed,damage;
    private MovmentScript target;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target)
        {
            target.TakedDamage(damage * Time.deltaTime);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target && collision.CompareTag("Player"))
        {
            target = null;
            //animator.stop
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out target))
        {
            //attack.Play;
        }
    }
}
