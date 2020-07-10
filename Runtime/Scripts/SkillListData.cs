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
}
