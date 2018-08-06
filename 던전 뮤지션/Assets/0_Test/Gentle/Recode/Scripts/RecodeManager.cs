using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//0.695

public class RecodeManager : MonoBehaviour {
    public AudioSource music;

    public float bpm;

    public GameObject wlineoriginal;
    public RNote rnoteoriginal;

    public Transform wlinestransform;

    public List<GameObject> wlines;
    public List<RNote> rnotes;

    public float scrollsensitive;

    public Text text;
    public NoteType type;

    public Coroutine play;

    public Text resulttext;

    private float interval;
    private int amount;

    private void Awake()
    {
        interval = 60f / bpm;
        amount = (int)(music.clip.length / interval);

        for (int i = 0; i < amount; i++)
        {
            wlines.Add(Instantiate(wlineoriginal, new Vector3(0, interval * 3f * i), Quaternion.identity, wlinestransform));
        }

        music.Stop();
    }

    private void FixedUpdate()
    {
        if (Input.mouseScrollDelta != Vector2.zero)
        {
            wlinestransform.position += (Vector3)Input.mouseScrollDelta * scrollsensitive * -1f;

            if (play != null)
            {
                StopCoroutine(play);
                music.Stop();
            }
        }
    }

    private void Update()
    {
        if (type == NoteType.NORMAL) NormalRnote();
        if (type == NoteType.LONG || type == NoteType.LONG_END) LongRnote();
        if (type == NoteType.SLIDER) SliderRnote();

        if (type != NoteType.LONG_END && Input.GetKeyDown(KeyCode.Alpha1))
        {
            type = NoteType.NORMAL;
            text.text = type.ToString();
        }
        if (type != NoteType.LONG_END && Input.GetKeyDown(KeyCode.Alpha2))
        {
            type = NoteType.LONG;
            text.text = type.ToString();
        }
        if (type != NoteType.LONG_END && Input.GetKeyDown(KeyCode.Alpha3))
        {
            type = NoteType.SLIDER;
            text.text = type.ToString();
        }


        if (Input.GetMouseButtonDown(1))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < rnotes.Count; i++)
            {
                if (Vector2.Distance((Vector2)rnotes[i].transform.position, point) < 0.695f)
                {
                    RNote temp = rnotes[i];
                    rnotes.Remove(temp);
                    if (temp.rnote != null)
                    {
                        rnotes.Remove(temp.rnote);
                        Destroy(temp.rnote.gameObject);
                    }
                    Destroy(temp.gameObject);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(play != null) StopCoroutine(play);
            play = StartCoroutine(PlayMusic());
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveMusic();
        }
    }

    private void NormalRnote()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < wlines.Count; i++)
            {
                for (int j = -3; j < 4; j++)
                {
                    if (j == -2 || j == 0 || j == 2) continue;

                    if (Vector2.Distance((Vector2)wlines[i].transform.position + new Vector2(0.695f * j, 0), point) < 0.695f)
                    {
                        rnotes.Add(Instantiate(rnoteoriginal, (Vector2)wlines[i].transform.position + new Vector2(0.695f * j, 0), rnoteoriginal.transform.rotation));
                        rnotes[rnotes.Count - 1].transform.parent = wlines[i].transform;
                        rnotes[rnotes.Count - 1].Init(NoteType.NORMAL, null, i + 1, (j + 5) / 2);
                    }
                }
            }
        }
    }

    private void LongRnote()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < wlines.Count; i++)
            {
                for (int j = -3; j < 4; j++)
                {
                    if (j == -2 || j == 0 || j == 2) continue;

                    if (Vector2.Distance((Vector2)wlines[i].transform.position + new Vector2(0.695f * j, 0), point) < 0.695f)
                    {
                        if (type == NoteType.LONG)
                        {
                            rnotes.Add(Instantiate(rnoteoriginal, (Vector2)wlines[i].transform.position + new Vector2(0.695f * j, 0), rnoteoriginal.transform.rotation));
                            rnotes[rnotes.Count - 1].transform.parent = wlines[i].transform;
                            rnotes[rnotes.Count - 1].Init(NoteType.LONG, null, i + 1, (j + 5) / 2);

                            type = NoteType.LONG_END;
                            text.text = type.ToString();
                        }
                        else if (type == NoteType.LONG_END && rnotes[rnotes.Count - 1].node < i + 1 && rnotes[rnotes.Count - 1].line == (j + 5) / 2) 
                        {
                            rnotes.Add(Instantiate(rnoteoriginal, (Vector2)wlines[i].transform.position + new Vector2(0.695f * j, 0), rnoteoriginal.transform.rotation));
                            rnotes[rnotes.Count - 1].transform.parent = wlines[i].transform;
                            rnotes[rnotes.Count - 1].Init(NoteType.LONG_END, rnotes[rnotes.Count - 2], i + 1, (j + 5) / 2);

                            type = NoteType.LONG;
                            text.text = type.ToString();
                        }
                    }
                }
            }
        }
    }

    private void SliderRnote()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 0; i < wlines.Count; i++)
            {
                for (int j = -3; j < 4; j++)
                {
                    if (j == -2 || j == 0 || j == 2) continue;

                    if (Vector2.Distance((Vector2)wlines[i].transform.position + new Vector2(0.695f * j, 0), point) < 0.695f)
                    {
                        rnotes.Add(Instantiate(rnoteoriginal, (Vector2)wlines[i].transform.position + new Vector2(0.695f * j, 0), rnoteoriginal.transform.rotation));
                        rnotes[rnotes.Count - 1].transform.parent = wlines[i].transform;
                        rnotes[rnotes.Count - 1].Init(NoteType.SLIDER, null, i + 1, (j + 5) / 2);
                    }
                }
            }
        }
    }

    IEnumerator PlayMusic()
    {
        WaitForSeconds wait = new WaitForSeconds(0.03f);

        music.Play();
        music.time = wlinestransform.position.y * -1f;

        while (true)
        {
            yield return wait;

            wlinestransform.position += Vector3.down * 0.03f * 3;
        }
    }

    private void SaveMusic()
    {
        string result = string.Empty;

        for (int i = 0; i < rnotes.Count; i++)
        {
            if (rnotes[i].type != NoteType.LONG_END)
                result += rnotes[i].node + "," + rnotes[i].line + "," + rnotes[i].type.ToString() + "," + (rnotes[i].rnote != null ? rnotes[i].rnote.node : 0) + "\r\n";
        }

        resulttext.text = result;
    }
}
