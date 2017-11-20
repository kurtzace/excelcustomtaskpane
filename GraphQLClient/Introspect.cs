using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLClient
{
    public class Introspect
    {
        public async System.Threading.Tasks.Task<Schema> doIntrospectAsync()
        {
            var client = new GraphQL.GraphQLClient("https://www.graphqlhub.com/graphql");
            var query = @"{
        __schema {
      queryType { name }
      mutationType { name }
      types {
        ...FullType
      }
    }
  }

  fragment FullType on __Type {
    kind
    name
    description
    fields(includeDeprecated: true) {
      name
      description
      args {
        ...InputValue
      }
      type {
        ...TypeRef
      }
      isDeprecated
      deprecationReason
    }
    inputFields {
      ...InputValue
    }
    interfaces {
      ...TypeRef
    }
    enumValues(includeDeprecated: true) {
      name
      description
      isDeprecated
      deprecationReason
    }
    possibleTypes {
      ...TypeRef
    }
  }

  fragment InputValue on __InputValue {
    name
    description
    type { ...TypeRef }
    defaultValue
  }

  fragment TypeRef on __Type {
    kind
    name
    ofType {
      kind
      name
      ofType {
        kind
        name
        ofType {
          kind
          name
        }
      }
    }
  }
";
            var obj = (await client.QueryAsync(query, null)).Get<Schema>("__schema");
            return obj;
        }
    }
}
