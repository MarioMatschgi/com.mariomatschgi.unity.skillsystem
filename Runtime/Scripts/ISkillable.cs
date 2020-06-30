using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISkillable
{
    int skillableIndex { get; set; }
    SkillData skillData { get; set; }
}