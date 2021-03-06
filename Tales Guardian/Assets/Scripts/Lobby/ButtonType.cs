using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum ButtonType
{
	//로비 씬
	Settings, //설정
	Library, //서재
	Arrangement, //배치
	Theme, //테마
	SelectChar, //대표 캐릭터 선택

	Close, //캐릭터 선택 창 닫기
	Char
}

public enum SkillButtonType
{
	char0skill1,
	char0skill2,

	char1skill1,
	char1skill2,
	
	char2skill1,
	char2skill2,
	
	char3skill1,
	char3skill2
}

public enum TurnCardIndex
{
	TurnCardIndex0,
	TurnCardIndex1,
	TurnCardIndex2,
	TurnCardIndex3
}
