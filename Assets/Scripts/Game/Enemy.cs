using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 4.0f;
    [SerializeField]
    private GameObject LaserPrefab;

    private Player player;
    private Animator anim;
    private AudioSource AudioSource;
    private float FireRate = 3.0f;
    private float CanFire = -1f;
    private bool IsDead = false;

    public GameObject Left_thruster;
    public GameObject Right_thruster;





    void Start()
    {

        player = GameObject.Find("Player").GetComponent<Player>();
        AudioSource = GetComponent<AudioSource>();

        if (player == null)
        {
            Debug.LogError("The Player is NULL");
        }

        anim = GetComponent<Animator>();

        if (anim == null)
        {
            Debug.LogError("The Animator is NULL");
        }

    }

    void Update()
    {
        CalculateMovement();
        DestroyWhileExit();
        EnemyFire();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            AudioSource.Play();

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
            Destroy(Left_thruster);
            Destroy(Right_thruster);
            IsDead = true;
        }

        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            if (player != null)
            {
                player.AddScore(1);
            }

            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            AudioSource.Play();

            Destroy(GetComponent<Collider2D>());
            Destroy(this.gameObject, 2.8f);
            Destroy(Left_thruster);
            Destroy(Right_thruster);
            IsDead = true;
        }
    }

    private void DestroyWhileExit()
    {
        if (transform.position.y < -4.5)
        {

            Destroy(this.gameObject);
            if (player != null)
            {
                player.AddScore(-1);
            }
        }
    }

    private void EnemyFire()
    {
        if (Time.time > CanFire && IsDead == false)
        {
            FireRate = Random.Range(1f, 3f);
            CanFire = Time.time + FireRate;
            GameObject enemyLaser = Instantiate(LaserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();


            for (int i = 0; i < lasers.Length; i++)
            {
                lasers[i].AssignEnemyLaser();
            }
        }
    }
}
