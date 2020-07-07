using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
#if UNITY_EDITOR
using UnityEngine;
#endif

[Serializable]
[ExecuteAlways]
[CreateAssetMenu(fileName = "New SkillListData", menuName = "ScriptableObjects/MM SkillSystem/SkillListData")]
public class SkillListData : ScriptableObject
{
    public bool useThisList = true;
    public List<Skill> skills;

    void OnValidate()
    {
        if (useThisList)
        {
            SkillListData[] _instances = GetAllInstances();

            for (int i = 0; i < _instances.Length; i++)
                if (!_instances[i].Equals(this))
                    _instances[i].useThisList = false;
        }
        
        for (int i = 0; i < skills.Count; i++)
            skills[i].type.index = i;
    }

    public static List<Skill> GetSkills()
    {
        try
        {
#if UNITY_EDITOR
            return SkillListData.GetActiveInstance().skills.Select(item => (Skill)item.Clone()).ToList();
#endif
            return SkillCanvas.instance.skillListData.skills.Select(item => (Skill)item.Clone()).ToList();
        } catch (UnityException e) { }

        return null;
    }
    
#if UNITY_EDITOR
    public static SkillListData GetActiveInstance()
    {
        SkillListData[] _instances = GetAllInstances();
        
        for (int i = 0; i < _instances.Length; i++)
            if (_instances[i].useThisList)
                return _instances[i];

        return null;
    }
    
    public static SkillListData[] GetAllInstances()
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(SkillListData).Name);
        SkillListData[] _a = new SkillListData[guids.Length];
        for(int i = 0; i < guids.Length;i++)
            _a[i] = AssetDatabase.LoadAssetAtPath<SkillListData>(AssetDatabase.GUIDToAssetPath(guids[i]));
 
        return _a;
    }
#endif
}
