public interface ICustomerState
{
    void EnterState(Customer customer);
    void UpdateState(Customer customer);
    void ExitState(Customer customer);
}
