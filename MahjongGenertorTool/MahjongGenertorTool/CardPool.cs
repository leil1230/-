using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongGenertorTool
{
    class CardPool
    {
        /// <summary>
        /// 序牌
        /// </summary>
        private List<int> orderCards = new List<int>(36);

        /// <summary>
        /// 字牌
        /// </summary>
        private List<int> charCards = new List<int>(28);

        /// <summary>
        /// 初始化牌池
        /// </summary>
        public void initCards()
        {
            initOrderCards();
            initCharCards();
        }

        /// <summary>
        /// 初始化序牌
        /// </summary>
        private void initOrderCards()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    orderCards.Add(j);
                }
            }
        }

        /// <summary>
        /// 获取序牌牌池
        /// </summary>
        /// <returns></returns>
        public List<int> getOrderCards()
        {
            return new List<int>(orderCards);
        }

        /// <summary>
        /// 初始化字牌牌池
        /// </summary>
        private void initCharCards()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 7; j++)
                {
                    charCards.Add(j);
                }
            }
        }

        /// <summary>
        /// 获取字牌牌池
        /// </summary>
        /// <returns></returns>
        public List<int> getCharCards()
        {
            return new List<int>(charCards);
        }
    }
}
