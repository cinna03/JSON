using UnityEngine;

public class UIManager : MonoBehaviour
{
    public APIService apiService;

    public Transform contentParent;
    public GameObject itemPrefab;

    void Start()
    {
        LoadData();
    }

    public void LoadData()
    {
        Debug.Log("Fetching API data...");
        apiService.FetchData(OnDataLoaded, OnError);
    }

    void OnDataLoaded(ApiResponse response)
    {
        Debug.Log("UI received items: " + response.record.items.Count);

        // Clear old items
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        // Spawn new items
        foreach (Item item in response.record.items)
        {
            Debug.Log("Creating UI item: " + item.name);

            GameObject obj = Instantiate(itemPrefab, contentParent, false);

            ItemUI ui = obj.GetComponent<ItemUI>();

            if (ui != null)
            {
                ui.Setup(item);
            }
            else
            {
                Debug.LogError("ItemUI component missing on prefab.");
            }
        }
    }

    void OnError(string error)
    {
        Debug.LogError("API Error: " + error);
    }

    // Optional refresh button
    public void RefreshData()
    {
        LoadData();
    }
}