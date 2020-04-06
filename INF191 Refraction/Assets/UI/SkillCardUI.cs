using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardUI : MonoBehaviour
{
    [SerializeField] private BackgroundCover _backgroundCover;
    [SerializeField] private SubCanvas subCanvas;
    private SkillCard _displayedSkillCard;
    
    public void OnSkillCardClick(SkillCard skillCard)
    {
        subCanvas.SetChild(skillCard.transform);
        _backgroundCover.gameObject.SetActive(true);
        _displayedSkillCard = skillCard;
    }

    public void Return()
    {
        _displayedSkillCard.Return();
        subCanvas.RemoveChild();
        _backgroundCover.gameObject.SetActive(false);
        _displayedSkillCard = null;
    }
    

    public SubCanvas SubCanvas => subCanvas;
}
