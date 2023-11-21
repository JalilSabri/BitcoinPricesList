using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Net.Mime.MediaTypeNames;

namespace GlobalTeknoloji.UnitTest;

[TestClass]
public class BitcoinTests
{
    private HttpClient _client;

    public BitcoinTests()
    {
        //var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        //_client = server.CreateClient();
    }

    [TestMethod]
    public void BitcoinGetAllTest()
    {
        var request = new HttpRequestMessage(new HttpMethod("Get"), "/Api/Bitcoins");

        var response = _client.SendAsync(request).Result;

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    [DataRow(1)]
    public void CustomerGetOneTest(int id)
    {
        var request = new HttpRequestMessage(new HttpMethod("Get"), $"/Api/Bitcoins/{id}");

        var response = _client.SendAsync(request).Result;

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
    }

    [TestMethod]
    public void CustomerPostTest()
    {
        var request = new HttpRequestMessage(new HttpMethod("POST"), $"/Api/Bitcoins");

        var response = _client.SendAsync(request).Result;

        Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
