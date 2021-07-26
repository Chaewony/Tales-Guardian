using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyField : MonoBehaviour
{
	//Transform fieldScale;
	SpriteRenderer fieldColor;

	public EnemyField leftUpField;     // 1
	public EnemyField upField;         // 2
	public EnemyField rightUpField;    // 3
	public EnemyField leftField;       // 4
	public EnemyField rightField;      // 5
	public EnemyField leftDownField;   // 6
	public EnemyField downField;       // 7
	public EnemyField rightDownField;  // 8
	//Vector3 defaultScale;
	Color defaultColor;

	public BattleManager battleManager;

	//private int[] mySecondTarget;

	List<int> mySecondTarget = new List<int>();

	// Start is called before the first frame update
	void Start()
    {
		//fieldScale = GetComponent<Transform>();
		fieldColor = GetComponent<SpriteRenderer>();

		//defaultScale = fieldScale.localScale;
		defaultColor = fieldColor.color;
	}

	public void SetSecondTarget(int[] secondTarget)
	{
		mySecondTarget = new List<int>();
		//int[] mySecondTarget = new int[secondTarget.Length];
		for(int i = 0; i < secondTarget.Length; i++)
		{
			//mySecondTarget[i] = secondTarget[i];
			mySecondTarget.Add(secondTarget[i]);
			//mySecondTarget[i] = secondTarget[i];
		}
	}

	private void OnMouseEnter()
	{
		//fieldScale.localScale = defaultScale * 1.05f;
		/*if(fieldColor.color== new Color(1, 1, 1)) 
			fieldColor.color = new Color(fieldColor.color.r, 0.5f, 0.5f);
		else if (fieldColor.color == new Color(0, 0, 0))
			fieldColor.color = new Color(0.5f, fieldColor.color.g, fieldColor.color.b);*/

		/*if (battleManager.canAttack)
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
		}*/

		if (battleManager.canAttack && mySecondTarget != null)
		{
			fieldColor.color = new Color(1, 0.5f, 0.5f);

			for (int i = 0; i < mySecondTarget.Count; i++)
			{
				switch (mySecondTarget[i])
				{
					case 1:
						if (leftUpField != null)
							leftUpField.SecondTargetEnter();
						break;

					case 2:
						if (upField != null)
							upField.SecondTargetEnter();
						break;

					case 3:
						if (rightUpField != null)
							rightUpField.SecondTargetEnter();
						break;

					case 4:
						if (leftField != null)
							leftField.SecondTargetEnter();
						break;

					case 5:
						if (rightField != null)
							rightField.SecondTargetEnter();
						break;

					case 6:
						if (leftDownField != null)
							leftDownField.SecondTargetEnter();
						break;

					case 7:
						if (downField != null)
							downField.SecondTargetEnter();
						break;

					case 8:
						if (rightDownField != null)
							rightDownField.SecondTargetEnter();
						break;
				}
			}
		}
	}
	private void OnMouseExit()
	{
		//fieldScale.localScale = defaultScale;
		fieldColor.color = defaultColor;

		/*if (rightField != null)
			rightField.SecondTargetExit();
		if (leftField != null)
			leftField.SecondTargetExit();
		if (upField != null)
			upField.SecondTargetExit();
		if (downField != null)
			downField.SecondTargetExit();
		else return;*/
		if (battleManager.canAttack && mySecondTarget != null)
		{
			for (int i = 0; i < mySecondTarget.Count; i++)
			{
				switch (mySecondTarget[i])
				{
					case 1:
						if (leftUpField != null)
							leftUpField.SecondTargetExit();
						break;

					case 2:
						if (upField != null)
							upField.SecondTargetExit();
						break;

					case 3:
						if (rightUpField != null)
							rightUpField.SecondTargetExit();
						break;

					case 4:
						if (leftField != null)
							leftField.SecondTargetExit();
						break;

					case 5:
						if (rightField != null)
							rightField.SecondTargetExit();
						break;

					case 6:
						if (leftDownField != null)
							leftDownField.SecondTargetExit();
						break;

					case 7:
						if (downField != null)
							downField.SecondTargetExit();
						break;

					case 8:
						if (rightDownField != null)
							rightDownField.SecondTargetExit();
						break;
				}
			}
		}
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
