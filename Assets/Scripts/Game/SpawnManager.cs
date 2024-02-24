using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject enemyContainer;
    [SerializeField]
    private GameObject[] powerups;
    private float SpawnSpeed;
    private float IncreaseSpawn = 10f;
    private bool stopSpawning = false;
    [SerializeField]
    private Image SpawnRateCoolDown;
    [SerializeField]
    private Text SpawnRateText;
    private float SpawnRatePercent = 10f;
    private bool IsCoolDown = false;
    private int GameDifficulty;
    private GameData GameData = new GameData();

    void Start()
    {
        GameDifficulty = GameData.GameDifficulty;

        switch (GameDifficulty)
        {
            case 1:
                SpawnSpeed = 4f;
                SpawnRateText.text = "Arcade: Beginner";
                return;
            case 2:
                SpawnSpeed = 3f;
                SpawnRateText.text = "Arcade: Easy";
                return;
            case 3:
                SpawnSpeed = 2f;
                SpawnRateText.text = "Arcade: Medium";
                return;
            case 4:
                SpawnSpeed = 1.5f;
                SpawnRateText.text = "Arcade: Hard";
                return;
            case 5:
                SpawnSpeed = 0.75f;
                SpawnRateText.text = "Arcade: Ultra hard";
                return;
            case 10:
                SpawnSpeed = 2.5f;
                SpawnRateText.text = "Challenge: 0%";
                return;
            default:
                Debug.LogError("Game Difficulty - missing!");
                return;
        }
    }

    private void Update()
    {
        if (IsCoolDown == true && stopSpawning == false)
        {
            SpawnRateCoolDown.fillAmount += 1 / 15f * Time.deltaTime;
        }
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupRoutine());
        if (GameDifficulty == 10)
        {
            StartCoroutine(ExecuteAfterTime());
        }
    }


    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(4f);

        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 8.5f, 0);
            GameObject newEnemy = Instantiate(enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(SpawnSpeed);
        }
    }


    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(4f);
        SpawnRateText.text = "Challenge: " + SpawnRatePercent + "%";
        IsCoolDown = true;
        yield return new WaitForSeconds(15f);

        while (SpawnSpeed > 0.7f && stopSpawning == false)
        {
            SpawnRateCoolDown.fillAmount = 0;
            SpawnSpeed -= 0.2f;
            SpawnRatePercent += 10f;
            SpawnRateText.text = "Challenge: " + SpawnRatePercent + "%";
            yield return new WaitForSeconds(15f);            
        }
    }


    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(4f);

        while (stopSpawning == false)
        {
            Vector3 postToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            int randomPowerUp = Random.Range(0, 4);
            Instantiate(powerups[randomPowerUp], postToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(4, 8));
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
}
