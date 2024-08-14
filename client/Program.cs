// See https://aka.ms/new-console-template for more information

using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;

// We expect DAB to be running on port 5000.
// This will be http://localhost:4280/data-api/graphql if you're using SWA CLI instead
var graphQlClient = new GraphQLHttpClient("http://localhost:5000/graphql/", new SystemTextJsonSerializer());

var conferencesResult = await graphQlClient.SendQueryAsync<ConferencesData>(new GraphQLRequest
{
    Query =
    @"{
        conferences {
            items {
                endDate
                id
                location
                mainTag
                startDate
                url
                year
                talks {
                    talkId
                    abstract
                    mainTag
                    tags
                    talkLength
                    talkTime
                    title
                }
            }
        }
    }"
});

var talksResult = await graphQlClient.SendQueryAsync<TalksData>(new GraphQLRequest
{
    Query =
    @"{
        talks {
          items {
            id
            mainTag
            title
          }
        }
      }"
});

Console.WriteLine($"You have {conferencesResult.Data.Conferences.Items.Count} conferences in cosmosdb");
Console.WriteLine($"You have {talksResult.Data.Talks.Items.Count} talks in cosmosdb");
Console.ReadKey();

public class ConferencesData
{
    public ConferenceList Conferences { get; set; } = new();
}

public class ConferenceList
{
    public List<Conference> Items { get; set; } = [];
}

public class Conference
{
    public DateOnly EndDate { get; set; }
    public string Id { get; set; }
    public string Location { get; set; }
    public string MainTag { get; set; }
    public string Name { get; set; }
    public DateOnly StartDate { get; set; }
    public string Url { get; set; }
    public int Year { get; set; }
    public List<ConferenceTalk> Talks { get; set; } = [];
}

public class ConferenceTalk
{
    public string TalkId { get; set; }
    public string Abstract { get; set; }
    public string MainTag { get; set; }
    public List<string> Tags { get; set; }
    public int TalkLength { get; set; }
    public string TalkTime { get; set; }
    public string Title { get; set; }
}

// Below is the code for the wrapper around talk data.
public class TalksData
{
    public TalkList Talks { get; set; } = new();
}

public class TalkList
{
    public List<Talk> Items { get; set; } = [];
}

public class Talk
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string MainTag { get; set; }
}
