using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour
{
    public static LifeManager Instance { get; private set; }

    [Header("Life Settings")]
    [SerializeField] private int initialLifeCount = 3;
    [SerializeField] private GameObject lifePrefab;
    private float iconSpacing = 2f;
    [SerializeField] private GameObject initialPosition;
    private int lifeCount;
    private List<GameObject> lifeIcons = new List<GameObject>();

    [SerializeField] private GameObject LoseScreen;
    [SerializeField] private GameObject MainMenuButton;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitializeLives();
        if (LoseScreen != null)
        {
            LoseScreen.SetActive(false);
            MainMenuButton.SetActive(false);
        }
    }

    private void InitializeLives()
    {
        lifeCount = initialLifeCount;
        SpawnLifeIcons();
    }

    private void SpawnLifeIcons()
    {
        foreach (GameObject icon in lifeIcons)
        {
            Destroy(icon);
        }
        lifeIcons.Clear();

        for (int i = 0; i < lifeCount; i++)
        {
            Vector3 position = CalculateLifeIconPosition(i);
            GameObject lifeIcon = Instantiate(lifePrefab, position, Quaternion.identity);
            lifeIcon.transform.SetParent(transform, false);
            lifeIcons.Add(lifeIcon);
        }
    }

    private Vector3 CalculateLifeIconPosition(int index)
    {
        float xPosition = initialPosition.transform.position.x - (index * iconSpacing);
        float yPosition = initialPosition.transform.position.y;
        return new Vector3(xPosition, yPosition, 0);
    }

    public void ReduceLife()
    {
        if (lifeCount <= 0) return;

        lifeCount--;
        DestroyLifeIcon();

        if (lifeCount <= 0)
        {
            GameOver();
        }
    }

    private void DestroyLifeIcon()
    {
        if (lifeIcons.Count > 0)
        {
            GameObject lastLifeIcon = lifeIcons[lifeIcons.Count - 1];
            lifeIcons.RemoveAt(lifeIcons.Count - 1);
            Destroy(lastLifeIcon);
        }
    }

    public void RespawnLives()
    {
        lifeCount = initialLifeCount;
        SpawnLifeIcons();
    }

    private void GameOver()
    {
        if (LoseScreen != null)
        {
            LoseScreen.SetActive(true);
            MainMenuButton.SetActive(true);
        }

        Time.timeScale = 0;

        StartCoroutine(QuitAfterDelay(5f));
    }

    private IEnumerator QuitAfterDelay(float delay)
    {
        Time.timeScale = 0;
        float realTimePassed = 0f;

        while (realTimePassed < delay)
        {
            realTimePassed += Time.unscaledDeltaTime;
            yield return null;
        }

        Application.Quit();
        //SceneManager.LoadScene(1);
    }


}
