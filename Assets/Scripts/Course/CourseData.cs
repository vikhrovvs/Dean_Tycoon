namespace Course
{
    public class CourseData
    {
        private float m_Price;
        private float m_MotivationDelta;
        private float m_ScoreDelta;

        public float Price => m_Price;

        public float MotivationDelta => m_MotivationDelta;

        public float ScoreDelta => m_ScoreDelta;

        public CourseData()
        {
            m_Price = 1;
            m_MotivationDelta = 1;
            m_ScoreDelta = 1;
        }
    }
}