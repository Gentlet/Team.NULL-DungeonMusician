using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InstanceStringExtension
{
    public static NoteType ToNoteType(this string source)
    {
        for (int i = 0; i < (int)NoteType.END; i++)
        {
            if((NoteType.NORMAL + i).ToString() == source.Trim().ToUpper())
            {
                return (NoteType.NORMAL + i);
            }
        }

        return NoteType.END;
    }
}
