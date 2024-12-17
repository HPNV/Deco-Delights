using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Manager Prefabs")]
    [SerializeField] private GameObject queueManagerPrefab;
    [SerializeField] private GameObject orderManagerPrefab;
    [SerializeField] private GameObject workSpaceManagerPrefab;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeManagers();
    }

    private void InitializeManagers()
    {
        EnsureManagerExists(queueManagerPrefab);
        EnsureManagerExists(orderManagerPrefab);
        EnsureManagerExists(workSpaceManagerPrefab);
    }

    private void EnsureManagerExists(GameObject managerPrefab)
    {
        string managerName = managerPrefab.name;
        if (GameObject.Find(managerName) == null)
        {
            GameObject managerInstance = Instantiate(managerPrefab);
            managerInstance.name = managerName;
        }
    }

    public void UpdateScore() {
        score += 100;
        scoreText.text = score.ToString();
    }
}
