using UnityEngine;

namespace BatalladeMundos
{
    public class CardTester : MonoBehaviour
    {
        public CardData testCard;     // carta aquí
        public GameObject cardPrefab; // prefab aquí

        void Start()
        {
            SpawnCard();
        }

        void SpawnCard()
        {
            GameObject cardGO = Instantiate(cardPrefab, transform);

            CardVisual visual = cardGO.GetComponent<CardVisual>();

            if (visual != null && testCard != null)
            {
                visual.Load(testCard);
            }
        }
    }
}