using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 合并排序
{
    class Class1
    {
        public int[] mergeSort(int[] nums1, int[] nums2)
        {
            int[] addNum = new int[nums1.Length + nums2.Length];
            int n1 = 0, n2 = 0;
            int i = 0;
            while (i < addNum.Length)
            {
                if (n1 < nums1.Length && n2 < nums2.Length)
                {
                    if (nums1[n1] < nums2[n2])
                    {
                        addNum[i] = nums1[n1];
                        i++;
                        n1++;
                    } else
                    {
                        addNum[i] = nums2[n2];
                        i++;
                        n2++;
                    }
                } else if (n1 == nums1.Length)
                {
                    addNum[i] = nums2[n2];
                    i++;
                    n2++;
                } else if (n2 == nums1.Length)
                {
                    addNum[i] = nums1[n1];
                    i++;
                    n1++;
                }
            }

            return addNum;
        }
    }
}
