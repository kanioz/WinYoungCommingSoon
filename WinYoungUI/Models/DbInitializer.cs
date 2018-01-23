namespace WinYoungUI.Models
{
    public static class DbInitializer
    {
        public static void Initialize(WinYoungContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
