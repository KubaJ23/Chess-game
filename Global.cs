namespace Chess
{
    public static class Global
    {
        public static bool CheckForIndex(int y, int x)
        {
            if (y >= 0 && y < 8 && x >= 0 && x < 8)
            {
                return true;
            }
            return false;
        }
    }
}
