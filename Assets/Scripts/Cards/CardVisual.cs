using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BatalladeMundos
{
    public enum CardDisplayMode
    {
        SinHabilidad,
        MiniaturaConHabilidad,
        Completa
    }

    public class CardVisual : MonoBehaviour
    {
        [Header("— CAPAS VISUALES")]
        [SerializeField] private Image artworkSlot;
        [SerializeField] private Image cardFrame;
        [SerializeField] private Image battleTypeIcon;
        [SerializeField] private Image worldIcon;

        [Header("— PANEL DE DESCRIPCIÓN")]
        [SerializeField] private GameObject descriptionPanel;
        [SerializeField] private Image descriptionImage;
        [SerializeField] private TextMeshProUGUI descriptionText;

        [Header("— TEXTOS")]
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI attackText;
        [SerializeField] private TextMeshProUGUI defenseText;

        [Header("— MARCOS POR MUNDO")]
        [SerializeField] private Sprite[] framesByWorld = new Sprite[3];

        [Header("— DESCRIPCIÓN HINT")]
        [SerializeField] private Sprite[] descHintByWorld = new Sprite[3];

        [Header("— DESCRIPCIÓN COMPLETA")]
        [SerializeField] private Sprite[] descFullByWorld = new Sprite[3];

        [Header("— ÍCONOS DE MUNDO")]
        [SerializeField] private Sprite[] worldIconsByWorld = new Sprite[3];

        [Header("— ÍCONOS DE BATALLA")]
        [SerializeField] private Sprite iconAtaque;
        [SerializeField] private Sprite iconDefensa;
        [SerializeField] private Sprite iconHibrido;

        public CardData CardData { get; private set; }
        private CardDisplayMode currentMode;

        // MÉTODO CLAVE
        public void Load(CardData data)
        {
            CardData = data;

            int worldIndex = GetWorldIndex(data.world);

            // ── ARTWORK ──
            if (artworkSlot && data.artwork)
                artworkSlot.sprite = data.artwork;
            //artworkSlot.SetAllDirty();

            // FRAME
            if (data.frameOverride != null)
                cardFrame.sprite = data.frameOverride;
            else if (worldIndex >= 0 && worldIndex < framesByWorld.Length)
                cardFrame.sprite = framesByWorld[worldIndex];

            // ── ICONO MUNDO ──
            if (worldIcon)
            {
                bool hasWorld = data.world != WorldType.Ninguno;
                worldIcon.gameObject.SetActive(hasWorld);

                if (hasWorld)
                {
                    if (data.worldIconOverride != null)
                        worldIcon.sprite = data.worldIconOverride;
                    else if (worldIndex >= 0 && worldIndex < worldIconsByWorld.Length)
                        worldIcon.sprite = worldIconsByWorld[worldIndex];
                }
            }

            // ── ICONO BATALLA ──
            if (battleTypeIcon)
            {
                bool isBeing = data.type == CardType.Ser;
                battleTypeIcon.gameObject.SetActive(isBeing);

                if (isBeing)
                {
                    if (data.battleIconOverride != null)
                    {
                        battleTypeIcon.sprite = data.battleIconOverride;
                    }
                    else
                    {
                        switch (data.battleType)
                        {
                            case BattleType.Ataque:
                                battleTypeIcon.sprite = iconAtaque;
                                break;
                            case BattleType.Defensa:
                                battleTypeIcon.sprite = iconDefensa;
                                break;
                            case BattleType.Hibrido:
                                battleTypeIcon.sprite = iconHibrido;
                                break;
                        }
                    }
                }
            }

            // ── NOMBRE ──
            if (nameText)
                nameText.text = data.cardName;

            // ── STATS ──
            bool showStats = data.type == CardType.Ser;

            if (attackText) attackText.gameObject.SetActive(showStats);
            if (defenseText) defenseText.gameObject.SetActive(showStats);

            if (showStats)
            {
                if (attackText) attackText.text = data.attack.ToString();
                if (defenseText) defenseText.text = data.defense.ToString();
            }

            // ── MODO INICIAL ──
            SetDisplayMode(data.hasAbility
                ? CardDisplayMode.MiniaturaConHabilidad
                : CardDisplayMode.SinHabilidad);
        }

        // SOLUCIÓN PARA "Ninguno"
        private int GetWorldIndex(WorldType world)
        {
            if (world == WorldType.Ninguno)
                return -1;

            return (int)world - 1;
        }

        public void SetDisplayMode(CardDisplayMode mode)
        {
            currentMode = mode;

            int worldIndex = CardData != null ? GetWorldIndex(CardData.world) : -1;

            switch (mode)
            {
                case CardDisplayMode.SinHabilidad:
                    if (descriptionPanel) descriptionPanel.SetActive(false);
                    break;

                case CardDisplayMode.MiniaturaConHabilidad:
                    if (descriptionPanel) descriptionPanel.SetActive(true);

                    if (descriptionImage && worldIndex >= 0)
                        descriptionImage.sprite = descHintByWorld[worldIndex];

                    if (descriptionText)
                        descriptionText.gameObject.SetActive(false);
                    break;

                case CardDisplayMode.Completa:
                    if (descriptionPanel) descriptionPanel.SetActive(true);

                    if (descriptionImage && worldIndex >= 0)
                        descriptionImage.sprite = descFullByWorld[worldIndex];

                    if (descriptionText && CardData != null)
                    {
                        descriptionText.gameObject.SetActive(true);
                        descriptionText.text = CardData.effectDescription;
                    }
                    break;
            }
        }

        public void Expand()
        {
            if (CardData != null && CardData.hasAbility)
                SetDisplayMode(CardDisplayMode.Completa);
        }

        public void Collapse()
        {
            if (CardData != null)
                SetDisplayMode(CardData.hasAbility
                    ? CardDisplayMode.MiniaturaConHabilidad
                    : CardDisplayMode.SinHabilidad);
        }

        public void SetSelected(bool selected)
        {
            // luego animación
        }

        public void SetFaceDown(bool faceDown)
        {
            if (artworkSlot) artworkSlot.gameObject.SetActive(!faceDown);

            if (descriptionPanel)
                descriptionPanel.SetActive(
                    !faceDown && CardData != null && CardData.hasAbility);
        }

        public void SetHighlight(bool highlight)
        {
            // luego glow
        }
    }
}