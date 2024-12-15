using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveState : ICustomerState
{
    float LeaveTime = 0f;
    public void EnterState(Customer customer)
    {
        customer.Leave();
    }

    public void ExitState(Customer customer)
    {
        
    }

    public void UpdateState(Customer customer)
    {
        
    }
}
