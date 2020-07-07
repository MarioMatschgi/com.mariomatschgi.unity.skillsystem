using System.Collections;
using System.Collections.Generic;
using MM.Extentions;
using UnityEngine;
using MM.Libraries.UI;
using TMPro;
using UnityEngine.UI;

[ExecuteAlways]
public class SkillCell : MonoBehaviour, IPrefabListChild
{
    [Header("General")]
    public SkillType skillType;
    public int skillableIndex;

    [Header("Formatting")]
    public string nameTextFormat = "{name}";
    public string levelTextFormat = "Level: {cur}/{max}";
    
    [Header("Outlets")]
    public TMP_Text nameText;
    public TMP_Text levelText;
    public SimpleSlider slider;


    #region Callback Methodes
    /*
     *
     *  Callback Methodes
     * 
     */

    public void Setup()
    {
        UpdateCell();
    }

    public void SetupVariables(SkillType _skillType, int _skillableIndex)
    {
        skillType = _skillType;
        skillableIndex = _skillableIndex;
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        UpdateCell();
    }

    #endregion

    #region Gameplay Methodes
    /*
     *
     *  Gameplay Methodes
     *
     */

    public void UpdateCell()
    {
        nameText.text = nameTextFormat.Replace("{name}", skillType.displayName);
        levelText.text = levelTextFormat.Replace("{cur}", SkillCanvas.skillables[skillableIndex].skillData.GetSkill(skillType).level.ToString())
            .Replace("{max}", SkillCanvas.skillables[skillableIndex].skillData.GetSkill(skillType).maxLevel.ToString());
        slider.value = SkillCanvas.skillables[skillableIndex].skillData.GetSkill(skillType).xp;
    }

    #endregion

    #region Helper Methodes
    /*
     *
     *  Helper Methodes
     * 
     */

    #endregion
}
