using System;
using System.Collections;
using System.Collections.Generic;
using MM.Extentions;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[Serializable]
public struct SkillType
{
    public string displayName;

    public int index;

    public SkillType(int _idx)
    {
        SkillType _type = SkillCanvas.instance.skillListData.skills[_idx].type;
        displayName = _type.displayName;
        index = _type.index;
    }

    public static implicit operator int(SkillType _type)
    {
        return _type.index;
    }
    public static implicit operator SkillType(int _idx)
    {
        return new SkillType(_idx);
    }
}