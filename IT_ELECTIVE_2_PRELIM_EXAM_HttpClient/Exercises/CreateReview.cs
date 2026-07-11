using System.Diagnostics;
using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 6: POST Create Review
// JSONPlaceholder API: https://jsonplaceholder.typicode.com/posts
//
// Your task:
// 1. Create a JSON body string: { "title": "Great Pasta!", "body": "Loved this recipe", "userId": 1 }
// 2. Wrap it in StringContent with media type "application/json"
// 3. Send a POST request to the URL
// 4. Assert status code is 201 Created
// 5. Parse the response JSON and assert it contains an "id" field
//
// Hint: Use await client.PostAsync(url, content)
// Hint: Use new StringContent(json, Encoding.UTF8, "application/json")

public static class CreateReview
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        var reviewData = new
        {
            title = "Great Pasta!",
            body = "Loved this recipe",
            userId = 1
        };

        string jsonRequestBody = JsonSerializer.Serialize(reviewData);

        using HttpContent content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");
        HttpResponseMessage response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts", new StringContent("{\"title\": \"Great Pasta!\", \"body\": \"Loved this recipe\", \"userId\": 1}", System.Text.Encoding.UTF8, "application/json"));
       
        Debug.Assert(response.StatusCode == HttpStatusCode.Created, $"Expected HTTP 201 Created, but got {response.StatusCode}");

        string jsonResponse = await response.Content.ReadAsStringAsync();
        using JsonDocument document = JsonDocument.Parse(jsonResponse);

        JsonElement root = document.RootElement;

        bool hasIdField = root.TryGetProperty("id", out JsonElement idElement);

        Debug.Assert(hasIdField, "Expected response JSON to contain an 'id' field.");

        int generatedId = idElement.GetInt32();
        Debug.Assert(generatedId > 0, $"Expected a valid generated ID, but got {generatedId}");

        // TODO: Create JSON string with title, body, and userId
        // TODO: Create StringContent with the JSON and Content-Type "application/json"
        // TODO: Send POST request to https://jsonplaceholder.typicode.com/posts
        // TODO: Assert status code is 201 Created
        // TODO: Parse the response JSON
        // TODO: Assert the response has an "id" field with a value

    }
}
