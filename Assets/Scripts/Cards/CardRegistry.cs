using BatalladeMundos;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Animations.AimConstraint;

[CreateAssetMenu(menuName = "Batalla de Mundos/Card Registry", fileName = "CardRegistry")]
public class CardRegistry : ScriptableObject
{
    [Header("— CARTAS DE ESTRATEGIA")]
    public List<CardData> allStrategyCards = new();

    [Header("— CARTAS DE ARMAS")]
    public List<CardData> allWeaponCards = new();

    public List<CardData> GetStrategyCardsByWorld(WorldType world)
        => allStrategyCards.Where(c => c != null && c.world == world).ToList();

    public List<CardData> GetAllBeings()
        => allStrategyCards.Where(c => c != null && c.type == CardType.Ser).ToList();

    public List<CardData> GetAllSupports()
        => allStrategyCards.Where(c => c != null && c.type == CardType.Apoyo).ToList();

    public CardData GetCardById(string id)
        => allStrategyCards.Concat(allWeaponCards)
                           .FirstOrDefault(c => c != null && c.cardId == id);

#if UNITY_EDITOR
    private void OnValidate()
    {
        int nullStrategy = allStrategyCards.Count(c => c == null);
        int nullWeapons = allWeaponCards.Count(c => c == null);

        if (nullStrategy > 0)
            Debug.LogWarning($"[Registry] {nullStrategy} null en estrategia");

        if (nullWeapons > 0)
            Debug.LogWarning($"[Registry] {nullWeapons} null en armas");

        Debug.Log($"[Registry] Total: {allStrategyCards.Count} / {allWeaponCards.Count}");
    }
#endif
}
