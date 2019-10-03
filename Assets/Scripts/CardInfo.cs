using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Suits
{
    diamonds,
    hearts,
    clubs,
    spades
}
public enum Ranks
{
    ace,
    six,
    seven,
    eight,
    nine,
    ten,
    jack,
    queen,
    king
}
public enum Locations
{
    table,
    deck,
    deckTable,
    stockpile,
    slotOfDeck
}
public class CardInfo : MonoBehaviour
{
    public Suits Suit = 0;
    public Ranks Rank = 0;
    private Locations location;
    public Locations Location
    {
        get { return location; }
        set
        {
            switch (value)
            {
                case Locations.deck:
                    {
                        location = value;
                        ShowBack();
                        DisableDraging();
                        break;
                    }
                case Locations.deckTable:
                    {
                        location = value;
                        ShowBack();
                        DisableDraging();
                        break;
                    }
                case Locations.table:
                    {
                        location = value;
                        ShowFace();
                        EnableDraging();
                        break;
                    }
                case Locations.stockpile:
                    {
                        location = value;
                        ShowFace();
                        EnableDraging();
                        break;
                    }
                case Locations.slotOfDeck:
                    {
                        location = value;
                        ShowFace();
                        EnableDraging();
                        break;
                    }
            }
        }
    }

    void ShowBack()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/card_back");
    }
    void ShowFace()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/" + Rank.ToString() + "_of_" + Suit.ToString());
    }
    void EnableDraging()
    {
        gameObject.GetComponent<GraphicRaycaster>().enabled = true;
    }
    void DisableDraging()
    {
        gameObject.GetComponent<GraphicRaycaster>().enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
