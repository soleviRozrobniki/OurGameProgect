using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [HideInInspector] public bool isOpened;
    private Animator _animator;
    public bool isLocked;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLocked)
        {
            _animator.SetBool("Open", true);
            isOpened = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLocked)
        {
            _animator.SetBool("Open", false);
            isOpened = false;
        }
    }
}
