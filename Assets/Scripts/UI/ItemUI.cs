using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text categoryText;
    public TMP_Text priceText;

    public void Setup(Item item)
    {
        if (nameText != null)
            nameText.text = item.name;

        if (categoryText != null)
            categoryText.text = item.category;

        if (priceText != null)
            priceText.text = "$" + item.price.ToString("F2");
    }
}