namespace AddressBook.Helper
{
    public static class StringUtils
    {
        public static bool Contains(this string str1, string str2, bool ignoreCase)
        {
            if (ignoreCase)
            {
                str1 = str1.ToLower();
                str2 = str2.ToLower();
            }
            return str1.Contains(str2);
        }
    }
}
