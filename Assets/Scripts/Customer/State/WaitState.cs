using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitState : ICustomerState
{
    float waitTime = 0f;
    public void EnterState(Customer customer)
    {
        waitTime = customer.customerData.patienceTime;
        customer.SetSliderMaxValue(waitTime);
    }

    public void ExitState(Customer customer)
    {

    }

    public void UpdateState(Customer customer)
    {
        waitTime -= Time.deltaTime;
        customer.SetSliderValue(waitTime);
        if (waitTime <= 0)
        {
            customer.customerStateManager.SetState(new LeaveState(), customer);
        }

        if (customer.isServed)
        {
            customer.customerStateManager.SetState(new EatState(), customer);
        }
    }
}
