using System.Collections.Frozen;
using System.Collections.Generic;

namespace GPO_BLAZOR.Client.Class.Date
{
    public record Field :  IField
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Text { get; init; }
        public string ClassType { get; init; }

        public bool IsDisabled { get; init; }

        public string value { get; set; } = "";

        public IEnumerable<KeyValuePair<string, IField>> GetValues()
        {
           Stack<KeyValuePair<string, IField>> result = new Stack<KeyValuePair<string, IField>>();

           result.Push(new KeyValuePair<string, IField>(Id, this));

            return result;
        }

    }
}