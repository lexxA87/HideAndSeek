﻿namespace HideAndSeek
{
    public class Opponent
    {
        public readonly string Name;
        public Opponent(string name) => Name = name;
        public override string ToString() => Name;
        public void Hide()
        {
            throw new NotImplementedException();
        }
    }
}