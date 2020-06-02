using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;
using UnityScript.Scripting.Pipeline;
using System;
using Newtonsoft.Json;
using System.IO;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class SkillCatalouge : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<SkillCardEntry> skillCardList;
    private List<Transform> skillCardTransformList;
    private SkillCards _skillcards;

    private void Awake()
    {
        entryContainer = transform.Find("ButtonListContent");
        entryTemplate = entryContainer.Find("SkillCard");

        entryTemplate.gameObject.SetActive(false);

        /* initializing some skillcards for test*/
        skillCardList = new List<SkillCardEntry>(16);//*/

        var json = new StreamReader("./Users/skills.json");
        skillCardList = JsonConvert.DeserializeObject<List<SkillCardEntry>>(json.ReadToEnd());


        for (int i = 0; i < skillCardList.Count; i++)
        {
            for (int j = i + 1; j < skillCardList.Count; j++)
            {
                //if isFirst is -1 then it is First
                int isFirst = (string.Compare(skillCardList[j].skillName,
                    skillCardList[i].skillName, System.StringComparison.CurrentCulture));
                if (isFirst == -1)
                {
                    SkillCardEntry tmp = skillCardList[i];
                    skillCardList[i] = skillCardList[j];
                    skillCardList[j] = tmp;
                }
            }
        }

        skillCardTransformList = new List<Transform>();
        foreach (SkillCardEntry SkillCardEntry in skillCardList)
        {
            CreateListEntryTransform(SkillCardEntry, entryContainer, skillCardTransformList);
        }

        /*var path = "./Users/skills.json";
        var fileWriter = new StreamWriter(path);

        SkillCards skillcards = new SkillCards { skillCardList = skillCardList };
        var json = JsonConvert.SerializeObject(skillCardList);
        Debug.Log(json);
        fileWriter.WriteLine(json);
        fileWriter.Close();*/
  
    }

    private void CreateListEntryTransform(SkillCardEntry skillCardEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 72.806f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string skillName = skillCardEntry.skillName;
        string description = skillCardEntry.description;
        entryTransform.Find("Text").GetComponent<Text>().text = skillName;
        entryTransform.Find("Description").GetComponent<Text>().text = description;

        transformList.Add(entryTransform);
    }

    [System.Serializable]
    private class SkillCards
    {
        public List<SkillCardEntry> skillCardList;
    }

    [System.Serializable]
    private class SkillCardEntry
    {
        public string skillName;
        public string cardID;

        public string description;
        public int type; //1 - technology, 2 - interpersonal, 3 - specialty

        public string comment1;
        public string comment2;
        public string comment3;
  
    }
}
