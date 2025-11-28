namespace MovieApp.Data
{
    public class Role
    {

        public const string Lead = "LEAD";
        public const string Supporting = "SUPPORTING";
        public const string Extra = "EXTRA";

        // getter for constants
        public static readonly string[] AllRoles = { Lead, Supporting, Extra };
    }
}
