using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private float speedMultiplier = 15f;
    private float Speed1 = 10f;
    public GameObject laserPrefab;
    public GameObject tripleShotPrefab;
    public float fireRate = 0.5f;
    private float canFire = -1f;
    public int lives = 3;
    private SpawnManager spawnManager;
    private bool isTripleShotActive = false;
    private bool isSpeedBoostActive = false;
    private bool isShieldsActive = false;
    public GameObject shieldVisualizer;
    public GameObject leftEngine, rightEngine;
    public int score = 0;
    private UIManager uiManager;
    public AudioClip LaserSound;
    public AudioSource AudioSource;
    public AudioSource Audio;
    public GameObject TrippleShotButton;
    public GameObject SpeedButton;
    public GameObject ShieldButton;
    public Image TrippleShotImage;
    public Image SpeedImage;
    public Image ShieldImage;
    private bool TrippleShotCooldown, SpeedCooldown, ShieldCooldown = false;
    private float CoolDown = 10;
    private bool NextSpeed = false;
    private int x, y = 0;
    private Coroutine coroutineTripple, coroutineSpeed, coroutineShield;
    private bool TrippleShotRunning, SpeedRunning, ShieldRunning = false;
    public Text EndGame_HighScore;
    public GameData Gamedata = new GameData();
    


    void Start()
    {
        score = 0;
        transform.position = new Vector3(0, 0, 0);
        spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        AudioSource = GetComponent<AudioSource>();

        if (spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL.");
        }

        if (uiManager == null)
        {
            Debug.LogError("The UI Manager is NULL!");
        }

        if (AudioSource == null)
        {
            Debug.LogError("AudioSource on the player is NULL");
        }
        else
        {
            AudioSource.clip = LaserSound;
        }
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > canFire)
        {
            Laser();
        }

        if (TrippleShotCooldown == true)
        {
            TrippleShotImage.fillAmount -= 1 / CoolDown * Time.deltaTime;
        }
        if (SpeedCooldown == true)
        {
            SpeedImage.fillAmount -= 1 / CoolDown * Time.deltaTime;
        }
        if (ShieldCooldown == true)
        {
            ShieldImage.fillAmount -= 1 / CoolDown * Time.deltaTime;
        }
    }
       
    void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 direction = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -3.8f)
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        if (transform.position.x > 10.77f)
        {
            transform.position = new Vector3(-10.77f, transform.position.y, 0);
        }
        else if (transform.position.x < -10.77f)
        {
            transform.position = new Vector3(10.77f, transform.position.y, 0);
        }
    }
       
    void Laser()
    {
        canFire = Time.time + fireRate;

        if (isTripleShotActive == true)
        {
            Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0f, 1.05f), Quaternion.identity);
        }


        AudioSource.Play();
    }

    public void Damage()
    {

        if (isShieldsActive == true)
        {
            isShieldsActive = false;
            shieldVisualizer.SetActive(false);
            ShieldButton.SetActive(false);
            return;
        }

        lives--;
        Audio.Play();
        uiManager.UpdateLives(lives);

        if (lives == 2)
        {
            leftEngine.SetActive(true);
        }
        else if (lives == 1)
        {
            rightEngine.SetActive(true);
        }

        if (lives  < 1)
        {
            spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }

    public void TripleShotActive()
    {
        isTripleShotActive = true;
        TrippleShotButton.SetActive(true);
        TrippleShotCooldown = true;
        TrippleShotImage.fillAmount = 1;

        if (TrippleShotRunning == true)
        {
            StopCoroutine(coroutineTripple);
        }
        coroutineTripple = StartCoroutine(TripleShotPowerDownRoutine());
    }

    IEnumerator TripleShotPowerDownRoutine()
    {
        TrippleShotRunning = true;
        yield return new WaitForSeconds(10f);
        TrippleShotRunning = false;

        isTripleShotActive = false;
        TrippleShotButton.SetActive(false);
        TrippleShotCooldown = false;
    }

    public void SpeedBoostActive()
    {
        isSpeedBoostActive = true;
        speed = speedMultiplier;
        SpeedButton.SetActive(true);
        SpeedCooldown = true;
        SpeedImage.fillAmount = 1;

        if (SpeedRunning == true)
        {
            StopCoroutine(coroutineSpeed);
        }
        coroutineSpeed = StartCoroutine(SpeedBoostPowerDownRoutin());
    }

    IEnumerator SpeedBoostPowerDownRoutin()
    {
        SpeedRunning = true;
        yield return new WaitForSeconds(10f);
        SpeedRunning = false;

        isSpeedBoostActive = false;
        speed = Speed1;
        SpeedButton.SetActive(false);
        SpeedCooldown = false;
    }

    public void ShieldsActive()
    {
        isShieldsActive = true;
        shieldVisualizer.SetActive(true);
        ShieldButton.SetActive(true);
        ShieldImage.fillAmount = 1;
        ShieldCooldown = true;
        

        if (ShieldRunning == true)
        {
            StopCoroutine(coroutineShield);
        }
        coroutineShield = StartCoroutine(ShieldBoostPowerDownRoutin());
    }

    IEnumerator ShieldBoostPowerDownRoutin()
    {
        ShieldRunning = true;
        yield return new WaitForSeconds(10f);
        ShieldRunning = false;
        ShieldCooldown = false;

        isShieldsActive = false;
        shieldVisualizer.SetActive(false);
        ShieldButton.SetActive(false);

    }

    public void AddScore(int points)
    {
        score += points;
        uiManager.UpdateScore(score);
    }

    public void Heal()
    {
        if (lives < 3 && lives >= 1)
        {
            lives++;
            uiManager.UpdateLives(lives);

            switch(lives)
            {
                case 3:
                    leftEngine.SetActive(false);
                    rightEngine.SetActive(false);
                    return;
                case 2:
                    leftEngine.SetActive(true);
                    rightEngine.SetActive(false);
                    return;
                case 1:
                    leftEngine.SetActive(true);
                    rightEngine.SetActive(true);
                    return;
                default:
                    return;
            }
        }

    }
}
