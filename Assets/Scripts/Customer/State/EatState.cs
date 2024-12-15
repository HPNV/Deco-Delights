using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatState : ICustomerState
{
    float eatTime = 0f;
    public void EnterState(Customer customer)
    {
        eatTime = customer.customerData.eatTime;
        customer.requestUI.SetActive(false);
    }

    public void ExitState(Customer customer)
    {
        
    }

    public void UpdateState(Customer customer)
    {
        eatTime -= Time.deltaTime;
        if (eatTime <= 0)
        {
            customer.customerStateManager.SetState(new LeaveState(), customer);
        }
    }
}
