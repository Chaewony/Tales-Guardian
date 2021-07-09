using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectGrid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public Transform gridScale;
	public Image gridColor;
	Vector3 defaultScale;
	Color defaultColor;
	private bool isClicked;
	private void Start()
	{
		defaultScale = gridScale.localScale;
		defaultColor = gridColor.color;
		isClicked = false;
	}
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (!isClicked)
		{
			gridScale.localScale = defaultScale * 1.05f;
			gridColor.color = new Color(gridColor.color.r, 0.25f, gridColor.color.b);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		gridScale.localScale = defaultScale;
		if (!isClicked)
		{
			gridColor.color = defaultColor;
		}
		else return;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (!isClicked)
		{
			isClicked = true;
			gridColor.color = new Color(gridColor.color.r, 0.25f, gridColor.color.b);
		}
		else
		{
			isClicked = false;
			gridColor.color = defaultColor;
		}
	}
}
