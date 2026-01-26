namespace LeetCode
{
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s)) 
                return 0;

            int longestLength = 0;

            Dictionary<char, int> dict = new Dictionary<char, int>();

            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                char c = s[right];

                if (dict.TryGetValue(c, out int i))
                {
                    left = Math.Max(left, i + 1);

                    if (longestLength >= s.Length - left)
                        break;
                }

                dict[c] = right;
                longestLength = Math.Max(longestLength, right - left + 1);
            }
            return longestLength;
        }
    }
}
