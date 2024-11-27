using DBAgent;
using System.Collections.Frozen;

namespace GPO_BLAZOR.API_Functions
{
    public static class GetAtributes
    {
        public static string GetAtribute (in string AtributeName, in string UserName, IDictionary<string, Func<string, string>> MethodTable)
        {
            return MethodTable[AtributeName](UserName);
        }


    }
}
