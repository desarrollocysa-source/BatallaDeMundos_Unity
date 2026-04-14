using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BatalladeMundos
{
    public class CardListItem : MonoBehaviour
    {
        public TextMeshProUGUI txtName;
        public Button btnSelect;

        private CardData card;
        private CardEditorManager editor;

        public void Setup(CardData data, CardEditorManager manager)
        {
            card = data;
            editor = manager;

            txtName.text = data.cardName;

            btnSelect.onClick.AddListener(OnClick);
        }

        void OnClick()
        {
            editor.LoadCard(card);
        }
    }
}