using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardManager : MonoBehaviour
{
	public List<Card> deck;
	public TextMeshProUGUI deckSizeText;
	public GameObject cardSlots;
	public Transform[] cardSlotsTransform;
	public bool[] availableCardSlots;
	public List<Card> discardPile;
	public TextMeshProUGUI discardPileSizeText;

	public void DrawCard()
	{
		if (deck.Count >= 1)
		{
			Card randomCard = deck[Random.Range(0, deck.Count)];

			for (int i = 0; i < availableCardSlots.Length; i++)
			{
				if (availableCardSlots[i] == true)
				{
					randomCard.gameObject.SetActive(true);
					randomCard.transform.position = cardSlotsTransform[i].position;
					randomCard.handIndex = i;
					randomCard.hasBeenPlayed = false;
					deck.Remove(randomCard);
					availableCardSlots[i] = false;
					return;
				}
			}
		}
	}

	public void Shuffle()
	{
		if (discardPile.Count >= 1)
		{
			foreach (Card card in discardPile)
			{
				deck.Add(card);
			}
			discardPile.Clear();
		}
	}

	private void Update()
	{
		deckSizeText.text = deck.Count.ToString();
		discardPileSizeText.text = discardPile.Count.ToString();

		for (int i = 0; i < availableCardSlots.Length; i++)
		{
			cardSlotsTransform[i] = GameObject.Find("CardSlots").transform.GetChild(i);
		}
	}
}

