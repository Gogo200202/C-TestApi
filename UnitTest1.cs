using System.Collections.Generic;
using System.Reflection.Metadata;
using NUnit.Framework;
using NUnit.Framework.Internal;
using RestSharp;

namespace TestProject1;
//https://jsonplaceholder.typicode.com/
public class Tests
{

    private RestClient client;
    [SetUp]
    public void Setup()
    {
        client = new RestClient("https://jsonplaceholder.typicode.com");
    }

    [Test]
    public void GetAllPost()
    {

        RestRequest request = new RestRequest("/posts/", Method.Get);
        List<Post> queryResult = client.Execute<List<Post>>(request).Data;

        Assert.AreEqual(100, queryResult.Count);

    }

    [Test]
    public void ChekId()
    {

        RestRequest request = new RestRequest("/posts/1", Method.Get);
        Post queryResult = client.Execute<Post>(request).Data;

        Assert.AreEqual(queryResult.id, 1);

    }
    [Test]
    public void ChekUserId()
    {

        RestRequest request = new RestRequest("/posts/1", Method.Get);
        Post queryResult = client.Execute<Post>(request).Data;

        Assert.AreEqual(queryResult.userId, 1);

    }
    [Test]
    public void testPostId()
    {




        RestRequest request = new RestRequest("/posts", Method.Post);

        request.RequestFormat = DataFormat.Json;
        request.AddBody(new Post
        {
            title = "testGogo",
            body = "something",
            userId = 1
        });

        Post queryResult = client.Execute<Post>(request).Data;

        Assert.AreEqual(queryResult.id, 101);

    }
    [Test]
    public void testTitleId()
    {




        RestRequest request = new RestRequest("/posts", Method.Post);

        request.RequestFormat = DataFormat.Json;
        request.AddBody(new Post
        {
            title = "testGogo",
            body = "something",
            userId = 1
        });

        Post queryResult = client.Execute<Post>(request).Data;

        Assert.AreEqual(queryResult.title, "testGogo");

    }
    [Test]
    public void testPostBody()
    {




        RestRequest request = new RestRequest("/posts", Method.Post);

        request.RequestFormat = DataFormat.Json;
        request.AddBody(new Post
        {
            title = "testGogo",
            body = "something",
            userId = 1
        });

        Post queryResult = client.Execute<Post>(request).Data;

        Assert.AreEqual(queryResult.body, "something");

    }


    [Test]
    public void CheckPostComments()
    {

        RestRequest request = new RestRequest("posts/1/comments", Method.Get);
        List<Comments> queryResult = client.Execute<List<Comments>>(request).Data;

        Assert.AreEqual(queryResult.Count, 5);

    }

    [Test]
    public void CheckPostCommentsEmail()
    {

        RestRequest request = new RestRequest("posts/1/comments", Method.Get);
        List<Comments> queryResult = client.Execute<List<Comments>>(request).Data;

        Assert.AreEqual(queryResult[0].email, "Eliseo@gardner.biz");

    }



    [Test]
    public void UpdatePost()
    {

        RestRequest request = new RestRequest("/posts/1", Method.Patch);

        request.RequestFormat = DataFormat.Json;
        request.AddBody(new Post
        {
            title = "testGogo",
        });

        Post queryResult = client.Execute<Post>(request).Data;

        Assert.AreEqual(queryResult.title, "testGogo");

    }
}