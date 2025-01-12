using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class LeaveState : ICustomerState
{
    float LeaveTime = 0f;
    public Sprite newSprite;

    public void EnterState(Customer customer)
    {
        if(customer.isServed) {
            GameManager.Instance.UpdateScore();
            customer.Leave();
        } else {
            LifeManager.Instance.ReduceLife();
            //ChangeSprite(customer.gameObject, newSprite);
            LeaveAfterDelayAsync(customer);
        }

    }

    public void ExitState(Customer customer)
    {
        
    }

    public void UpdateState(Customer customer)
    {
        
    }

    private void ChangeSprite(GameObject targetObject, Sprite newSprite)
    {
        SpriteRenderer spriteRenderer = targetObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer not found on target object!");
        }
    }

    private async void LeaveAfterDelayAsync(Customer customer)
    {
        
        await Task.Delay(1000);
        customer.Leave();
    }
}
