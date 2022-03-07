using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D therRB;
    public float moveSpeed;

    public float rangeToChasePlayer;
    private Vector3 moveDirection;


    private void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer)
        {
            moveDirection = PlayerController.instance.transform.position - transform.position;
        }
        else
        {
            moveDirection = Vector3.zero;
        }

        moveDirection.Normalize();

        therRB.velocity = moveDirection * moveSpeed;
    }




}
