using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaceController : MonoBehaviour, IDropHandler
{
    public Locations FieldType;

    public void OnDrop(PointerEventData eventData)
    {
        bool allowed = false;
        CardInfo NewCard = eventData.pointerDrag.gameObject.GetComponent<CardInfo>();
        Transform parent = null;// Parent of new card

        //If here are cards - attach a new card to the last card in this slot
        if (GetLastCard() != null)
        {
            CardInfo LastCard = GetLastCard().GetComponent<CardInfo>();
            allowed = JoinToCard(NewCard, LastCard, out parent);
        }
        else
        {
            allowed = JoinToEmptyField(NewCard, out parent);
            Debug.Log(allowed);
        }

        if (allowed)
            NewCard.gameObject.transform.SetParent(parent);

    }

    //Check that the new card is opposite color and has a lower rank
    bool JoinToCard(CardInfo NewCard, CardInfo LastCard, out Transform ParentOfNewCard)
    {
        if (FieldType == Locations.table)
        {
            if ((LastCard.Rank - 1) == NewCard.Rank)
            {
                Suits suitLast = LastCard.Suit;
                switch (suitLast)
                {
                    case Suits.clubs:
                        {
                            if (NewCard.Suit == Suits.diamonds || NewCard.Suit == Suits.hearts)
                            {
                                ParentOfNewCard = LastCard.gameObject.transform;
                                return true;
                            }
                            break;
                        }
                    case Suits.diamonds:
                        {
                            if (NewCard.Suit == Suits.clubs || NewCard.Suit == Suits.spades)
                            {
                                ParentOfNewCard = LastCard.gameObject.transform;
                                return true;
                            }
                            break;
                        }
                    case Suits.hearts:
                        {
                            if (NewCard.Suit == Suits.clubs || NewCard.Suit == Suits.spades)
                            {
                                ParentOfNewCard = LastCard.gameObject.transform;
                                return true;
                            }
                            break;
                        }
                    case Suits.spades:
                        {
                            if (NewCard.Suit == Suits.diamonds || NewCard.Suit == Suits.hearts)
                            {
                                ParentOfNewCard = LastCard.gameObject.transform;
                                return true;
                            }
                            break;
                        }
                }
            }
        }
        if (FieldType == Locations.stockpile)
        {
            if (LastCard.Suit == NewCard.Suit && (LastCard.Rank + 1) == NewCard.Rank)
            {
                ParentOfNewCard = gameObject.transform;
                return true;
            }
        }
        ParentOfNewCard = NewCard.gameObject.transform.parent;
        return false;
    }
    bool JoinToEmptyField(CardInfo NewCard, out Transform ParentOfNewCard)
    {
        if (FieldType == Locations.table && NewCard.Rank == Ranks.king)
        {
            ParentOfNewCard = gameObject.transform;
            return true;
        }

        if (FieldType == Locations.stockpile && NewCard.Rank == Ranks.ace)
        {
            ParentOfNewCard = gameObject.transform;
            return true;
        }
        ParentOfNewCard = NewCard.gameObject.transform.parent;
        return false;

    }
    public GameObject GetLastCard()
    {
        CardInfo[] cards = gameObject.GetComponentsInChildren<CardInfo>();
        if (cards.Length != 0)
            return cards[cards.Length - 1].gameObject;
        else
            return null;
    }

    /// <summary>
    ///Enabling last card in column for draging and show face of card
    /// </summary>
    void EnableLastCard()
    {
        CardInfo[] cards = gameObject.GetComponentsInChildren<CardInfo>();
        if (cards.Length != 0)
            cards[cards.Length - 1].Location = Locations.table;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        EnableLastCard();
    }
}
