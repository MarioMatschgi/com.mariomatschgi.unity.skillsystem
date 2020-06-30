using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamplePlayer : MonoBehaviour, ISkillable
{
    [SerializeField]
    int m_skillableIndex;
    public int skillableIndex
    {
        get { return m_skillableIndex; }
        set { m_skillableIndex = value; }
    }
    
    [SerializeField]
    SkillData m_skillData;
    public SkillData skillData
    {
        get { return m_skillData; }
        set { m_skillData = value; }
    }


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    void Start()
    {
        if (skillData == null)
            skillData = new SkillData();
        
        skillData.building.level = 5;
    }

    void OnEnable()
    {
        skillData = SkillManager.LoadSkillData("Player" + skillableIndex.ToString());
    }

    void OnDisable()
    {
        SkillManager.SaveSkillData(skillData, "Player" + skillableIndex.ToString());
    }

    void Update()
    {
        
    }

    #endregion

    #region Gameplay Methodes
    /*
     *
     *  Gameplay Methodes
     *
     */

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}
