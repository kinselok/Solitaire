using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TableCardsController : MonoBehaviour
{
    //const float shift = 0.15f;
    //int childCount = 0;
    //public bool go = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    //I think here can use: gameObject.transform.GetChild(gameObject.transform.childCount).GetComponent<>............
    // But i'm not sure about the safety of this, we can have situation when we have some GameObject without CardInfo script as last child
    /*void ShowFaceOfLastCard()
    {
        CardInfo[] cards = gameObject.GetComponentsInChildren<CardInfo>();

        if (cards.Length != 0)
            cards[cards.Length - 1].Visible = true;
    }*/
    /// <summary>
    /// ShiftLast = true, if you want to shift only last card, if you want initial alignment, set - false
    /// </summary>
    /// <param name="ShiftLast"></param>
    /*public void ShiftCards(bool ShiftLast)
    {
        CardInfo[] cards = gameObject.GetComponentsInChildren<CardInfo>();
        if (cards.Length > 1)
            if (ShiftLast)
            {
                Debug.Log("1ok");
                cards[cards.Length - 1].gameObject.transform.position -= new Vector3(0, (0.15f * (cards.Length - 1)), 0);
                Debug.Log("2ok");
            }
            else
            {
                ShowFaceOfLastCard();
                for (int i = 1; i < cards.Length; i++)
                    cards[i].gameObject.transform.position -= new Vector3(0, (0.15f * i), 0);
            }
    }*/
    // Update is called once per frame
    void Update()
    {
        /*if (childCount < gameObject.transform.childCount)
        {
            ShowFaceOfLastCard();
            ShiftCards(childCount);
            childCount = gameObject.transform.childCount;
        }
        else childCount = gameObject.transform.childCount;*/
    }
}
