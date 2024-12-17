using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public static OrderManager Instance { get; private set; }
    [SerializeField] private List<Sprite> bases = new List<Sprite>();
    [SerializeField] private List<Sprite> toppings = new List<Sprite>();
    [SerializeField] private List<Sprite> creams = new List<Sprite>();

    [SerializeField] private GameObject cakePrefab;

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
    
    public void ValidateOrder(Customer customer, string order)
    {
        if (customer.GetRequest().Equals(order))
        {
            customer.isServed = true;
        }
    }

    public GameObject GenerateRandomOrder()
    {
        Sprite baseOrder = bases[UnityEngine.Random.Range(0, bases.Count)];
        Sprite creamOrder = creams[UnityEngine.Random.Range(0, creams.Count)];
        Sprite toppingOrder = toppings[UnityEngine.Random.Range(0, toppings.Count)];

        GameObject cake = cakePrefab;
        cake.GetComponent<Cake>().SetCake(baseOrder, toppingOrder, creamOrder);

        return cake;
    }
}
