using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;

    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public bool isGameActive;
    // Start is called before the first frame update
    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        isGameActive = true;
        titleScreen.gameObject.SetActive(false);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }

    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
