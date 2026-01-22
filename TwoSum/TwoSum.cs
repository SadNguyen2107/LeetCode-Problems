namespace LeetCode
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];

                // If the dictionary contain complement
                // Return that index + map[complement]
                if (map.ContainsKey(complement))
                {
                    return new int[2] { map[complement], i };
                }

                // If that dictionary does not contains that number
                // Add to the dictionary
                map[nums[i]] = i;
            }

            return new int[0];
        }
    }
}
