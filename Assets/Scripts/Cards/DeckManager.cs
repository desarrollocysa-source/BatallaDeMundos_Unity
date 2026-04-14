using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [Header("Mazos disponibles")]
    public List<DeckData> availableDecks;

    private DeckData selectedDeck;

    public void SelectDeck(DeckData deck)
    {
        selectedDeck = deck;

        PlayerPrefs.SetString("active_deck", deck.deckId);
        PlayerPrefs.Save();

        Debug.Log("Mazo seleccionado: " + deck.deckName);
    }

    public DeckData GetSelectedDeck()
    {
        return selectedDeck;
    }
}
