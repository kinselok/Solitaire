using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeckController : MonoBehaviour, IPointerClickHandler
{
    public GameObject[] TableSlots = new GameObject[7];
    public Transform DeckSlot;
    const int size = 36;
    const int nSuits = 4;
    const int nRanks = size / nSuits;
    public List<CardInfo> deck = new List<CardInfo>(); // I think here can use Queue or Stack
    public GameObject WinWindow;
    // Start is called before the first frame update
    void Start()
    {
        InitGame();
        Shuffle();
        DealCards();
    }
    void InitGame()
    {
        for (int i = 0; i < nSuits; i++)
            for (int k = 0; k < nRanks; k++)
            {
                deck.Add(CardController.CreateCard((Suits)i, (Ranks)k, Locations.deck, gameObject.transform));
            }
    }
    public void Shuffle()
    {
        for (int t = 0; t < deck.Count; t++)
        {
            var tmp = deck[t];
            int r = Random.Range(t, deck.Count);
            deck[t] = deck[r];
            deck[r] = tmp;
        }
    }
    public void DealCards()
    {
        int numberOfSlot = 0;
        for (int i = 0; numberOfSlot < TableSlots.Length; i++)
        {
            for (int k = 0; k <= numberOfSlot; k++)
            {
                deck[0].Location = Locations.deckTable;
                deck[0].gameObject.transform.SetParent(TableSlots[numberOfSlot].transform);
                deck[0].gameObject.transform.localPosition = Vector3.zero;
                deck.RemoveAt(0);
            }
            i += numberOfSlot;
            numberOfSlot++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isGameEnded()) EndGame();
    }
    bool isGameEnded()
    {
        int nOfCardsInDeck = deck.Count + DeckSlot.GetComponentsInChildren<CardInfo>().Length;
        if (nOfCardsInDeck == 0)
        {
            for (int i = 0; i < TableSlots.Length; i++)
            {
                if (TableSlots[i].GetComponent<PlaceController>().GetLastCard() != null) return false;
            }
            return true;
        }
        else return false;
    }
    void EndGame()
    {
        WinWindow.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (deck.Count != 0)
        {
            deck[0].Location = Locations.slotOfDeck;
            deck[0].gameObject.transform.SetParent(DeckSlot);
            deck[0].gameObject.transform.localPosition = Vector3.zero;
            deck.RemoveAt(0);
        }
        else
            ReturnCardToDeck();
    }
    void ReturnCardToDeck()
    {
        CardInfo[] buffer = DeckSlot.GetComponentsInChildren<CardInfo>();
        if (buffer.Length != 0)
        {
            foreach (var card in buffer)
            {
                card.Location = Locations.deck;
                card.gameObject.transform.SetParent(gameObject.transform);
                card.gameObject.transform.localPosition = Vector3.zero;
                deck.Add(card);
            }
        }
    }
}
