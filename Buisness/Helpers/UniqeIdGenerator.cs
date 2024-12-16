

namespace Buisness.Helpers
{
    public class UniqeIdGenerator
    {
        public static string GenerateUniqeId() => Guid.NewGuid().ToString(); 
    }
}
