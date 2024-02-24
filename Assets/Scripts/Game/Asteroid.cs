using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    private float rotateSpeed = 50.0f;
    [SerializeField]
    private GameObject explosionPrefab;
    private SpawnManager spawnManager;
    [SerializeField]
    private Text Controlls;
    public Text Instructions1;
    public Text Instructions2;
    public Text Instructions3;
    public Text Instructions4;
    [SerializeField]
    private Text Arrow;
    public bool GameIsRunning = false;

    void Start()
    {
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            spawnManager.StartSpawning();
            Destroy(this.gameObject, 0.2f);
            Destroy(GetComponent<Collider2D>());
            Controlls.CrossFadeAlpha(0, 3, true);
            Instructions1.CrossFadeAlpha(0, 3, true);
            Instructions2.CrossFadeAlpha(0, 3, true);
            Instructions3.CrossFadeAlpha(0, 3, true);
            Instructions4.CrossFadeAlpha(0, 3, true);
            Arrow.CrossFadeAlpha(0, 3, true);
            GameIsRunning = true;
        }
    }
}
