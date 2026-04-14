#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace BatalladeMundos
{
    public class CardSaver : MonoBehaviour
    {
        public CardEditorManager editor;

        public void SaveCard()
        {
#if UNITY_EDITOR
            if (editor == null) return;

            CardData card = editor.GetCurrentCard();

            // Copiar datos
            card.cardId = editor.inputId.text;
            card.cardName = editor.inputName.text;
            card.attack = int.Parse(editor.inputAttack.text);
            card.defense = int.Parse(editor.inputDefense.text);
            card.effectDescription = editor.inputDescription.text;

            card.type = (CardType)editor.dropdownType.value;
            card.world = (WorldType)editor.dropdownWorld.value;
            card.battleType = (BattleType)editor.dropdownBattleType.value;

            card.hasAbility = editor.toggleAbility.isOn;
            card.supportSubtype = (SupportSubtype)editor.dropdownSupportSubtype.value;
            card.activationMode = (ActivationMode)editor.dropdownActivationMode.value;

            card.isPermanent = editor.toggleIsPermanent.isOn;

            int.TryParse(editor.inputDurationTurns.text, out card.durationTurns);

            // Guardar asset
            string path = "Assets/Cards/" + card.cardId + ".asset";

            AssetDatabase.CreateAsset(card, path);
            AssetDatabase.SaveAssets();

            Debug.Log("Carta guardada en: " + path);
#endif
        }
    }
}