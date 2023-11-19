namespace Persistence;

public class DbInitializer
{
    public static void Initialize(MeetingDbContext context)
    {
        context.Database.EnsureCreated();
    }
}