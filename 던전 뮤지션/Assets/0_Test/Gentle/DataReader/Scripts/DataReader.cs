using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Bundle
{
    public string name;
    public int bundlenum;
    public Sprite sprite;

    public List<Music> musics;

    public Bundle(string bundlenum, string name, Sprite sprite)
    {
        int.TryParse(bundlenum, out this.bundlenum);
        this.name = name;
        this.sprite = sprite;

        musics = new List<Music>();
    }
}

[System.Serializable]
public struct Music
{
    public enum Mood
    {
        HAPPY,
    }

    public string name;
    public int bundlenum;
    public int musicnum;
    public Mood mood;
    public Sprite sprite;

    public List<NoteData> notes;

    public Music(string bundlenum, string musicnum, string name, string mood, Sprite sprite)
    {
        int intmood;
        int.TryParse(mood, out intmood);

        int.TryParse(bundlenum, out this.bundlenum);
        int.TryParse(musicnum, out this.musicnum);
        this.name = name;
        this.mood = (Mood)intmood;
        this.sprite = sprite;

        notes = new List<NoteData>();
    }
}

[System.Serializable]
public class NoteData
{
    public int bundlenum;
    public int musicnum;

    public float time;
    public Line line;
    public NoteType type;
    public float value;

    public NoteData(string bundlenum, string musicnum, string time, string line, string type, string value)
    {
        int linenum;
        int.TryParse(line, out linenum);

        int.TryParse(bundlenum, out this.bundlenum);
        int.TryParse(musicnum, out this.musicnum);
        float.TryParse(time, out this.time);
        this.line = GameManager.Instance.Lines[linenum - 1];
        this.type = type.ToNoteType();
        float.TryParse(value, out this.value);
    }
}

[System.Serializable]
public struct Relics
{
    public string name;
    public int relicsnum;
    public string explain;
    public Sprite sprite;

    public Relics(string relicsnum, string name, string explain, Sprite sprite)
    {
        int temp;
        int.TryParse(relicsnum, out temp);

        this.relicsnum = temp;
        this.name = name;
        this.explain = explain;
        this.sprite = sprite;
    }
}

public class DataReader : MonoBehaviour {

    private void Awake()
    {
        FileNameReader();
    }

    private void FileNameReader()
    {
        List<string> files = new List<string>();
        Object obj = Resources.Load("Datas/Files");

        string temp = string.Empty;
        for (int i = 0; i < obj.ToString().Length; i++)
        {
            if (obj.ToString()[i] == ',' || obj.ToString().Length - 1 == i)
            {
                files.Add(temp);
                temp = string.Empty;
                continue;
            }
            else if (obj.ToString()[i] == '\r' || obj.ToString()[i] == '\n')
                continue;

            temp += obj.ToString()[i];
        }

        for (int i = 0; i < files.Count; i++)
        {
            FileReader(files[i]);
        }
    }

    private void FileReader(string filename)
    {
        List<string> datas = new List<string>();
        Object obj = Resources.Load("Datas/" + filename);

        string temp = string.Empty;
        bool comment = false;
        for (int i = 0; i < obj.ToString().Length; i++)
        {
            if (obj.ToString()[i] == '*')
                comment = true;

            if (comment == true)
            {
                if (obj.ToString()[i] == '\n')
                    comment = false;

                continue;
            }

            if (obj.ToString()[i] == ',')
            {
                datas.Add(temp);
                temp = string.Empty;
                continue;
            }
            else if (obj.ToString()[i] == '\r' || obj.ToString().Length - 1 == i)
            {
                datas.Add(temp);
                temp = string.Empty;

                datas.Add("end");

                continue;
            }
            else if (obj.ToString()[i] == '\n')
            {
                temp = string.Empty;

                continue;
            }

            temp += obj.ToString()[i];
        }

        if (filename == "BundleDatas")
            InsertBundleDatas(datas);
        else if (filename == "MusicDatas")
            InsertMusicDatas(datas);
        else if (filename == "NoteDatas")
            InsertNoteDatas(datas);
        else if (filename == "RelicsDatas")
            InsertRelicsDatas(datas);
    }

    private void InsertBundleDatas(List<string> datas)
    {
        List<Bundle> bundles = new List<Bundle>();

        for (int i = 3; i < datas.Count; i+=4)
        {
            if (datas[i] == "end")
                bundles.Add(new Bundle(datas[i - 3], datas[i - 2], Resources.Load<Sprite>(datas[i - 1])));
        }

        GameManager.Instance.ReadDatas.bundles.AddRange(bundles);
    }

