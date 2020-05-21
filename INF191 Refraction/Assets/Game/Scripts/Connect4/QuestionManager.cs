using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestionManager
{
    private Questions _questions;
    private int _p1tier1Index = 0;
    private int _p1tier2Index = 0;
    private int _p1tier3Index = 0;
    private int _p2tier1Index = 0;
    private int _p2tier2Index = 0;
    private int _p2tier3Index = 0;
    private bool[] _p1AvailableTiers = new bool[3] {true, true, true};
    private bool[] _p2AvailableTiers = new bool[3] {true, true, true};
    public QuestionManager()
    {
        LoadQuestionData();
    }

    private void LoadQuestionData()
    {
        var json = new StreamReader("QuestionData/Connect4Questions.json");
        _questions = JsonConvert.DeserializeObject<Questions>(json.ReadToEnd());
    }

    public Questions GetQuestionsClass()
    {
        return _questions;
    }

    public string GetOneQuestion(int tier, bool isPlayer1)
    {
        string question;
        var availability = isPlayer1 ? _p1AvailableTiers : _p2AvailableTiers;
        var availableTierIndex = CheckAvailableTier(availability, tier);
        var playerType = isPlayer1 ? "Candidate" : "Company";
        var tierSet = isPlayer1? _questions.employee:_questions.employer;

        switch (availableTierIndex)
        {
            case -1:
                Debug.Log("Run out of questions");
                return null;
            case 0:
                question = GetQuestionFromTier1(tierSet, ref isPlayer1? ref _p1tier1Index: ref _p2tier1Index);
                UpdateAvailableTier(availability, availableTierIndex, tierSet.tier1);
                return "" + playerType + " Asks! (Tier 1): \n\n" + question;
            case 1:
                question = GetQuestionFromTier2(tierSet, ref isPlayer1? ref _p1tier2Index: ref _p2tier2Index);
                UpdateAvailableTier(availability, availableTierIndex, tierSet.tier2);
                return "" + playerType + " Asks! (Tier 2): \n\n" + question;
            case 2:
                question = GetQuestionFromTier3(tierSet, ref isPlayer1? ref _p1tier3Index: ref _p2tier3Index);
                UpdateAvailableTier(availability, availableTierIndex, tierSet.tier3);
                return "" + playerType + " Asks! (Tier 3): \n\n" + question;
            default:
                return null;
        }
    }

    private string GetQuestionFromTier1(TierSet tierSet, ref int tierIndex)
    {
        
        var questionIndex = Random.Range( tierIndex, tierSet.tier1.Length);
        var question = string.Copy(tierSet.tier1[questionIndex]);
        tierSet.tier1[questionIndex] = string.Copy(tierSet.tier1[tierIndex]);
        tierIndex++;
        return question;
    }
    private string GetQuestionFromTier2(TierSet tierSet, ref int tierIndex)
    {
        
        var questionIndex = Random.Range( tierIndex, tierSet.tier2.Length);
        var question = string.Copy(tierSet.tier2[questionIndex]);
        tierSet.tier2[questionIndex] = string.Copy(tierSet.tier2[tierIndex]);
        tierIndex++;
        return question;
    }
    private string GetQuestionFromTier3(TierSet tierSet, ref int tierIndex)
    {
        
        var questionIndex = Random.Range( tierIndex, tierSet.tier3.Length);
        var question = string.Copy(tierSet.tier3[questionIndex]);
        tierSet.tier3[questionIndex] = string.Copy(tierSet.tier3[tierIndex]);
        tierIndex++;
        return question;
    }

    private int CheckAvailableTier(bool[] availability, int tier)
    {
        //find next available tier if current one is unavailable
        if (availability[tier]) return tier;
        if (availability[(tier + 1) % 3]) return (tier + 1) % 3;
        if (availability[(tier + 2) % 3]) return (tier + 2) % 3;
        return -1;
        
    }
    
    private void UpdateAvailableTier(bool[] availability, int _tierIndex, string[] questionSet)
    {
        if (_tierIndex == questionSet.Length)
        {
            Debug.Log("Run out of tier " + (_tierIndex+1).ToString() + " questions");
            availability[_tierIndex] = false;
        }
    }


    public void Reset()
    {
        _p1tier1Index = _p1tier2Index = _p1tier3Index = 
            _p2tier1Index = _p2tier2Index = _p2tier3Index = 0;
       LoadQuestionData();
    }
}
