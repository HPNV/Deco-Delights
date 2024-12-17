using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerStateManager : MonoBehaviour
{
    private ICustomerState currentState;

    public void SetState(ICustomerState newState, Customer customer)
    {
        currentState?.ExitState(customer);
        currentState = newState;
        currentState.EnterState(customer);
    }

    public void UpdateState(Customer customer)
    {
        currentState?.UpdateState(customer);
        Debug.Log(currentState);
    }

    public ICustomerState GetCurrentState()
    {
        return currentState;
    }
}
