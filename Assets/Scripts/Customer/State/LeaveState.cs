using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveState : ICustomerState
{
    public void EnterState(Customer customer)
    {
        if(customer.isServed)
        {
            customer.ShowDialog("Thank you!");
        } else
        {
            customer.ShowDialog("I'm leaving!");
        }
    }

    public void ExitState(Customer customer)
    {
        customer.Leave();
    }

    public void UpdateState(Customer customer)
    {
        
    }
}
