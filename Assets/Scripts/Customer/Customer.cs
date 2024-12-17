using UnityEngine;
using TMPro;
using System.Collections;
using System;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public CustomerData customerData;
    public CustomerStateManager customerStateManager;
    public bool isServed = false;
    private SpriteRenderer spriteRenderer;
    private string request;
    [SerializeField] public GameObject requestUI;
    [SerializeField] private Slider slider;

    private void Start()
    {
        this.AddComponent<CustomerStateManager>();
        customerStateManager = GetComponent<CustomerStateManager>();
        customerStateManager.SetState(new WaitState(), this);
        request = SetRequest(OrderManager.Instance.GenerateRandomOrder());
    }

    public void SetData(CustomerData data)
    {
        customerData = data;
        this.AddComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = data.customerSprite;
    }

    private void Update()
    {
        customerStateManager.UpdateState(this);
    }

    public string SetRequest(GameObject cake)
    {
        Cake newCake = cake.GetComponent<Cake>();
        requestUI.GetComponent<CakeRequest>().SetCake(cake);
        return newCake.cakeString();
    }

    void ShowCake() {

    }

    public string GetRequest()
    {
        return request;
    }

    public void Leave()
    {
        QueueManager.Instance.RemoveCustomer(this.gameObject);
    }

    public void SetSliderValue(float value)
    {
        slider.value = value;
    }

    public void SetSliderMaxValue(float value)
    {
        slider.maxValue = value;
    }
}
