﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
	public BattleManager battleManager;
	public SkillButtonType skillButtonType;
    public EnemyField[] enemyField;
	public void OnButtonClick()
	{
        if (battleManager.battleState == BattleState.PLAYER_ATTACK_TURN)
        {
            switch (skillButtonType)
            {
                //캐릭터 0의 스킬
                case SkillButtonType.char0skill1:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[0].myFirstSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
                case SkillButtonType.char0skill2:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[0].mySecondSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
                //캐릭터 1의 스킬
                case SkillButtonType.char1skill1:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[1].myFirstSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
                case SkillButtonType.char1skill2:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[1].mySecondSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
                //캐릭터 2의 스킬
                case SkillButtonType.char2skill1:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[2].myFirstSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
                case SkillButtonType.char2skill2:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[2].mySecondSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
                //캐릭터 3의 스킬
                case SkillButtonType.char3skill1:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[3].myFirstSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
                case SkillButtonType.char3skill2:
                    for (int i = 0; i < enemyField.Length; i++)
                        enemyField[i].SetSecondTarget(battleManager.playerSquad[3].mySecondSkillSecondTargetRange);
                    battleManager.canAttack = true;
                    battleManager.canMove = false;
                    break;
            }
        }
	}
}
