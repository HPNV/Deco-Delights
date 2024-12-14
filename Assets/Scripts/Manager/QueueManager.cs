using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public static QueueManager Instance { get; private set; }

    [Header("Queue Configuration")]
    [SerializeField] private Vector3[] queuePositions = new Vector3[3];
    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private float spawnDelay = 2f;

    [Header("Customer Data")]
    [SerializeField] private List<CustomerData> customerDatabase = new List<CustomerData>();

    private readonly List<GameObject> customers = new List<GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeQueuePositions();
    }

    private void Start()
    {
        StartCoroutine(SpawnCustomersRoutine());
    }

    private void InitializeQueuePositions()
    {
        Vector3 Position1 = new Vector3(-7f, 0, 0);
        Vector3 Position2 = new Vector3(-4f, 0, 0);
        Vector3 Position3 = new Vector3(-1f, 0, 0);

        queuePositions[0] = Position1;
        queuePositions[1] = Position2;
        queuePositions[2] = Position3;
    }

    private IEnumerator SpawnCustomersRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            TrySpawnCustomer();
        }
    }

    private void TrySpawnCustomer()
    {
        if (customers.Count < queuePositions.Length)
        {
            CustomerData customerData = GetRandomCustomerData();
            GameObject customerObject = Instantiate(customerPrefab, queuePositions[customers.Count], Quaternion.identity);
            Customer customer = customerObject.GetComponent<Customer>();
            customer.SetData(customerData);
            customers.Add(customerObject);
        }
    }

    private CustomerData GetRandomCustomerData()
    {
        return customerDatabase[Random.Range(0, customerDatabase.Count)];
    }

    public void RemoveCustomer(GameObject customer)
    {
        if (customers.Contains(customer))
        {
            customers.Remove(customer);
            Destroy(customer);
            UpdateQueuePositions();
        }
    }

    private void UpdateQueuePositions()
    {
        for (int i = 0; i < customers.Count; i++)
        {
            customers[i].transform.position = queuePositions[i];
        }
    }
}
