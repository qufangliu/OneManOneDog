namespace Character
{
    public class CharacterProperty
    {
        private int _mood;

        public int mood
        {
            get => _mood;
            set => _mood = value;
        }

        public int gold;
        public int HP;
    }
}