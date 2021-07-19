using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyField : MonoBehaviour
{
	//Transform fieldScale;
	SpriteRenderer fieldColor;
	public EnemyField rightField;
	public EnemyField leftField;
	public EnemyField upField;
	public EnemyField downField;
	//Vector3 defaultScale;
	Color defaultColor;

	public BattleManager battleManager;

	// Start is called before the first frame update
	void Start()
    {
		//fieldScale = GetComponent<Transform>();
		fieldColor = GetComponent<SpriteRenderer>();

		//defaultScale = fieldScale.localScale;
		defaultColor = fieldColor.color;
	}

	private void OnMouseEnter()
	{
		//fieldScale.localScale = defaultScale * 1.05f;
		/*if(fieldColor.color== new Color(1, 1, 1)) 
			fieldColor.color = new Color(fieldColor.color.r, 0.5f, 0.5f);
		else if (fieldColor.color == new Color(0, 0, 0))
			fieldColor.color = new Color(0.5f, fieldColor.color.g, fieldColor.color.b);*/
		if (battleManager.canAttack)
		{
			fieldColor.color = new Color(1, 0.5f, 0.5f);

			if (rightField != null)
				rightField.SecondTargetEnter();
			if (leftField != null)
				leftField.SecondTargetEnter();
			if (upField != null)
				upField.SecondTargetEnter();
			if (downField != null)
				downField.SecondTargetEnter();
			else return;
		}
	}
	private void OnMouseExit()
	{
		//fieldScale.localScale = defaultScale;
		fieldColor.color = defaultColor;

		if (rightField != null)
			rightField.SecondTargetExit();
		if (leftField != null)
			leftField.SecondTargetExit();
		if (upField != null)
			upField.SecondTargetExit();
		if (downField != null)
			downField.SecondTargetExit();
		else return;
	}
	private void SecondTargetEnter()
	{
		/*if (fieldColor.color == new Color(1, 1, 1))
			fieldColor.color = new Color(fieldColor.color.r, 0.75f, 0.5f);
		else if (fieldColor.color == new Color(0, 0, 0))
			fieldColor.color = new Color(0.75f, 0.5f, 0.25f);*/
		fieldColor.color = new Color(1, 0.75f, 0.5f);
	}
	private void SecondTargetExit()
	{
		//fieldScale.localScale = defaultScale;
		fieldColor.color = defaultColor;
	}
}
