using UnityEngine;

namespace Utils
{
    public static class MathUtils
    {
        public static float Round2F(float f)
        {
            return Mathf.Round(f * 100f) / 100f;
        }
        
    }
}