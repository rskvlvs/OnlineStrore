namespace OnlineStrore.Exceptions
{
    public class AlreadyCreatedException : Exception
    {
        public AlreadyCreatedException(string Email): base($"User with email: {Email} has already been created!")
        { }
    }
}
