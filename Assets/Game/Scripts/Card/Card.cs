using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
	public bool hasBeenPlayed;
	public int handIndex;

	CardManager gm;

	public GameObject effect;
	public GameObject hollowCircle;

	private Vector3 currentPosition;
	private float x;
	private float y;
	private float z;

	private bool mouseOver;

	private void Start()
	{
		gm = FindObjectOfType<CardManager>();
	}

    private void Update()
    {
		x = gm.cardSlotsTransform[handIndex].position.x;

		if (hasBeenPlayed)
		{
			y = gm.cardSlotsTransform[handIndex].position.y + 0.6f;
			z = gm.cardSlotsTransform[handIndex].position.z + 1;
		}
		else if (mouseOver)
        {
			y = gm.cardSlotsTransform[handIndex].position.y + 0.6f;
			z = gm.cardSlotsTransform[handIndex].position.z + 0.5f;
		}
        else
        {
			y = gm.cardSlotsTransform[handIndex].position.y;
			z = gm.cardSlotsTransform[handIndex].position.z;
		}

		currentPosition = new Vector3(x, y, z);

		transform.position = currentPosition;
    }

    private void OnMouseDown()
	{
		if (!hasBeenPlayed)
		{
			Instantiate(hollowCircle, transform.position, Quaternion.identity);

			transform.position += Vector3.up * 3f;
			hasBeenPlayed = true;
			gm.availableCardSlots[handIndex] = true;
			Invoke("MoveToDiscardPile", 1f);	
		}
	}

    private void OnMouseEnter()
    {
		mouseOver = true;
    }
    private void OnMouseExit()
    {
		mouseOver = false;
	}

    void MoveToDiscardPile()
	{
		Instantiate(effect, transform.position, Quaternion.identity);
		gm.discardPile.Add(this);
		gameObject.SetActive(false);
	}



}
