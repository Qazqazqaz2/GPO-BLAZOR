using DBAgent;
using GPO_BLAZOR.FiledConfiguration;
using GPO_BLAZOR.FiledConfiguration;
using GPO_BLAZOR.FiledConfiguration.Document;
using GPO_BLAZOR.FiledConfiguration.FieldCont;
using System.Collections.Frozen;
using System.Collections.Immutable;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace GPO_BLAZOR.FiledConfiguration
{
    interface INamed
    {
        string Name { get; }
    }

    namespace Document
    {
        interface IDocument: INamed
        {
            string Description { get; }
            IEnumerable<IFields> Fields { get; }
        }

        interface IFields: INamed
        {
            string Attribute { get; }
            IDictionary<string, IAttribute> Attributes { get; }
            [XmlIgnore]
            [JsonIgnore]
            FrozenFields Froze { get; }
        }

        interface IAttribute: INamed;

        [Serializable]
        record struct Documnet : IDocument
        {
            public readonly string Name { get; init; }
            public readonly string Description { get; init; }
            private Stack<IFields> _fields;
            public IEnumerable<IFields> Fields 
            { 
                get => _fields; 
                init => _fields = new Stack<IFields>(value); 
            }
        }

        record struct Fields : IFields
        {
            public string Name { get; init; }
            public string Attribute { get; init; }
            private Dictionary<string, IAttribute> _attributes;
            public IDictionary<string, IAttribute> Attributes { get;}
            [XmlIgnore]
            [JsonIgnore]
            public FrozenFields Froze { get => new FrozenFields(Name, Attribute, _attributes.ToFrozenDictionary()); }
        }

        record struct FrozenFields : IFields
        {
            public FrozenFields (string Name, string Attribute, FrozenDictionary<string, IAttribute> Attributes)
            {
                this.Name = Name;
                this.Attribute = Attribute;
                _attributes = Attributes;
            }
            public readonly string Name { get; init; }
            public readonly string Attribute { get; init; }
            private FrozenDictionary<string, IAttribute> _attributes;
            public IDictionary<string, IAttribute> Attributes { get => _attributes; }
            [XmlIgnore]
            [JsonIgnore]
            public FrozenFields Froze { get => this with { _attributes = _attributes.ToFrozenDictionary()};}

        }

        record struct Attribute: IAttribute
        {
            public readonly string Name { get; init; }
        }
    }

    namespace FieldCont
    {
        interface IPath
        {
            string Page { get; }
            string Block { get; }
        }
        interface IAccesorFabric<AccessorType>: INamed
            where AccessorType: IAccessor, 
            allows ref struct
        {
            AccessorType GetAccessor (string name);
        }

        interface IFieldsRec<in AccessorType>: INamed
            where AccessorType : IAccessor,
            allows ref struct
        {
            IPath Path { get; }
            FieldDateContainer Template { get; }
        }

        interface IField<AccessorType> : IFieldsRec<AccessorType>, IAccesorFabric<AccessorType>
            where AccessorType: IAccessor, 
            allows ref struct;

        interface IField: IField<Accessor>;
        interface IAccessor: INamed
        {
            string Value { get; set; }
        }
        record struct Path : IPath
        {
            public readonly string Page { get; init; }
            public readonly string Block { get; init; }
        }


        ref struct Accessor : IAccessor
        {
            public Accessor (Func<string, string> Getter, Action<string, string> Setter)
            {
                _getter = Getter;
                _setter = Setter;
            }

            Func<string, string> _getter;
            Action<string, string> _setter;

            public string Name { get; init; }
            public string Value { get => _getter(Name); set => _setter(Name, value); }
        }

        [Serializable]
        record struct Field : IField
        {
            private Path _path = new Path();
            public IPath Path { get => _path; init => SetPath(value) ; }

            private void SetPath (IPath ValuePath)
            {
                var tempValue = ValuePath as Path?;

                if (tempValue != null)
                {
                    _path = tempValue.Value;
                }
                else
                {
                    _path = new Path() { Block = ValuePath.Block, Page = ValuePath.Page};
                }
            }
            public Field(Gpo2Context context, Func<string, string> Getter, Action<string, string> Setter)
            {
                cntx = context;
                _getter = Getter;
                _setter = Setter;
            }
            Func<string, string> _getter;
            Action<string, string> _setter;
            public string Name { get; init; }

            [NonSerialized]
            [XmlIgnore]
            [JsonIgnore]
            private Gpo2Context cntx;
            public FieldDateContainer Template { get; init; }

            public Accessor GetAccessor(string Name)
            {
                return new Accessor(_getter, _setter) { Name = Name };
            }
        }
    }


    static class Constructor
    {
        public static IDictionary<string, IDateContainer<PageDateContainer>> GetFields (IList<IField> Fields, IEnumerable<IDocument> Document, out IDictionary<string, IField> FieldsDictionary)
        {
            FieldsDictionary = Fields.Select(static x => KeyValuePair.Create(x.Name, x)).ToFrozenDictionary();

            var GetDocFieldsTuple = static (IDictionary<string, IField> Fields) => (IDocument document) => ((DocName: document, Field: document.Fields.Select(f => Fields[f.Name])));
            var DocsFieldConnect = Document.Select(GetDocFieldsTuple (FieldsDictionary));

            static IDateContainer<PageDateContainer> ContainerCreator(IField Field)
            {
                var block = new BlockDateContainer(Field.Path.Block, [Field.Template]);
                return new StatmenDateContainer([new PageDateContainer(Field.Path.Page, [block])]);
            }

            var result = DocsFieldConnect
                .Select(static x => (Name: x.DocName.Name, Struct: x.Field
                    .Aggregate(new StatmenDateContainer() as IDateContainer<PageDateContainer>, (a, b) => a.Summ(ContainerCreator(b)))))
                .Select(static x=>new KeyValuePair<string, IDateContainer<PageDateContainer>>(x.Name, x.Struct.ToFronzeFieldContainer())).ToFrozenDictionary();

            return result;
                
        }
    }
    
}
