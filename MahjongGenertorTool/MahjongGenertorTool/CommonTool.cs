using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongGenertorTool
{
    class CommonTool
    {
        /// <summary>
        /// 组合算法
        /// </summary>
        /// <typeparam name="T">要组合的列表类型</typeparam>
        /// <param name="targetList">存储目标组合集合的列表</param>
        /// <param name="list">目标列表</param>
        /// <param name="target">目标存储组合容器</param>
        /// <param name="k">目标组合列表中的元素个数</param>
        public static void combineSelect<T>(List<List<T>> targetList, List<T> list, List<T> target, int k)
        {
            List<T> copyList;
            List<T> copyTarget;

            if (target.Count == k)
            {
                targetList.Add(target);
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                copyList = new List<T>(list);
                copyTarget = new List<T>(target);
                copyTarget.Add(copyList[i]);
                for (int j = i; j >= 0; j--)
                {
                    copyList.RemoveAt(j);
                }
                combineSelect(targetList, copyList, copyTarget, k);
            }
        }
    }
}
