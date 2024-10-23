using System;
using System.Collections;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;


public class HTTPRequests : MonoBehaviour
{
    public TextMeshProUGUI email1, fname1, lname1;
    public TextMeshProUGUI email2, fname2, lname2;
    public TextMeshProUGUI email3, fname3, lname3;
    public TextMeshProUGUI email4, fname4, lname4;
    public TextMeshProUGUI test;
    private const string MAIN = "https://reqres.in/api";
    private const string USER1 = "https://reqres.in/api/users/1";
    private const string USER2 = "https://reqres.in/api/users/2";
    private const string USER3 = "https://reqres.in/api/users/3";
    private const string USER4 = "https://reqres.in/api/users/4";
    private const string REG = "/register";
    [SerializeField] private RawImage image, image2, image3, image4;
    private IEnumerator Start()
    {
        //var userData = "{\"email\": \"eve.holt@reqres.in\", \"password\": \"pistol\" }";
        var PutRequest = "{\" name\": \"morpheus\", \"job\": \"zion resident\" }";
        var userData = new { name = "morpheus", job = "leader" };
        yield return HttpGetRequest(USER1);
        yield return HttpGetRequest2(USER2);
        yield return HttpGetRequest3(USER3);
        yield return HttpGetRequest4(USER4);
        //yield return HttpPostRequest(MAIN + REG + "/2", PutRequest);
        //yield return HttpDeleteRequest(MAIN + REG + "/4");
        yield return GetTextureFromUri1("https://reqres.in/img/faces/1-image.jpg");
        yield return GetTextureFromUri2("https://reqres.in/img/faces/2-image.jpg");
        yield return GetTextureFromUri3("https://reqres.in/img/faces/3-image.jpg");
        yield return GetTextureFromUri4("https://reqres.in/img/faces/4-image.jpg");
        //test.text = PutRequest;
    }

    private IEnumerator HttpGetRequest(string uri)
    {
        var request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            var response = JsonConvert.DeserializeObject<Authentication>(request.downloadHandler.text);
            Debug.Log("Response: " + request.downloadHandler.text);
            // Assuming the JSON structure, access the desired fields
            Debug.Log("Email: " + response.data.email);
            Debug.Log("First Name: " + response.data.first_name);
            Debug.Log("Last Name: " + response.data.last_name); // Adjust if the year is nested differently
            Debug.Log(request.downloadHandler.text);
            email1.text = response.data.email;
            fname1.text = response.data.first_name;
            lname1.text = response.data.last_name;
        }
    }
    private IEnumerator HttpGetRequest2(string uri)
    {
        var request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            var response = JsonConvert.DeserializeObject<Authentication>(request.downloadHandler.text);
            Debug.Log("Response: " + request.downloadHandler.text);
            // Assuming the JSON structure, access the desired fields
            Debug.Log("Email: " + response.data.email);
            Debug.Log("First Name: " + response.data.first_name);
            Debug.Log("Last Name: " + response.data.last_name); // Adjust if the year is nested differently
            Debug.Log(request.downloadHandler.text);
            email2.text = response.data.email;
            fname2.text = response.data.first_name;
            lname2.text = response.data.last_name;
        }
    }
    private IEnumerator HttpGetRequest3(string uri)
    {
        var request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            var response = JsonConvert.DeserializeObject<Authentication>(request.downloadHandler.text);
            Debug.Log("Response: " + request.downloadHandler.text);
            // Assuming the JSON structure, access the desired fields
            Debug.Log("Email: " + response.data.email);
            Debug.Log("First Name: " + response.data.first_name);
            Debug.Log("Last Name: " + response.data.last_name); // Adjust if the year is nested differently
            Debug.Log(request.downloadHandler.text);
            email3.text = response.data.email;
            fname3.text = response.data.first_name;
            lname3.text = response.data.last_name;
        }
    }
    private IEnumerator HttpGetRequest4(string uri)
    {
        var request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            var response = JsonConvert.DeserializeObject<Authentication>(request.downloadHandler.text);
            Debug.Log("Response: " + request.downloadHandler.text);
            // Assuming the JSON structure, access the desired fields
            Debug.Log("Email: " + response.data.email);
            Debug.Log("First Name: " + response.data.first_name);
            Debug.Log("Last Name: " + response.data.last_name); // Adjust if the year is nested differently
            Debug.Log(request.downloadHandler.text);
            email4.text = response.data.email;
            fname4.text = response.data.first_name;
            lname4.text = response.data.last_name;
        }
    }
    /*private IEnumerator HttpPostRequest(string uri, string data)
    {
        Debug.Log("Posting data: " + data);
        var request = UnityWebRequest.Post(uri, data, "application/json");
        yield return request.SendWebRequest();

        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            var auth = JsonConvert.DeserializeObject<Authentication>(request.downloadHandler.text);
            Debug.LogError(auth.email);
        }
    }*/
    private IEnumerator HttpDeleteRequest(string uri)
    {
        var request = UnityWebRequest.Delete(uri);
        yield return request.SendWebRequest();

        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("User Deleted");
        }
    }

    private IEnumerator GetTextureFromUri1(string uri)
    {
        var request = UnityWebRequestTexture.GetTexture(uri);

        yield return request.SendWebRequest();
        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(request);
            if (image != null)
            {
                image.texture = texture;
            }
        }
    }
    private IEnumerator GetTextureFromUri2(string uri)
    {
        var request = UnityWebRequestTexture.GetTexture(uri);

        yield return request.SendWebRequest();
        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(request);
            if (image2 != null)
            {
                image2.texture = texture;
            }
        }
    }
    private IEnumerator GetTextureFromUri3(string uri)
    {
        var request = UnityWebRequestTexture.GetTexture(uri);

        yield return request.SendWebRequest();
        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(request);
            if (image3 != null)
            {
                image3.texture = texture;
            }
        }
    }
    private IEnumerator GetTextureFromUri4(string uri)
    {
        var request = UnityWebRequestTexture.GetTexture(uri);

        yield return request.SendWebRequest();
        if (request.result is UnityWebRequest.Result.ConnectionError or
            UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var texture = DownloadHandlerTexture.GetContent(request);
            if (image4 != null)
            {
                image4.texture = texture;
            }
        }
    }


}
[System.Serializable]
public struct Authentication
{
    public UserData data;
}

public struct UserData
{
    public string email;
    public string first_name;
    public string last_name;
}


