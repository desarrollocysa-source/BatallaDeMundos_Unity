using BatalladeMundos;
using UnityEngine;
using static UnityEngine.Animations.AimConstraint;

[CreateAssetMenu(menuName = "Batalla de Mundos/Carta", fileName = "NuevaCarta")]
public class CardData : ScriptableObject
{
    [Header("— IDENTIDAD")]
    public string cardId;
    public string cardName;
    public Sprite artwork;

    [Header("— VISUALES PERSONALIZADOS")]
    public Sprite frameOverride;
    public Sprite worldIconOverride;
    public Sprite battleIconOverride;

    [Header("— CLASIFICACIÓN")]
    public WorldType world;
    public CardType type;
    public BattleType battleType;

    [Header("— ESTADÍSTICAS")]
    public int attack;
    public int defense;

    [Header("— HABILIDAD")]
    public bool hasAbility;

    [TextArea(3, 6)]
    public string effectDescription;

    public ActivationMode activationMode;

    [Header("— APOYO")]
    public SupportSubtype supportSubtype;
    public bool isPermanent;
    public int durationTurns;

    [Header("— ARMA")]
    public WeaponType weaponType;

#if UNITY_EDITOR
    private void OnValidate()
    {
        if (string.IsNullOrEmpty(cardId))
            Debug.LogWarning($"[CardData] '{cardName}' sin cardId");

        if (type != CardType.Ser)
        {
            attack = 0;
            defense = 0;
        }

        if (type != CardType.Apoyo)
        {
            isPermanent = false;
            durationTurns = 0;
        }

        if (type != CardType.Arma)
        {
            weaponType = WeaponType.Ninguno;
        }
    }
#endif
}
