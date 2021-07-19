using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonType
{
	//로비 씬
	Settings, //설정
	Library, //서재
	Arrangement, //배치
	Theme, //테마
	SelectChar, //대표 캐릭터 선택

	Close, //캐릭터 선택 창 닫기
	Char0, //캐릭터 0 선택
	Char1, //캐릭터 1 선택
	Char2, //캐릭터 2 선택
	Char3 //캐릭터 3 선택
}

public enum ArrangementButtonType
{
	//배치 씬
	Team1,
	Team2,
	Team3,
	Theme1,
	Theme2,
	Theme3,
	Theme4,
	Theme5,
	DefType,
	AtkType,
	SupType,
	All
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
	char3skill2,
}
