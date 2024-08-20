namespace Helper{

    public interface IPasswordHandler{
        public string HashPassword(string password);

        public bool VerifyPassword(string password, string storedHash);
    }
}