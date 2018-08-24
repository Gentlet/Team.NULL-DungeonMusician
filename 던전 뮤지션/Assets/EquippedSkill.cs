using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EquippedSkill : MonoBehaviour
{

    public Sprite[] sprites;
    public Image LeftImage;
    public Image RightImage;

    public Scream scream; // 0
    public Vibration vibration; // 1
    public VolumeUp volumeUp; // 2
    public Busking busking; //3
    public SpotLightSkill spotLight; //4

    public CustomToggleGroup CTG;
    public int LeftSkill;
    public int RightSkill;
    private void Update()
    {
        if (LeftSkill != -1)
            if (!CTG.toggles[LeftSkill].isOn)
            {
                LeftSkill = -1;
                LeftImage.sprite = null;
            }
        if (RightSkill != -1)
            if (!CTG.toggles[RightSkill].isOn)
            {
                RightSkill = -1;
                RightImage.sprite = null;
            }


        for (int i = 0; i < CTG.toggles.Length; i++)
        {
            if (CTG.toggles[i].isOn)
            {
                if (LeftSkill == -1)
                {
                    LeftSkill = i;
                    LeftImage.sprite = sprites[i];
                }
                else
                {
                    RightSkill = i;
                    RightImage.sprite = sprites[i];
                }
            }
        }


    }
    public void SkillActive(bool isLeft)
    {

        int AT = -1;
        if (isLeft)
            AT = LeftSkill;
        else
            AT = RightSkill;


        switch (AT)
        {
            case 0:
                scream.Active();
                break;

            case 1:
                vibration.Active();
                break;

            case 2:
                volumeUp.Active();
                break;

            case 3:
                busking.Active();
                break;

            case 4:
                spotLight.Active();
                break;
        }

    }
}
