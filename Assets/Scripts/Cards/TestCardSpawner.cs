using BatalladeMundos;
using UnityEngine;

public class TestCardSpawner : MonoBehaviour
{
    public CardVisual cardPrefab;
    public CardData testCard;

    void Start()
    {
        CardVisual card = Instantiate(cardPrefab, transform);
        card.Load(testCard);
    }
}
