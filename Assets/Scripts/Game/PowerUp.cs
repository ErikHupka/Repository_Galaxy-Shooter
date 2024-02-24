using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    private int powerupID;
    [SerializeField]
    private AudioClip Clip;

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -4.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            Player player = other.transform.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(Clip, transform.position);

            if (player != null)
            {
                switch (powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        player.ShieldsActive();
                        break;
                    case 3:
                        player.Heal();
                        break;
                    default:
                        break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}