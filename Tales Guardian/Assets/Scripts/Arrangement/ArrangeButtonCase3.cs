using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrangeButtonCase3 : MonoBehaviour
{
    public ArrangementButtonType arrangeButtonType;
    public GameObject SkillExplanation1;
    public GameObject SkillExplanation2;
    public GameObject SkillExplanationPanelExit;
    // Start is called before the first frame update
    public void OnButtonClick()
    {
        switch (arrangeButtonType)
        {
            case ArrangementButtonType.SkillImageButton1:
                SkillExplanation1.SetActive(true);
                SkillExplanationPanelExit.SetActive(true);
                break;
            case ArrangementButtonType.SkillImageButton2:
                SkillExplanation2.SetActive(true);
                SkillExplanationPanelExit.SetActive(true);
                break;
            case ArrangementButtonType.SkillExplanationPanelExit:
                SkillExplanation1.SetActive(false);
                SkillExplanation2.SetActive(false);
                SkillExplanationPanelExit.SetActive(false);
                break;
        }
    }
}
