using System;
using System.Collections;
using System.Collections.Generic;
using MM.Extentions;
using UnityEngine;

public class SkillManager
{
    public const string playerPrefsPath = "mm.systems.skillsystem.skilldata.";


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    #endregion

    #region Gameplay Methodes
    /*
     *
     *  Gameplay Methodes
     *
     */

    public static void SaveSkillData(SkillData _skillData, string _user)
    {
        Debug.Log("Saving Skills to PlayerPrefs");

        foreach (SkillType _skillType in Enum.GetValues(typeof(SkillType)))
            SaveSkill(_skillData.GetSkill(_skillType), _user, _skillType);
    }

    public static SkillData LoadSkillData(string _user)
    {
        Debug.Log("Loading Skills from PlayerPrefs");
        
        SkillData _skillData = new SkillData();
        foreach (SkillType _skillType in Enum.GetValues(typeof(SkillType)))
            _skillData.SetSkill(_skillType, LoadSkill(_user, _skillType));

        return _skillData;
    }

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    static void SaveSkill(Skill _skill, string _user, SkillType _skillType)
    {
        if (_skill == null)
            _skill = new Skill();
        
        PlayerPrefs.SetInt(playerPrefsPath + _user + "." + _skillType.GetStringValue() + ".level", _skill.level);
        PlayerPrefs.SetFloat(playerPrefsPath + _user + "." + _skillType.GetStringValue() + ".xp", _skill.xp);
    }

    static Skill LoadSkill(string _user, SkillType _skillType)
    {
        Skill _skill = new Skill();
        
        _skill.level = PlayerPrefs.GetInt(playerPrefsPath + _user + "." + _skillType.GetStringValue() + ".level");
        _skill.xp = PlayerPrefs.GetFloat(playerPrefsPath + _user + "." + _skillType.GetStringValue() + ".xp");

        return _skill;
    }

    #endregion
}
