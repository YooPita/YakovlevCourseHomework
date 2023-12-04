public interface IState
{
    void Start();
    IState Execute();
}