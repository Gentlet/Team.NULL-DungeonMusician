using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RNote : MonoBehaviour {
    public NoteType type;

    public RNote rnote;
    public int node;
    public int line;

    public void Init(NoteType t, RNote r, int n, int l)
    {
        type = t;
        rnote = r;
        node = n;
        line = l;

        if (type == NoteType.LONG)
            GetComponent<SpriteRenderer>().color = Color.blue;
        else if(type == NoteType.LONG_END)
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
            rnote.rnote = this;
        }
        else if (type == NoteType.SLIDER)
            GetComponent<SpriteRenderer>().color = Color.yellow;
    }
}
