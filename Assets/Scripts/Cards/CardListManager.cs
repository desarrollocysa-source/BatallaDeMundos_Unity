using System.Collections.Generic;
using UnityEngine;

namespace BatalladeMundos
{
    public class CardListManager : MonoBehaviour
    {
        public CardRegistry registry;
        public GameObject itemPrefab;
        public Transform content;
        public CardEditorManager editor;

        void Start()
        {
            LoadList();
        }

        void LoadList()
        {
            foreach (var card in registry.allStrategyCards)
            {
                GameObject go = Instantiate(itemPrefab, content);

                CardListItem item = go.GetComponent<CardListItem>();
                item.Setup(card, editor);
            }
        }
    }
}