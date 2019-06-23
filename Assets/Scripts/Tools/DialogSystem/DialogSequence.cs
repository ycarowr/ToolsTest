﻿namespace Tools
{
    public partial class DialogSystem
    {
        private class DialogSequence : DialogSubComponent
        {
            public DialogSequence(IDialogSystem system) : base(system)
            {
            }

            public TextSequence Sequence { get; private set; }
            public int IndexPieces { get; private set; }
            public bool IsLast => Sequence.Sequence.Length - 1 == IndexPieces;

            public void SetSequence(TextSequence sequence)
            {
                Sequence = sequence;
            }

            public void Hide()
            {
                IndexPieces = 0;
                Sequence = null;
            }

            public TextPiece Get(int index)
            {
                if (Sequence == null)
                    return null;

                return index < Sequence.Sequence.Length
                    ? Sequence.Sequence[index]
                    : null;
            }

            public TextPiece GetCurrent()
            {
                return Get(IndexPieces);
            }

            public TextPiece GetNext()
            {
                if (Sequence == null)
                    return null;

                ++IndexPieces;
                return GetCurrent();
            }
        }


        //-----------------------------------------------------------------------------------------
    }
}