using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnCardButton : MonoBehaviour
{
    public TurnCard turnCard;
	public bool isClicked;

	Image image;

	// Start is called before the first frame update
	private void Start()
	{
		image = GetComponent<Image>();
		isClicked = false;
	}
	private void Update()
	{
		if (isClicked)
		{
			this.transform.Rotate(0.0f, 120.0f * Time.deltaTime, 0.0f);
			if (this.transform.localRotation.y > 0.7f)
				turnCard.ImageChange();
				//isClicked = false;
		}
	}

	public void OnButtonClick()
	{
		isClicked = true;
		turnCard.ShowTurnCards();
	}
}