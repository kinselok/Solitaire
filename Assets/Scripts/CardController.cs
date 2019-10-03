using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    Vector3 InitialPosition;
    Transform InitialParent;
    Vector2 shift;

    public void OnBeginDrag(PointerEventData eventData)
    {
        InitialParent = gameObject.transform.parent;
        InitialPosition = gameObject.transform.position;

        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shift = MousePos - transform.position;

        gameObject.GetComponent<Canvas>().overrideSorting = true;    
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = MousePos-shift;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        gameObject.GetComponent<Canvas>().overrideSorting = false;

        //Without this, the z-position of the card changes after joining another card
        gameObject.transform.localPosition = Vector3.zero;

        if (InitialParent == gameObject.transform.parent)
            transform.position = InitialPosition;
    }
    //Perhaps it must be in CardInfo class, or somewhere else
    public static CardInfo CreateCard(Suits suit, Ranks rank, Locations location, Transform parent)
    {
        CardInfo o = Instantiate(Resources.Load<GameObject>("Prefabs/CardPref"), parent).GetComponent<CardInfo>();
        o.Suit = suit;
        o.Rank = rank;
        o.Location = location;
        o.gameObject.transform.localPosition = Vector3.zero;
        return o;
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
