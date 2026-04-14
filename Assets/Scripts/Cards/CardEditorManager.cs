using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace BatalladeMundos
{
    public class CardEditorManager : MonoBehaviour
    {
        [Header("PREVIEW")]
        public CardVisual previewCard;

        [Header("PANELES POR TIPO")]
        public GameObject PanelCommon; // Panel común para todos los tipos
        public GameObject panelSer;
        public GameObject panelApoyo;
        public GameObject panelArma;
        public GameObject section_Apoyo;
        public GameObject section_Arma;

        [Header("INPUTS")]
        public TMP_InputField inputName;
        public TMP_InputField inputId;
        public TMP_InputField inputAttack;
        public TMP_InputField inputDefense;
        public TMP_InputField inputDescription;
        public TMP_InputField inputDurationTurns;

        public TMP_Dropdown dropdownType;
        public TMP_Dropdown dropdownWorld;
        public TMP_Dropdown dropdownBattleType;
        public TMP_Dropdown dropdownSupportSubtype;
        public TMP_Dropdown dropdownActivationMode;
        public TMP_Dropdown dropdownWeaponType;

        public Toggle toggleAbility;
        public Toggle toggleIsPermanent;

        private CardData tempCard;

        void Start()
        {
            tempCard = ScriptableObject.CreateInstance<CardData>();
            UpdatePreview();
        }

        public void UpdatePreview()
        {
            if (tempCard == null) return;

            Debug.Log("Updating Preview...");

            tempCard.cardName = inputName.text;
            tempCard.cardId = inputId.text;

            tempCard.type = (CardType)dropdownType.value;
            tempCard.world = (WorldType)dropdownWorld.value;
            tempCard.battleType = (BattleType)dropdownBattleType.value;

            int.TryParse(inputAttack.text, out tempCard.attack);
            int.TryParse(inputDefense.text, out tempCard.defense);

            tempCard.hasAbility = toggleAbility.isOn;
            tempCard.effectDescription = inputDescription.text;

            tempCard.supportSubtype = (SupportSubtype)dropdownSupportSubtype.value;
            tempCard.activationMode = (ActivationMode)dropdownActivationMode.value;
            tempCard.weaponType = (WeaponType)dropdownWeaponType.value;

            tempCard.isPermanent = toggleIsPermanent.isOn;

            int.TryParse(inputDurationTurns.text, out tempCard.durationTurns);
            
            UpdateTypeUI();

            previewCard.Load(tempCard);

            if (tempCard.hasAbility && !string.IsNullOrEmpty(tempCard.effectDescription))
              previewCard.Expand();

        }
        void UpdateTypeUI()
        {
            CardType type = (CardType)dropdownType.value;

            // Apagar todos primero
            PanelCommon.SetActive(true); // El panel común siempre está activo
            panelSer.SetActive(false);
            panelApoyo.SetActive(false);
            panelArma.SetActive(false);
            section_Apoyo.SetActive(false);
            section_Arma.SetActive(false);

            // Encender solo el correspondiente
            switch (type)
            {
                case CardType.Ser:
                    panelSer.SetActive(true);
                    break;

                case CardType.Apoyo:
                    panelApoyo.SetActive(true);
                    section_Apoyo.SetActive(true);
                    break;

                case CardType.Arma:
                    panelArma.SetActive(true);
                    section_Arma.SetActive(true);
                    break;
            }
        }
        public void LoadCard(CardData card)
        {
            tempCard = card;

            inputName.text = card.cardName;
            inputId.text = card.cardId;
            inputDescription.text = card.effectDescription;

            inputAttack.text = card.attack.ToString();
            inputDefense.text = card.defense.ToString();

            dropdownType.value = (int)card.type;
            dropdownWorld.value = (int)card.world;
            dropdownBattleType.value = (int)card.battleType;

            dropdownSupportSubtype.value = (int)card.supportSubtype;
            dropdownActivationMode.value = (int)card.activationMode;
            dropdownWeaponType.value = (int)card.weaponType;

            toggleAbility.isOn = card.hasAbility;
            toggleIsPermanent.isOn = card.isPermanent;

            inputDurationTurns.text = card.durationTurns.ToString();

            UpdatePreview();
        }

        public CardData GetCurrentCard()
        {
            return tempCard;
        }
        public void SetArtwork(Sprite sprite)
        {
            tempCard.artwork = sprite;
            UpdatePreview();
        }
        public void OnTypeChanged()
        {
            UpdateTypeUI();
            UpdatePreview();
        }
        public void SetFrame(Sprite sprite)
        {
            tempCard.frameOverride = sprite;
            UpdatePreview();
        }

        public void SetWorldIcon(Sprite sprite)
        {
            tempCard.worldIconOverride = sprite;
            UpdatePreview();
        }

        public void SetBattleIcon(Sprite sprite)
        {
            tempCard.battleIconOverride = sprite;
            UpdatePreview();
        }
        /*void LateUpdate()
        {
            if (previewCard != null && tempCard != null)
            {
                previewCard.Load(tempCard);
                Canvas.ForceUpdateCanvases(); 
            }
        }*/
    }
}