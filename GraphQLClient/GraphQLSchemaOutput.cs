using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLClient
{
    public class QueryType
    {
        public string name { get; set; }
    }

    public class MutationType
    {
        public string name { get; set; }
    }

    public class OfType
    {
        public string kind { get; set; }
        public string name { get; set; }
        public object ofType { get; set; }
    }



    public class Arg
    {
        public string name { get; set; }
        public string description { get; set; }
        public Type type { get; set; }
        public string defaultValue { get; set; }
    }

    public class Field
    {
        public string name { get; set; }
        public string description { get; set; }
        public IList<Arg> args { get; set; }
        public InterfaceType type { get; set; }
        public bool isDeprecated { get; set; }
        public object deprecationReason { get; set; }
    }

    public class InputField
    {
        public string name { get; set; }
        public object description { get; set; }
        public InterfaceType type { get; set; }
        public object defaultValue { get; set; }
    }

    public class InterfaceType
    {
        public string kind { get; set; }
        public string name { get; set; }
        public object ofType { get; set; }
    }

    public class EnumValue
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool isDeprecated { get; set; }
        public object deprecationReason { get; set; }
    }

    public class PossibleType
    {
        public string kind { get; set; }
        public string name { get; set; }
        public object ofType { get; set; }
    }
    public class Type
    {
        public string kind { get; set; }
        public string name { get; set; }
        public OfType ofType { get; set; }
        public string description { get; set; }
        public IList<Field> fields { get; set; }
        public IList<InputField> inputFields { get; set; }
        public IList<InterfaceType> InterfaceTypes { get; set; }
        public IList<EnumValue> enumValues { get; set; }
        public IList<PossibleType> possibleTypes { get; set; }
    }

    public class Schema
    {
        public QueryType queryType { get; set; }
        public MutationType mutationType { get; set; }
        public IList<Type> types { get; set; }
    }

    public class Data
    {
        public Schema __schema { get; set; }
    }

    public class GraphQLSchemaOutput
    {
        public Data data { get; set; }
    }
}



