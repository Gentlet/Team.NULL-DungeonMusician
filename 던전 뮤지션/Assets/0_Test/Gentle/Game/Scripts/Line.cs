﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line : MonoBehaviour
{
    private GameObject start;
    private GameObject end;

    [SerializeField]
    private GameObject touchline;

    //private TouchSim touchsim;

    private int linephase;

    private void Awake()
    {
        //touchsim = TouchSim.Instance;

        if (start == null)
            start = transform.GetChild(0).gameObject;
        if (end == null)
            end = transform.GetChild(1).gameObject;
    }

    /*
    private void Update()
    {
        touchline.SetActive(false);

        if (GameManager.Instance.isbattle && touchsim.state != 0 && Vector2.Distance(touchsim.transform.position, EndPos) < EndObjectScale.x)
        {
            Note note = GameManager.Instance.NearestNote(this);

            if (note != null && note.Isactive == true)
            {
                float rank = note.TouchedNote(touchsim.phase);

                if (note.IsDestroy)
                    note.DestroyNote();

                if (rank >= 0.3f)
                {
                    if (NoteType.LONG <= note.Type && note.Type <= NoteType.LONG_END)
                    {
                        if (rank == 1f)
                            GameManager.Instance.Combo += 1;
                        rank *= 0.3f;
                    }
                    else
                        GameManager.Instance.Combo += 1;


                    float damage = rank * Player.Instance.GetStatus("Strength") * (Random.Range(0f, 100f) < Player.Instance.GetStatus("Criticalrate") ? Player.Instance.GetStatus("Criticaldamage") / 100f : 1f);
                    EnemyManager.Instance.Enemy.AttackEnemy(damage);
                    Player.Instance.Health += damage * Player.Instance.GetStatus("Healthdrainrate");

                    //Debug.Log(damage);
                }
            }

            touchline.SetActive(true);
            //Debug.Log(gameObject.name + touchsim.phase);
        }
    }
    */

    //0 == Began
    //1 == Moved
    //2 == Stationary
    //3 == Ended
    //4 == Canceled
    public void TouchLineBtn(int phase)
    {
        touchline.SetActive(true);

        Note note = GameManager.Instance.NearestNote(this);

        if (note != null && note.Isactive == true)
        {
            float rank = note.TouchedNote((TouchPhase)phase);

            if (note.IsDestroy)
                note.DestroyNote();

            if (rank >= 0.3f)
            {
                if (NoteType.LONG <= note.Type && note.Type <= NoteType.LONG_END)
                {
                    if (rank == 1f)
                        GameManager.Instance.Combo += 1;
                    rank *= 0.3f;
                }
                else
                    GameManager.Instance.Combo += 1;


                float damage = rank * Player.Instance.GetStatus("Strength") * (Random.Range(0f, 100f) < Player.Instance.GetStatus("Criticalrate") ? Player.Instance.GetStatus("Criticaldamage") / 100f : 1f);
                EnemyManager.Instance.Enemy.AttackEnemy(damage);
                Player.Instance.Health += damage * Player.Instance.GetStatus("Healthdrainrate");

                //Debug.Log(damage);
            }
            else
                note.Isactive = false;

        }
        
        if ((TouchPhase)phase == TouchPhase.Ended || (TouchPhase)phase == TouchPhase.Canceled)
            touchline.SetActive(false);
    }

    public void TESTFUNCTION(string text)
    {
        Debug.Log(text);
    }

    #region Operators
    public static bool operator ==(Line a, Line b)
    {
        if (a.StartPos == b.StartPos && a.EndPos == b.EndPos)
        {
            return true;
        }

        return false;
    }

    public static bool operator !=(Line a, Line b)
    {
        if (a.StartPos == b.StartPos && a.EndPos == b.EndPos)
        {
            return false;
        }

        return true;
    }
    #endregion

    #region Properties
    public Vector3 StartObjectScale
    {
        get
        {
            return start.transform.localScale;
        }
    }

    public Vector3 EndObjectScale
    {
        get
        {
            return end.transform.localScale;
        }
    }

    public Vector2 StartPos
    {
        get
        {
            return start.transform.position;
        }
    }

    public Vector2 EndPos
    {
        get
        {
            return end.transform.position;
        }
    }

    public Vector2 Direction
    {
        get
        {
            return (EndPos - StartPos).normalized;
        }
    }

    public float Distance
    {
        get
        {
            return Vector3.Distance(start.transform.position, end.transform.position);
        }
    }
    #endregion
}