    private void InsertMusicDatas(List<string> datas)
    {
        List<Music> musics = new List<Music>();

        for (int i = 5; i < datas.Count; i+=6)
        {
            if (datas[i] == "end")
                musics.Add(new Music(datas[i - 5], datas[i - 4], datas[i - 3], datas[i - 2], Resources.Load<Sprite>(datas[i - 1])));
        }

        for (int i = 0; i < musics.Count; i++)
        {
            for (int j = 0; j < GameManager.Instance.ReadDatas.bundles.Count; j++)
            {
                if (GameManager.Instance.ReadDatas.bundles[j].bundlenum == musics[i].bundlenum)
                {
                    GameManager.Instance.ReadDatas.bundles[j].musics.Add(musics[i]);
                    break;
                }
            }
        }
    }

    private void InsertNoteDatas(List<string> datas)
    {
        List<NoteData> notes = new List<NoteData>();

        for (int i = 6; i < datas.Count; i+=7)
        {
            if (datas[i] == "end")
                notes.Add(new NoteData(datas[i - 6], datas[i - 5], datas[i - 4], datas[i - 3], datas[i - 2], datas[i - 1]));
        }

        for (int i = 0; i < notes.Count; i++)
        {
            for (int j = 0; j < GameManager.Instance.ReadDatas.bundles.Count; j++)
            {
                if (GameManager.Instance.ReadDatas.bundles[j].bundlenum == notes[i].bundlenum)
                {
                    for (int k = 0; k < GameManager.Instance.ReadDatas.bundles[j].musics.Count; k++)
                    {
                        if (GameManager.Instance.ReadDatas.bundles[j].musics[k].musicnum == notes[i].musicnum)
                        {
                            for (int l = 0; l < GameManager.Instance.ReadDatas.bundles[j].musics[k].notes.Count + 1; l++)
                            {
                                if (l == GameManager.Instance.ReadDatas.bundles[j].musics[k].notes.Count)
                                {
                                    GameManager.Instance.ReadDatas.bundles[j].musics[k].notes.Add(notes[i]);
                                    break;
                                }
                                else if (GameManager.Instance.ReadDatas.bundles[j].musics[k].notes[l].time >= notes[i].time)
                                {
                                    GameManager.Instance.ReadDatas.bundles[j].musics[k].notes.Insert(l, notes[i]);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }
    }

    private void InsertRelicsDatas(List<string> datas)
    {
        List<Relics> relics = new List<Relics>();

        for (int i = 4; i < datas.Count; i += 5)
        {
            if (datas[i] == "end")
                relics.Add(new Relics(datas[i - 4], datas[i - 3], datas[i - 2], Resources.Load<Sprite>(datas[i - 1])));
        }

        GameManager.Instance.ReadDatas.relicses.AddRange(relics);
    }

    //private IEnumerator ReadNote()
    //{
    //    string[] textlines = File.ReadAllLines(@"..\던전 뮤지션\Assets\0_Test\Gentle\NoteRecorder\RecordFile.txt");
    //    List<NoteProperty> noteproperties = new List<NoteProperty>();
    //    float storetime = 0f;

    //    for (int i = 0; i < textlines.Length; i++)
    //    {
    //        textlines[i].Trim();

    //        if (textlines[i][0] != '*')
    //        {
    //            string text = string.Empty;
    //            NoteProperty noteproperty = new NoteProperty();

    //            for (int j = 0; j < textlines[i].Length; j++)
    //            {
    //                if (textlines[i][j] != ',')
    //                    text += textlines[i][j];
    //                else
    //                {
    //                    if (noteproperty.time == -1f)
    //                        float.TryParse(text, out noteproperty.time);
    //                    else if (noteproperty.line == -1)
    //                        int.TryParse(text, out noteproperty.line);
    //                    else if (noteproperty.type == string.Empty)
    //                        noteproperty.type = text;
    //                    else if (noteproperty.typevalue == -1)
    //                        float.TryParse(text, out noteproperty.typevalue);

    //                    text = string.Empty;
    //                }
    //            }

    //            noteproperties.Add(noteproperty);

    //            for (int j = 0; j < noteproperties.Count; j++)
    //            {
    //                if (noteproperties[j].time > noteproperty.time)
    //                {
    //                    noteproperties.Remove(noteproperty);
    //                    noteproperties.Insert(j, noteproperty);
    //                    break;
    //                }
    //            }
    //        }
    //    }

    //    foreach (NoteProperty note in noteproperties)
    //    {
    //        yield return new WaitForSeconds(note.time - storetime);
    //        storetime = note.time;

    //        GameManager.Instance.CreateNote(GameManager.Instance.Lines[note.line - 1], note.type.ToNoteType(), note.typevalue);
    //    }
    //}

}
