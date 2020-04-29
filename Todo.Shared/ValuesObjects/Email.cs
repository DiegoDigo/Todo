namespace Todo.Shared.ValuesObjects
{
    public class Email
    {
        public string Address { get; private set; }


        public Email()
        {
        }

        public Email(string address)
        {
            Address = address;
        }
    }
}