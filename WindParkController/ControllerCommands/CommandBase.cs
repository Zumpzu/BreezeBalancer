namespace WindParkController.ControllerCommands
{
    public abstract class CommandBase<T> : ICommand<T>
    {
        public CommandBase(T obCommandData)
        {
            CommandData = obCommandData;
        }
        protected T CommandData { get; set; }
        public abstract Task<T> ExecuteAsync();
    }
    public interface ICommand<TResult>
    {
        Task<TResult> ExecuteAsync();
    }
}
