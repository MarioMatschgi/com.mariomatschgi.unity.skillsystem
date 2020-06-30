using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillData
{
    [Header("Crafting Skill")] 
    public const int craftingMaxLevel = 10;
    public Skill crafting;
    
    [Header("Building Skill")]
    public const int buildingMaxLevel = 10;
    public Skill building;
    
    [Header("Foraging Skill")]
    public const int foragingMaxLevel = 10;
    public Skill foraging;
    
    [Header("Farming Skill")]
    public const int farmingMaxLevel = 10;
    public Skill farming;
    
    [Header("Hunting Skill")]
    public const int huntingMaxLevel = 10;
    public Skill hunting;
    
    [Header("Experience Skill")]
    public const int experienceMaxLevel = 10;
    public Skill experience;

    public SkillData()
    {
        crafting = new Skill();
        building = new Skill();
        foraging = new Skill();
        farming = new Skill();
        hunting = new Skill();
        experience = new Skill();
    }

    public Skill GetSkill(SkillType _skillType)
    {
        switch (_skillType)
        {
            case SkillType.Crafting:
                return crafting;
            
            case SkillType.Building:
                return building;
            
            case SkillType.Foraging:
                return foraging;
            
            case SkillType.Farming:
                return farming;
            
            case SkillType.Hunting:
                return hunting;
            
            case SkillType.Experience:
                return experience;
            
            default:
                return null;
        }
    }
    
    public int GetMaxSkillLevel(SkillType _skillType)
    {
        switch (_skillType)
        {
            case SkillType.Crafting:
                return craftingMaxLevel;
            
            case SkillType.Building:
                return buildingMaxLevel;
            
            case SkillType.Foraging:
                return foragingMaxLevel;
            
            case SkillType.Farming:
                return farmingMaxLevel;
            
            case SkillType.Hunting:
                return huntingMaxLevel;
            
            case SkillType.Experience:
                return experienceMaxLevel;
            
            default:
                return -1;
        }
    }
}

[Serializable]
public class Skill
{
    public int level;
    [Range(0, 1)]
    public float xp;
}