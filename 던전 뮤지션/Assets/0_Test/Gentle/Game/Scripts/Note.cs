﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//라인의 시작부분의 크기와 끝부분 크기 비교해서 노트 크기 조정으로 내려오면서 커지는 걸 표현

public enum NoteType
{
    NORMAL,
    LONG,
    LONG_START,
    LONG_LINE,
    LONG_END,
    SLIDER,

    END,
}

public class Note : MonoBehaviour
{
    private Note[] longnotes;
    [SerializeField]
    private SpriteRenderer sprite;

    private NoteType type;
    private Line line;

    private float size;

    private bool isactive;
    private bool isdestroy;

    private bool ischanged;

    private int ischecked = 0;

    private bool isreverse = false;

    public int linenum;

    public NoteData notedata;
    
    private void FixedUpdate()
    {
        transform.position += (Vector3)Variation;

        transform.localScale = line.StartObjectScale + (line.EndObjectScale - line.StartObjectScale) / (line.Distance / Vector2.Distance(line.StartPos, transform.position));

        if (type == NoteType.LONG_LINE)
        {
            Vector3 scale = transform.localScale;
            scale.y = size * 1.27f;
            scale.x = 0.6f;

            transform.localScale = scale;
        }


        if (EndPos.y < -4f)
        {
            ParticleManager.instance.longNoteUp(linenum);

            //if (!(NoteType.LONG <= type && type <= NoteType.LONG_END))
            GameManager.Instance.Combo = 0;

            DestroyNote();
        }
    }

    public Note Init(Line line, NoteType type, float speed, float size)
    {
        sprite = GetComponent<SpriteRenderer>();

        gameObject.SetActive(true);
        gameObject.name = "Note";

        isactive = true;
        isdestroy = false;

        transform.position = line.StartPos;
        this.line = line;
        this.type = type;
        //this.Speed = speed;

        this.size = size;

        transform.localScale = line.StartObjectScale;
        Line[] lines;
        lines = GameManager.Instance.Lines;
        linenum = -1;
        for (linenum = 0; linenum < lines.Length; linenum++)
        {
            if (lines[linenum] == line)
            {
                break;
            }

        }

        if (type == NoteType.SLIDER)
        {
            for (int i = 0; i < 4; i++)
            {
                if(line == GameManager.Instance.Lines[i])
                {
                    sprite.sprite = GameManager.Instance.SliderNoteSprite[((i == 0 || i == 3) ? 0 : 1)];

                    break;
                }
            }
        }

        if (size != 0f)
        {
            longnotes = new Note[3];

            if (type == NoteType.LONG_START)
            {

            }
            else if (type == NoteType.LONG_LINE)
            {
                transform.position = Position - line.Direction * (size / 2f);
                transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(line.Direction.y, line.Direction.x) * Mathf.Rad2Deg + 90);

                sprite.sprite = GameManager.Instance.LongNoteSprite;
                sprite.sortingOrder = 3;
            }
            else if (type == NoteType.LONG_END)
            {
                transform.position = Position - line.Direction * size;
            }
        }

