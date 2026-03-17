using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIService : MonoBehaviour
{
    private string url = "https://api.jsonbin.io/v3/b/6686a992e41b4d34e40d06fa";

    public void FetchData(Action<ApiResponse> onSuccess, Action<string> onError)
    {
        StartCoroutine(GetRequest(onSuccess, onError));
    }

    IEnumerator GetRequest(Action<ApiResponse> onSuccess, Action<string> onError)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API Request Failed: " + request.error);
            onError?.Invoke(request.error);
        }
        else
        {
            string json = request.downloadHandler.text;

            Debug.Log("RAW JSON: " + json);

            ApiResponse data = JsonUtility.FromJson<ApiResponse>(json);

            if (data == null || data.record == null || data.record.items == null)
            {
                Debug.LogError("JSON parsing failed or returned empty data.");
                onError?.Invoke("JSON parsing failed.");
                yield break;
            }

            Debug.Log("Items received: " + data.record.items.Count);

            onSuccess?.Invoke(data);
        }
    }
}