using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPieces : MonoBehaviour
{

    public float moveSpeed = 3f;
    private Vector3 moveDirection;

    public float deceleration = 5f;

    public float lifetime = 3f;

    public SpriteRenderer therSR;
    public float fadeSpeed = 2.5f;

    private void Start()
    {
        moveDirection.x = Random.Range(-moveSpeed, moveSpeed);
        moveDirection.y = Random.Range(-moveSpeed, moveSpeed);
    }

    private void Update()
    {
        transform.position += moveDirection * Time.deltaTime;

        moveDirection = Vector3.Lerp(moveDirection, Vector3.zero, deceleration * Time.deltaTime);

        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            therSR.color = new Color(therSR.color.r, therSR.color.g, therSR.color.b, Mathf.MoveTowards(therSR.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (therSR.color.a == 0f)
            {
                Destroy(gameObject);
            }
        }
    }

}
