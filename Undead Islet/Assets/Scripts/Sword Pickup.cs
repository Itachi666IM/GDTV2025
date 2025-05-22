using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    PlayerMovement player;
    public float radius;
    public LayerMask playerLayer;
    bool canPickup;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        canPickup = Physics.CheckSphere(transform.position,radius,playerLayer);

        if(canPickup)
        {
            Destroy(gameObject);
            player.sword.SetActive(true);
        }
    }
}
