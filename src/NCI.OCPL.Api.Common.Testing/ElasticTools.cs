using System;
using System.Collections.Generic;

using Elasticsearch.Net;
using Nest;

namespace NCI.OCPL.Api.Common.Testing
{

    /// <summary>
    /// Tools for mocking elasticsearch clients
    /// </summary>
    public static class ElasticTools {

        /// <summary>
        /// Gets an ElasticClient backed by an InMemoryConnection.  This is used to mock the
        /// JSON returned by the elastic search so that we test the Nest mappings to our models.
        /// </summary>
        /// <param name="testFile"></param>
        /// <returns></returns>
        public static IElasticClient GetInMemoryElasticClient(string testFile) {

            //Get Response JSON
            byte[] responseBody = TestingTools.GetTestFileAsBytes(testFile);

            //While this has a URI, it does not matter, an InMemoryConnection never requests
            //from the server.
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));

            // Setup ElasticSearch stuff using the contents of the JSON file as the client response.
            InMemoryConnection conn = new InMemoryConnection(responseBody);

            var connectionSettings = new ConnectionSettings(pool, conn);

            return new ElasticClient(connectionSettings);
        }

        /// <summary>
        /// Gets an ElasticClient which simulates a failed request.  Success is defined by
        /// statuses with a 200-series response, so anything from the 400 or 503 series
        /// should be treated as an error.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static IElasticClient GetErrorElasticClient(int statusCode)
        {
          //While this has a URI, it does not matter, an InMemoryConnection never requests
          //from the server.
          var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));

          //Get Response JSON
          byte[] responseBody = new byte[0];

          // Setup ElasticSearch stuff using the contents of the JSON file as the client response.
          InMemoryConnection conn = new InMemoryConnection(responseBody, statusCode);

          var connectionSettings = new ConnectionSettings(pool, conn);

          return new ElasticClient(connectionSettings);
        }

  }
}