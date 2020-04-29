namespace Todo.Shared.Command
{
    public class CommandResult
    {
        public bool Success { get; private set; }
        public string Menssage { get; private set; }
        public object Content { get; private set; }

        public CommandResult(bool success, string menssage, object content)
        {
            Success = success;
            Menssage = menssage;
            Content = content;
        }

        public CommandResult()
        {
        }
    }
}