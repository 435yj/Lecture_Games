using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 1;

    public float waitToBeCollecte = .5f;

    private void Update()
    {
        if (waitToBeCollecte > 0)
        {
            waitToBeCollecte -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && waitToBeCollecte <= 0)
        {
            PlayerHealthController.instance.HealPlayer(healAmount);

            Destroy(gameObject);

            AudioManager.instance.PlaySFX(7);
        }
    }

}
