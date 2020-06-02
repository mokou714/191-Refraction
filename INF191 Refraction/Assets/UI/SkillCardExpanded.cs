using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class SkillCardExpanded : MonoBehaviour
{
    
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillNameBack;
    public TextMeshProUGUI description;

    private SkillCatalouge _skillList;

    void Start()
    {

    }
    // Start is called before the first frame update
    public void setText()
    {
        skillName = GetComponent<TextMeshProUGUI>();
        skillNameBack = GetComponent<TextMeshProUGUI>();
        description = GetComponent<TextMeshProUGUI>();

        // skillName.text = skillNameOrigin.text;
        // skillNameBack.text = skillNameOrigin.text;
        // description.text = descriptionOrigin.text;
    }

    private void searchCard()
    {

    }
}