        return this;
    }

    public void NoteDataInit(NoteData notedata)
    {
        this.notedata = notedata;
    }

    public void AddLongNote(Note note)
    {
        if (note.Type == NoteType.LONG_START)
            longnotes[0] = note;
        if (note.Type == NoteType.LONG_LINE)
            longnotes[1] = note;
        if (note.Type == NoteType.LONG_END)
            longnotes[2] = note;
    }

    public float TouchedNote(TouchPhase phase)
    {
        float distance = -1f;
        float temp;
        NoteType temptype = type;

        if (NoteType.LONG <= temptype && temptype <= NoteType.LONG_END)
        {
            if (longnotes[0].Position.y + 0.5f < line.EndPos.y && longnotes[2].Position.y - 0.5f > line.EndPos.y)
                temptype = NoteType.LONG_LINE;
        }

        if (temptype == NoteType.SLIDER || (temptype == NoteType.NORMAL && phase != TouchPhase.Began))
            distance = 1f;

        if (temptype == NoteType.NORMAL && phase == TouchPhase.Began)
        {
            temp = Vector2.Distance(Position, line.EndPos);

            if (temp < 2f)
            {
                distance = temp * 0.5f;
                isdestroy = true;
            }
        }
        else if (temptype == NoteType.LONG_START && phase == TouchPhase.Began && Ischecked != 3)
        {
            temp = Vector2.Distance(StartPos, line.EndPos);



            if (temp < 2f)
            {
                distance = temp * 0.5f;
                Ischecked = 1;
                ParticleManager.instance.longNoteDown(linenum);
            }
            else
                isactive = false;
        }
        else if (temptype == NoteType.LONG_LINE && phase == TouchPhase.Stationary && Ischecked != 0 && Ischecked != 3)
        {
            temp = Vector2.Distance((Position + ((Position.y > line.EndPos.y ? 1f : -1f) * (line.Direction * Vector2.Distance(line.EndPos, Position)))), line.EndPos);

            //Debug.Log("linein");

            if (temp < 2f)
            {
                distance = 0f;
                Ischecked = 2;
            }
            else
                isactive = false;
        }
        else if (temptype == NoteType.LONG_LINE && phase == TouchPhase.Ended && Ischecked != 0 && Ischecked != 3)
        {
            ParticleManager.instance.longNoteUp(linenum);

            Ischecked = 3;
            GameManager.Instance.Combo = 0;

            longnotes[0].sprite.color = longnotes[0].sprite.color + new Color(0, 0, 0, -0.5f);
            longnotes[1].sprite.color = longnotes[1].sprite.color + new Color(0, 0, 0, -0.5f);
            longnotes[2].sprite.color = longnotes[2].sprite.color + new Color(0, 0, 0, -0.5f);
        }
        else if (temptype == NoteType.LONG_END && phase == TouchPhase.Ended && Ischecked != 3)
        {

            temp = Vector2.Distance(EndPos, line.EndPos);

            if (temp < 2f)
            {
                distance = temp * 0.5f;
                Ischecked = 3;

                if (Vector2.Distance(line.EndPos, (Vector2)longnotes[2].transform.position) < 0.5f)
                {
                    ParticleManager.instance.longNoteUp(linenum);
                    longnotes[0].DestroyNote();
                    longnotes[1].DestroyNote();
                    longnotes[2].DestroyNote();
                }
            }
            else
            {

                isactive = false;
            }
        }
        else if (temptype == NoteType.SLIDER && (phase == TouchPhase.Moved || phase == TouchPhase.Stationary))
        {
            temp = Mathf.Abs(Position.y - line.EndPos.y);

            if (temp < 0.5f)
            {
                distance = 0f;
                isdestroy = true;
            }
            else
                return 0f;
        }
        else if (isactive == true && (temptype == NoteType.LONG_START || temptype == NoteType.LONG_LINE || temptype == NoteType.LONG_END) && (phase == TouchPhase.Began || phase == TouchPhase.Stationary || phase == TouchPhase.Ended))
        {
            return 0f;
        }

        return (distance >= 0 ? 1f - distance : -1f);
    }

    public bool ChanageLine()
    {
        //이동될 부분에 이미 노트가 있는지 확인하고 배치

        if ((NoteType.LONG <= type && type <= NoteType.LONG_END) || ischanged == true)
            return false;

        float dis = Vector2.Distance(line.StartPos, Position);
        Line nline = line;
        int num = 0;

        while (nline == line)
        {
            num = Random.Range(0, 4);
            nline = GameManager.Instance.Lines[num];
        }

        line = nline;

        transform.position = line.StartPos + line.Direction * dis;
        transform.rotation = GameManager.Instance.Originalnote[num].transform.rotation;
        transform.localScale = line.StartObjectScale + (line.EndObjectScale - line.StartObjectScale) / (line.Distance / dis);

        sprite.sprite = GameManager.Instance.Originalnote[num].sprite.sprite;
        ischanged = true;

        return true;
    }

    public void DestroyNote()
    {
        GameManager.Instance.Notes.Remove(this);
        Destroy(gameObject);
    }

    #region Properties

    public Vector2 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            if (NoteType.LONG <= type && type <= NoteType.LONG_END)
            {
                Vector2 pos = value - (Vector2)transform.position;

                for (int i = 0; i < longnotes.Length; i++)
                {
                    longnotes[i].transform.position = (Vector2)longnotes[i].transform.position + pos;
                }
            }

            transform.position = value;


            if (NoteType.LONG <= type && type <= NoteType.LONG_END)
            {
                Vector2 dpos = longnotes[2].transform.position - longnotes[0].transform.position;

                for (int i = 0; i < longnotes.Length; i++)
                    longnotes[i].transform.position += (Vector3)dpos;
            }
        }
    }

    public Vector2 StartPos
    {
        get
        {
            if (type == NoteType.LONG_START)
                return Position;
            if (type == NoteType.LONG_END)
                return Position + line.Direction * size;


            return Position + line.Direction * (size / 2f);
        }
    }

    public Vector2 EndPos
    {
        get
        {
            if (type == NoteType.LONG_START)
                return Position - line.Direction * size;
            if (type == NoteType.LONG_END)
                return Position;

            return Position - line.Direction * (size / 2f);
        }
    }

    public NoteType Type
    {
        get
        {
            return type;
        }
    }

    public Line Line
    {
        get
        {
            return line;
        }
    }

    public float Size
    {
        get
        {
            return size;
        }
    }

    public bool IsDestroy
    {
        get
        {
            return isdestroy;
        }
    }

    public bool Isactive
    {
        get
        {
            if (type == NoteType.LONG_END || type == NoteType.LONG_LINE || type == NoteType.LONG_START)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (longnotes[i] == false)
                        return false;
                }

                return true;
            }

            return isactive;
        }
        set
        {
            isactive = value;


            if (type == NoteType.LONG_END || type == NoteType.LONG_LINE || type == NoteType.LONG_START)
            {
                longnotes[0].isactive = value;
                longnotes[1].isactive = value;
                longnotes[2].isactive = value;
            }
        }
    }

    public bool IsReverse
    {
        get
        {
            return isreverse;
        }
        set
        {

            isreverse = value;
        }
    }

    public bool IsChanged
    {
        get
        {
            return ischanged;
        }
    }

    public Vector2 Variation
    {
        get
        {
            return line.Direction * Speed;
        }
    }

    private int Ischecked
    {
        get
        {
            return ischecked;
        }

        set
        {
            longnotes[0].ischecked = value;
            longnotes[1].ischecked = value;
            longnotes[2].ischecked = value;
        }
    }

    public float Speed
    {
        get
        {
            return GameManager.Instance.NoteSpeed * (isreverse == true ? -1f : 1f);
        }
    }
    #endregion
}