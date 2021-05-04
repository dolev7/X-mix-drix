namespace B21_Ex02_01
{
    public partial class GameManger
    {
        public class Player
        {
            private char m_Symbol;
            private bool m_IsHuman;
            private int m_WinsCounter;
            public bool IsHuman
            {
                get
                {
                    return m_IsHuman;
                }
                set
                {
                    m_IsHuman = value;
                }
            }
            public char Symbol
            {
                get
                {
                    return m_Symbol;
                }
            }
            public int WinsCounter
            {
                get
                {
                    return m_WinsCounter;
                }
                set
                {
                    m_WinsCounter = value;
                }
            }

            public Player(char i_Symbol, bool i_IsHuman)
            {
                m_Symbol = i_Symbol;
                m_IsHuman = i_IsHuman;
                m_WinsCounter = 0;
            }
        }
    }
}
