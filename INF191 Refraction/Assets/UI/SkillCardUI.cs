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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public SubCanvas SubCanvas => subCanvas;
}
