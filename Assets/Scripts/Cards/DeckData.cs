using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Batalla de Mundos/Mazo Predefinido", fileName = "NuevoMazo")]
public class DeckData : ScriptableObject
{
    [Header("— IDENTIDAD DEL MAZO")]
    public string deckName;
    public string deckId;
    public Sprite deckCover;

    [TextArea(2, 4)]
    public string deckDescription;

    [Header("— CARTAS DE ESTRATEGIA")]
    public List<CardData> strategyCards = new();

    [Header("— CARTAS DE ARMAS")]
    public List<CardData> weaponCards = new();

    public int StrategyCount => strategyCards.Count;
    public int WeaponCount => weaponCards.Count;

    public bool IsValid => StrategyCount == 40 && WeaponCount == 20;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (StrategyCount != 40)
            Debug.LogWarning($"[DeckData] {deckName}: {StrategyCount}/40 estrategia");

        if (WeaponCount != 20)
            Debug.LogWarning($"[DeckData] {deckName}: {WeaponCount}/20 armas");

        var strategyIds = new HashSet<string>();
        foreach (var card in strategyCards)
        {
            if (card == null) continue;

            if (!strategyIds.Add(card.cardId))
                Debug.LogWarning($"[DeckData] Duplicada: {card.cardName}");
        }

        var weaponIds = new HashSet<string>();
        foreach (var card in weaponCards)
        {
            if (card == null) continue;

            if (!weaponIds.Add(card.cardId))
                Debug.LogWarning($"[DeckData] Arma duplicada: {card.cardName}");
        }
    }
#endif
}
