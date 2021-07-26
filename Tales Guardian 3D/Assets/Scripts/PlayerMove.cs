using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public BattleManager battleManager;

	SpriteRenderer characterColor;
	Color defaultColor;

	public bool clicked;

	void Start()
	{
		characterColor = GetComponent<SpriteRenderer>();
		defaultColor = characterColor.color;
		clicked = false;
	}

	private void OnMouseDown()
	{
		clicked = true;
		battleManager.canMove = true;
		battleManager.canAttack = false;
		characterColor.color = new Color(0.25f, 0.5f, 1f);
	}

	public void move(Vector3 fieldPosition)
	{
		if (clicked)
		{
			this.transform.position = new Vector3(fieldPosition.x, this.transform.position.y, fieldPosition.z);
			characterColor.color = defaultColor;
			clicked = false;
			battleManager.canMove = false;
		}
	}
}
