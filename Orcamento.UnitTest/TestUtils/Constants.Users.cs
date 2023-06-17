namespace Orcamento.UnitTest.TestUtils;

public static partial class Constants
{
    public static class User
    {
        public const string Id = "53961ACE-911B-47A5-9CB6-035CA2FB81EC";
        public const string FirstName = "First Name";
        public const string LastName = "Last Name";
        public const string Email = "User Email";
        public const string Password = "User Password";
        public const string PasswordHash = "User Password";
        public const string PasswordSalt = "User Password";

        public static string UserIdFromIndex(int index) => $"{Id} {index}";
        public static string UserFirstNameFromIndex(int index) => $"{FirstName} {index}";
        public static string UserLastNameFromIndex(int index) => $"{LastName} {index}";
        public static string UserEmailFromIndex(int index) => $"{Email} {index}";
        public static string UserPasswordFromIndex(int index) => $"{Password} {index}";
        
    }
}