using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct NoteValues
{
    public Line[] lines;
    public Note[] originalnote;
    public Sprite longnotesprite;
    public Sprite[] slidernotesprite;

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
    [Header("Combo Text Image")]
    [SerializeField]
    private SpriteRenderer[] combo_text;
    [SerializeField]
    private GameObject combo_texts;

    [Space]
    [Header("PlayCanvas")]
    [SerializeField]
    private GameObject[] ingameobj;
    [SerializeField]
    private GameObject[] menuobj;

    [Space]
    [Header("TEST VALUES")]
    public NoteType notetype;

    public float size;
    public AudioSource audio;

    public Image fade;

    //public bool isbattle;

    private void Awake()
    {
        notevalues.notes = new List<Note>();
    }

    private void Update()
    {
        //for (int i = 0; i < 4; i++)
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha1 + i))
        //    {
        //        CreateNote(Lines[i], notetype, size);
        //    }
        //}

        //if (Input.GetKeyDown(KeyCode.M))
        //    PlayGame(0, 0, 0);

        if (Input.GetKeyDown(KeyCode.D))
            Lines[0].TouchLineBtn(0);
        if (Input.GetKey(KeyCode.D))
            Lines[0].TouchLineBtn(2);
        if (Input.GetKeyUp(KeyCode.D))
            Lines[0].TouchLineBtn(3);

        if (Input.GetKeyDown(KeyCode.F))
            Lines[1].TouchLineBtn(0);
        if (Input.GetKey(KeyCode.F))
            Lines[1].TouchLineBtn(2);
        if (Input.GetKeyUp(KeyCode.F))
            Lines[1].TouchLineBtn(3);

        if (Input.GetKeyDown(KeyCode.J))
            Lines[2].TouchLineBtn(0);
        if (Input.GetKey(KeyCode.J))
            Lines[2].TouchLineBtn(2);
        if (Input.GetKeyUp(KeyCode.J))
            Lines[2].TouchLineBtn(3);

        if (Input.GetKeyDown(KeyCode.K))
            Lines[3].TouchLineBtn(0);
        if (Input.GetKey(KeyCode.K))
            Lines[3].TouchLineBtn(2);
        if (Input.GetKeyUp(KeyCode.K))
            Lines[3].TouchLineBtn(3);
    }

    public void TurnOnGame()
    {
        for (int i = 0; i < ingameobj.Length; i++)
        {
            ingameobj[i].SetActive(true);
        }
        for (int i = 0; i < menuobj.Length; i++)
        {
            menuobj[i].SetActive(false);
        }

        PlayGame(0, 0, -1);
    }

    public void TurnOffGame()
    {
        for (int i = 0; i < notevalues.notes.Count; i++)
        {
            GameObject.Destroy(notevalues.notes[i].gameObject);
        }
        notevalues.notes.Clear();

        for (int i = 0; i < 4; i++)
        {
            ParticleManager.instance.longNoteUp(i);
            Lines[i].EndGame();
        }

        notevalues.combo = 0;

        for (int i = 0; i < ingameobj.Length; i++)
        {
            ingameobj[i].SetActive(false);
        }
        for (int i = 0; i < menuobj.Length; i++)
        {
            menuobj[i].SetActive(true);
        }
    }

    public void PlayGame(int bn, int mn, int en)
    {
        for (int i = 0; i < notevalues.notes.Count; i++)
        {
            GameObject.Destroy(notevalues.notes[i].gameObject);
        }
        notevalues.notes.Clear();

        StartMusic(bn, mn);
        EnemyManager.Instance.CreateEnemy(en);
        //isbattle = true;
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

    private IEnumerator CreateComboText(int combo)
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        GameObject parent = new GameObject("ComboText");
        List<SpriteRenderer> combotexts = new List<SpriteRenderer>();

        int temp = combo;
        string temps = temp.ToString();

        if (combo > 0)
        {
            combotexts.Add(Instantiate(combo_text[10], parent.transform));

            //콤보 문자 생성
            while (0 < combo)
            {
                combotexts.Insert(1, Instantiate(combo_text[combo % 10], parent.transform));
                combo /= 10;
                combotexts[1].sortingOrder += temp;
            }

            //Combo Text 좌표 수정
            combotexts[0].transform.position = new Vector3((temps[temps.Length - 1] == '1' ? -0.06f : (temps[0] == '1' ? 0.06f : 0f)) * (temps.Length > 2 ? 1 : 0.5f), -0.5f, 0);

            for (int i = 1; i < combotexts.Count; i++)
                combotexts[i].transform.position = new Vector3(((i - 1) * 0.5f) - ((combotexts.Count - 2) * 0.25f), 1.8f);
            combotexts[0].transform.position += Vector3.up * 1.8f;
        }
        else
        {
            combotexts.Add(Instantiate(combo_text[11], Vector3.up * 1.65f, Quaternion.identity, parent.transform));
            combotexts[0].sortingOrder += combo_texts.transform.childCount + 1;
        }

        parent.transform.parent = combo_texts.transform;

        //콤보 색 연하게
        while (parent.transform.position.y < 2f)
        {
            parent.transform.position += Vector3.up * 0.01f;

            foreach (SpriteRenderer sprite in combotexts)
            {
                sprite.color = sprite.color - new Color(0, 0, 0, 0.025f);
            }

            yield return wait;
        }

        Destroy(parent);
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

    public Sprite[] SliderNoteSprite
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

    public int Combo
    {
        get
        {
            return notevalues.combo;
        }

        set
        {
            //if (notevalues.combo == 0 && value == 0)
            //    return;

            notevalues.combo = value;

            if (notevalues.combo != 0)
            {
                HelperGuitar.instance.AbilityActive();
            }

            StartCoroutine(CreateComboText(notevalues.combo));
        }
    }

    public float NoteSpeed
    {
        get
        {
            return notevalues.speed;
        }

        set
        {
            notevalues.speed = value;
        }
    }
    #endregion
}