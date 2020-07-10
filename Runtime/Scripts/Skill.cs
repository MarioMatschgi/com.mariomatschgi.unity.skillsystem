using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class SkillData
{
    public List<Skill> skills;

    public SkillData()
    {
        if (SkillCanvas.instance == null)
            return;
            
        List<Skill> _skills = SkillCanvas.instance.skillListData.skills;
        
        for (int i = 0; i < _skills.Count; i++)
        {
            if (skills.Count - 1 <= i || skills[i] == null)
                skills[i] = _skills[i];
            else
            {
                skills[i].type = _skills[i].type;
                skills[i].maxLevel = _skills[i].maxLevel;
            }
        }
    }

    public Skill GetSkill(SkillType _skillType)
    {
        foreach (Skill _skill in skills)
            if (_skill.type == _skillType)
                return _skill;
        
        return null;
    }
}

[Serializable]
public class Skill : ICloneable
{
    public SkillType type;
    [Range(0, 99)]
    public int maxLevel;
    public int level;
    [Range(0, 1)]
    public float xp;

    public object Clone()
    {
        return new Skill
        {
            type = type,
            maxLevel = maxLevel,
            level = level,
            xp = xp
        };
    }
}