using System.Diagnostics;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

// EXERCISE 9: GET Handle 404 Not Found
// TheMealDB API: https://themealdb.com/api/json/v1/1/lookup.php?i={id}
//
// Your task:
// 1. Use the HttpClient to look up a meal with an ID that doesn't exist (ID 999999)
// 2. Assert the HTTP status code is 200 OK (TheMealDB always returns 200)
// 3. Parse the JSON and assert that the "meals" field is null
//    (meaning no meal was found for that ID)
//
// This teaches: APIs can return 200 OK but still indicate "not found"
// in the response body via null data.

public static class HandleNotFound
{
    public static async Task Run(System.Net.Http.HttpClient client)
    {
        HttpResponseMessage response = await client.GetAsync("https://themealdb.com/api/json/v1/1/lookup.php?i=999999");
        Debug.Assert(response.StatusCode == System.Net.HttpStatusCode.OK, $"Expected HTTP 200 OK, but got {response.StatusCode}");

        string jsonResponse = await response.Content.ReadAsStringAsync();
        using JsonDocument document = JsonDocument.Parse(jsonResponse);

        JsonElement root = document.RootElement;
        JsonElement mealsElement = root.GetProperty("meals");

        bool isMealsNull = mealsElement.ValueKind == JsonValueKind.Null;

        Debug.Assert(isMealsNull, "Expected the 'meals' property to be null for an invalid ID lookup.");

        // TODO: Send GET request to https://themealdb.com/api/json/v1/1/lookup.php?i=999999
        // TODO: Assert status code is 200 OK
        // TODO: Parse the response JSON
        // TODO: Assert that "meals" field is null (not found)

    }
}
