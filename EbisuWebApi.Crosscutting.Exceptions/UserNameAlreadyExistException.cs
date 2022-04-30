using EbisuWebApi.Crosscutting.ResourcesManagement;

namespace EbisuWebApi.Crosscutting.Exceptions
{
    public class UserNameAlreadyExistException : Exception
    {
        public UserNameAlreadyExistException() : base(MessagesResource.UserNameAlreadyExist)
        {
        }
    }
}