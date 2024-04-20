namespace Login
{
    public partial class Login
    {
        public class Admin
        {
            public static string Name()
            {
                return Usr.Admin.Name();
            }

            public static string Password()
            {
                return Usr.Admin.Key();
            }
        }
    }
}
