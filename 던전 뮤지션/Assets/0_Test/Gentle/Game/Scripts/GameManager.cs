using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NoteValues
{
    public Line[] lines;
    public Note[] originalnote;
    public Sprite longnotesprite;
    public Sprite slidernotesprite;

    [HideInInspector]
    public List<Note> notes;

    [SerializeField]
    [Range(0f, 2f)]
    public float speed;

    [HideInInspector]
    public int combo;

    [HideInInspector]
    public bool reverse;
}

[System.Serializable]
public struct ReadData
{
    public List<Bundle> bundles;
    public List<Relics> relicses;
}

public class GameManager : SingletonGameObject<GameManager>
{
    [Header("Note Objects")]
    [SerializeField]
    private NoteValues notevalues;

    [Space]
    [Header("Datas Objects")]
    [SerializeField]
    private ReadData readdatas;

    [Space]
    [Header("TEST VALUES")]
    public NoteType notetype;

    public float size;
    public AudioSource audio;

    private void Awake()
    {
        notevalues.notes = new List<Note>();
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                CreateNote(Lines[i], notetype, size);
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
            PlayGame();

    }

    public void PlayGame()
    {
        for (int i = 0; i < notevalues.notes.Count; i++)
        {
            GameObject.Destroy(notevalues.notes[i].gameObject);
        }
        notevalues.notes.Clear();

        StartMusic(0, 0);
    }

    public Note CreateNote(Line line, NoteType type, float size = 0f)
    {
        for (int i = 0; i < Lines.Length; i++)
        {
            if (Lines[i] == line)
            {
                if (type != NoteType.LONG)
                {
                    Notes.Add(Instantiate(Originalnote[i], transform).Init(line, type, notevalues.speed, size));
                }
                else
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Notes.Add(Instantiate(Originalnote[i], transform).Init(line, (type + j + 1), notevalues.speed, size));
                    }

                    for (int j = 0; j < 3; j++)
                    {
                        for (int z = 0; z < 3; z++)
                        {
                            Notes[Notes.Count - (1 + j)].AddLongNote(Notes[Notes.Count - (1 + z)]);
                        }
                    }
                }

                Notes[Notes.Count - 1].IsReverse = IsReverse;

                break;
            }
        }

        return Notes[Notes.Count - 1];
    }

    public void StartMusic(int bundlenum, int musicnum)
    {
        Music music = new Music();

        for (int i = 0; i < readdatas.bundles.Count; i++)
        {
            if (readdatas.bundles[i].bundlenum == bundlenum)
            {
                for (int j = 0; j < readdatas.bundles[i].musics.Count; j++)
                {
                    if (readdatas.bundles[i].musics[j].musicnum == musicnum)
                    {
                        music = readdatas.bundles[i].musics[j];
                        break;
                    }
                }
                break;
            }
        }

        //audio.clip = music.music;
        audio.Play();

        float interval = (60f / music.bpm) / music.divide;

        foreach (NoteData notedata in music.notes)
        {
            float size = Vector2.Distance((notedata.line.Direction * notevalues.speed) * ((notedata.value - 1) * interval / Time.fixedDeltaTime),
                                          (notedata.line.Direction * notevalues.speed) * ((notedata.time - 1) * interval / Time.fixedDeltaTime));

            if (notedata.value == 0) size = 0;

            Note note = CreateNote(notedata.line, notedata.type, size);
            
            note.NoteDataInit(notedata);

            note.Position = note.Line.EndPos + (note.Variation * ((notedata.time - 1) * interval / Time.fixedDeltaTime) * -1f);
        }
    }

    public Note NearestNote(Line line)
    {
        Note nearestnote = null;
        float dis = 0f;

        for (int i = 0; i < Notes.Count; i++)
        {
            if ((Notes[i].Line == line && (dis > Vector2.Distance(line.EndPos, Notes[i].Position)) || (Notes[i].Line == line && nearestnote == null)))
            {
                dis = Vector2.Distance(line.EndPos, Notes[i].Position);
                nearestnote = Notes[i];
            }
        }

        return nearestnote;
    }

    #region Properties
    public Note[] Originalnote
    {
        get
        {
            return notevalues.originalnote;
        }
    }

    public List<Note> Notes
    {
        get
        {
            return notevalues.notes;
        }
    }

    public Line[] Lines
    {
        get
        {
            return notevalues.lines;
        }
    }

    public Sprite LongNoteSprite
    {
        get
        {
            return notevalues.longnotesprite;
        }
    }

    public Sprite SliderNoteSprite
    {
        get
        {
            return notevalues.slidernotesprite;
        }
    }

    public bool IsReverse
    {
        get
        {
            return notevalues.reverse;
        }

        set
        {
            notevalues.reverse = value;

            for (int i = 0; i < notevalues.notes.Count; i++)
            {
                notevalues.notes[i].IsReverse = value;
            }
        }
    }

    public ReadData ReadDatas
    {
        get
        {
            return readdatas;
        }

        set
        {
            readdatas = value;
        }
    }
    #endregion
}