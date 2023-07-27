using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public Animation attack1, attack2,attack3;
    public float hp,damage;

    // Start is called before the first frame update
    void Start()
    {
        int attackRand = Random.Range(1,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
