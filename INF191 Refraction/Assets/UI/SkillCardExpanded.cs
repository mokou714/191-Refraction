using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using JetBrains.Annotations;

public class SkillCardExpanded : MonoBehaviour
{
    public Text skillNameOrig;
    public Text descOrig;
    
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillNameBack;
    public TextMeshProUGUI desc;

    //private SkillCatalouge _skillList;

    void Start()
    {

    }
    // Start is called before the first frame update
    public void setText()
    {
        skillName.text = skillNameOrig.text;
        skillNameBack.text = skillNameOrig.text;
        desc.text = descOrig.text;
    }

}
