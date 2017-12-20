using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongGenertorTool
{
    class PaiXingFactory
    {
        private CardPool cardPool;

        private Dictionary<string, StringBuilder> orderCombineSbDic = new Dictionary<string, StringBuilder>();

        private Dictionary<string, StringBuilder> charCombineSbDic = new Dictionary<string, StringBuilder>();

        private Dictionary<string, StringBuilder> orderCombineSbWithEyeDic = new Dictionary<string, StringBuilder>();

        private Dictionary<string, StringBuilder> charCombineSbWithEyeDic = new Dictionary<string, StringBuilder>();

        private Dictionary<string, Dictionary<int, bool>> orderCombineNumDic = new Dictionary<string, Dictionary<int, bool>>();

        private Dictionary<string, Dictionary<int, bool>> charCombineNumDic = new Dictionary<string, Dictionary<int, bool>>();

        private Dictionary<string, Dictionary<int, bool>> orderCombineWithEyeNumDic = new Dictionary<string, Dictionary<int, bool>>();

        private Dictionary<string, Dictionary<int, bool>> charCombineWithEyeNumDic = new Dictionary<string, Dictionary<int, bool>>();

        public enum ListType
        {
            Order,
            Char
        }

        private string outputPath = System.Environment.CurrentDirectory + "\\table";

        private bool isAddOrderEye = false;

        private bool isAddCharEye = false;

        public PaiXingFactory()
        {
            cardPool = new CardPool();
            cardPool.initCards();
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            for (int i = 0; i < 9; i++)
            {
                orderCombineSbDic.Add("order_combine_" + i, new StringBuilder());
                charCombineSbDic.Add("char_combine_" + i, new StringBuilder());
                orderCombineSbWithEyeDic.Add("order_combine_eye_" + i, new StringBuilder());
                charCombineSbWithEyeDic.Add("char_combine_eye_" + i, new StringBuilder());

                orderCombineNumDic.Add("order_combine_" + i, new Dictionary<int, bool>());
                charCombineNumDic.Add("char_combine_" + i, new Dictionary<int, bool>());
                orderCombineWithEyeNumDic.Add("order_combine_eye_" + i, new Dictionary<int, bool>());
                charCombineWithEyeNumDic.Add("char_combine_eye_" + i, new Dictionary<int, bool>());
            }
        }

        /// <summary>
        /// 初始化序牌胡牌牌型
        /// </summary>
        public void initAllCombineStr()
        {
            Console.WriteLine("开始生成牌型。。。");
            List<int> huList;
            List<int> hunToBeList;
            for (int targetN = 1; targetN <= 4; targetN++)
            {
                for (int hunNum = 0; hunNum < 9; hunNum++)
                {
                    isAddOrderEye = false;
                    isAddCharEye = false;
                    huList = new List<int>();
                    hunToBeList = new List<int>();
                    getOrderHuCardsList(huList, cardPool.getOrderCards(), 0, targetN, hunNum, hunNum, false, hunToBeList);
                    huList = new List<int>();
                    hunToBeList = new List<int>();
                    getCharHuCardsList(huList, cardPool.getCharCards(), 0, targetN, hunNum, hunNum, false, hunToBeList);
                    huList = new List<int>();
                    hunToBeList = new List<int>();
                    getOrderHuCardsList(huList, cardPool.getOrderCards(), 0, targetN, hunNum, hunNum, true, hunToBeList);
                    huList = new List<int>();
                    hunToBeList = new List<int>();
                    getCharHuCardsList(huList, cardPool.getCharCards(), 0, targetN, hunNum, hunNum, true, hunToBeList);
                }
            }
        }


        private void addHuNumToString(int huNum, string hunToBeStr, Dictionary<string, StringBuilder> sbDic, Dictionary<string, Dictionary<int, bool>> numDic, string keyPre, int targetHunNum)
        {
            if (targetHunNum == 0 && !numDic[keyPre + 0].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 1
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 2
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum)
                && !numDic[keyPre + 2].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 3
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum)
                && !numDic[keyPre + 2].ContainsKey(huNum)
                && !numDic[keyPre + 3].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 4
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum)
                && !numDic[keyPre + 2].ContainsKey(huNum)
                && !numDic[keyPre + 3].ContainsKey(huNum)
                && !numDic[keyPre + 4].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 5
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum)
                && !numDic[keyPre + 2].ContainsKey(huNum)
                && !numDic[keyPre + 3].ContainsKey(huNum)
                && !numDic[keyPre + 5].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 6
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum)
                && !numDic[keyPre + 2].ContainsKey(huNum)
                && !numDic[keyPre + 3].ContainsKey(huNum)
                && !numDic[keyPre + 5].ContainsKey(huNum)
                && !numDic[keyPre + 6].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 7
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum)
                && !numDic[keyPre + 2].ContainsKey(huNum)
                && !numDic[keyPre + 3].ContainsKey(huNum)
                && !numDic[keyPre + 5].ContainsKey(huNum)
                && !numDic[keyPre + 6].ContainsKey(huNum)
                && !numDic[keyPre + 7].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
            else if (targetHunNum == 8
                && !numDic[keyPre + 0].ContainsKey(huNum)
                && !numDic[keyPre + 1].ContainsKey(huNum)
                && !numDic[keyPre + 2].ContainsKey(huNum)
                && !numDic[keyPre + 3].ContainsKey(huNum)
                && !numDic[keyPre + 5].ContainsKey(huNum)
                && !numDic[keyPre + 6].ContainsKey(huNum)
                && !numDic[keyPre + 7].ContainsKey(huNum)
                && !numDic[keyPre + 8].ContainsKey(huNum))
            {
                numDic[keyPre + targetHunNum].Add(huNum, true);
                sbDic[keyPre + targetHunNum].Append(huNum + "\r\n");
            }
        }

        /// <summary>
        /// 递归获取序牌胡牌牌型组合
        /// </summary>
        /// <param name="combineList">胡牌牌型组合列表</param>
        /// <param name="huList">单组胡牌牌型</param>
        /// <param name="orderCards">序牌牌池</param>
        /// <param name="currentN">当前轮数</param>
        /// <param name="targetN">递归总轮数</param>
        public void getOrderHuCardsList(List<int> huList, List<int> orderCards, int currentN, int targetN, int hunNum, int targetHunNum, bool isEye, List<int> hunToBe)
        {
            List<int> copyOrderCards;
            List<int> copyHuList;
            int copyCurrentN;
            int copyHunNum;
            List<int> copyHunToBe;
            if (currentN == targetN)
            {
                if (isEye)
                {
                    if (!isAddOrderEye)
                    {
                        for (int card = 1; card <= 9; card++)
                        {
                            if (hunNum >= 1 && targetHunNum >= 1)
                            {
                                List<int> eyeHuList = new List<int>();
                                List<int> eyeHunToBe = new List<int>();
                                eyeHuList.Add(card);
                                eyeHunToBe.Add(card);
                                int huNum = convertHuListToNum(eyeHuList, ListType.Order);
                                string hunToBeStr = convertHunToBeToStr(eyeHunToBe);
                                addHuNumToString(huNum, hunToBeStr, orderCombineSbWithEyeDic, orderCombineWithEyeNumDic, "order_combine_eye_", targetHunNum);
                            }
                            else
                            {
                                List<int> eyeHuList = new List<int>();
                                eyeHuList.Add(card);
                                eyeHuList.Add(card);
                                int huNum = convertHuListToNum(eyeHuList, ListType.Order);
                                addHuNumToString(huNum, "", orderCombineSbWithEyeDic, orderCombineWithEyeNumDic, "order_combine_eye_", targetHunNum);
                            }
                        }
                        isAddOrderEye = true;
                    }

                    for (int card = 1; card <= 9; card++)
                    {
                        if (getOneCardNumInList(orderCards, card) >= 2)
                        {
                            copyHuList = new List<int>(huList);
                            copyHuList.Add(card);
                            copyHuList.Add(card);
                            int huNum = convertHuListToNum(copyHuList, ListType.Order);
                            string hunToBeStr = convertHunToBeToStr(hunToBe);
                            addHuNumToString(huNum, hunToBeStr, orderCombineSbWithEyeDic, orderCombineWithEyeNumDic, "order_combine_eye_", targetHunNum);
                        }
                        if (hunNum >= 1 && targetHunNum >= 1 && getOneCardNumInList(orderCards, card) >= 1)
                        {
                            copyHuList = new List<int>(huList);
                            copyHuList.Add(card);
                            copyHunToBe = new List<int>(hunToBe);
                            copyHunToBe.Add(card);
                            int huNum = convertHuListToNum(copyHuList, ListType.Order);
                            string hunToBeStr = convertHunToBeToStr(copyHunToBe);
                            addHuNumToString(huNum, hunToBeStr, orderCombineSbWithEyeDic, orderCombineWithEyeNumDic, "order_combine_eye_", targetHunNum);
                        }
                    }
                }
                else
                {
                    int huNum = convertHuListToNum(huList, ListType.Order);
                    string hunToBeStr = convertHunToBeToStr(hunToBe);
                    addHuNumToString(huNum, hunToBeStr, orderCombineSbDic, orderCombineNumDic, "order_combine_", targetHunNum);
                }
                return;
            }

            for (int i = 1; i <= 9; i++)
            {
                if (getOneCardNumInList(orderCards, i) >= 3)
                {
                    copyOrderCards = new List<int>(orderCards);
                    copyCurrentN = currentN;
                    copyHuList = new List<int>(huList);
                    for (int n = 0; n < 3; n++)
                    {
                        copyOrderCards.Remove(i);
                        copyHuList.Add(i);
                    }
                    copyCurrentN++;
                    getOrderHuCardsList(copyHuList, copyOrderCards, copyCurrentN, targetN, hunNum, targetHunNum, isEye, hunToBe);
                }

                if (getOneCardNumInList(orderCards, i) >= 1
                    && getOneCardNumInList(orderCards, i + 1) >= 1
                    && getOneCardNumInList(orderCards, i + 2) >= 1)
                {
                    copyOrderCards = new List<int>(orderCards);
                    copyCurrentN = currentN;
                    copyHuList = new List<int>(huList);
                    copyHuList.Add(i);
                    copyHuList.Add(i + 1);
                    copyHuList.Add(i + 2);
                    copyOrderCards.Remove(i);
                    copyOrderCards.Remove(i + 1);
                    copyOrderCards.Remove(i + 2);
                    copyCurrentN++;
                    getOrderHuCardsList(copyHuList, copyOrderCards, copyCurrentN, targetN, hunNum, targetHunNum, isEye, hunToBe);
                }

                if (hunNum >= 1 && targetHunNum >= 1 && getOneCardNumInList(orderCards, i) >= 2)
                {
                    copyOrderCards = new List<int>(orderCards);
                    copyCurrentN = currentN;
                    copyHunNum = hunNum;
                    copyHuList = new List<int>(huList);
                    copyHuList.Add(i);
                    copyHuList.Add(i);
                    copyOrderCards.Remove(i);
                    copyOrderCards.Remove(i);
                    copyHunToBe = new List<int>(hunToBe);
                    copyHunToBe.Add(i);
                    copyHunNum--;
                    copyCurrentN++;
                    getOrderHuCardsList(copyHuList, copyOrderCards, copyCurrentN, targetN, copyHunNum, targetHunNum, isEye, copyHunToBe);
                }

                if (hunNum >= 2 && targetHunNum >= 2 && getOneCardNumInList(orderCards, i) >= 1)
                {
                    copyOrderCards = new List<int>(orderCards);
                    copyCurrentN = currentN;
                    copyHunNum = hunNum;
                    copyHuList = new List<int>(huList);
                    copyHuList.Add(i);
                    copyOrderCards.Remove(i);
                    copyHunToBe = new List<int>(hunToBe);
                    if (i == 1)
                    {
                        copyHunToBe.Add(i);
                        copyHunToBe.Add(i + 1);
                        copyHunToBe.Add(i + 2);
                    }
                    else if (i == 9)
                    {
                        copyHunToBe.Add(i);
                        copyHunToBe.Add(i - 1);
                        copyHunToBe.Add(i - 2);
                    }
                    else if (i == 8)
                    {
                        copyHunToBe.Add(i);
                        copyHunToBe.Add(i - 1);
                        copyHunToBe.Add(i - 2);
                        copyHunToBe.Add(i + 1);
                    }
                    else if (i == 2)
                    {
                        copyHunToBe.Add(i);
                        copyHunToBe.Add(i - 1);
                        copyHunToBe.Add(i + 1);
                        copyHunToBe.Add(i + 2);
                    }
                    else
                    {
                        copyHunToBe.Add(i);
                        copyHunToBe.Add(i - 1);
                        copyHunToBe.Add(i - 2);
                        copyHunToBe.Add(i + 1);
                        copyHunToBe.Add(i + 2);
                    }
                    copyHunNum -= 2;
                    copyCurrentN++;
                    getOrderHuCardsList(copyHuList, copyOrderCards, copyCurrentN, targetN, copyHunNum, targetHunNum, isEye, copyHunToBe);
                }


                if (hunNum >= 1 && targetHunNum >= 1
                    && getOneCardNumInList(orderCards, i) >= 1
                    && getOneCardNumInList(orderCards, i + 1) >= 1)
                {
                    copyOrderCards = new List<int>(orderCards);
                    copyCurrentN = currentN;
                    copyHunNum = hunNum; 
                    copyHuList = new List<int>(huList);
                    copyHuList.Add(i);
                    copyHuList.Add(i + 1);
                    copyOrderCards.Remove(i);
                    copyOrderCards.Remove(i + 1);
                    copyHunToBe = new List<int>(hunToBe);
                    if (i == 1)
                    {
                        copyHunToBe.Add(i + 2);
                    }
                    else if (i == 8)
                    {
                        copyHunToBe.Add(i - 1);
                    }
                    else if (i >= 2 && i <= 7)
                    {
                        copyHunToBe.Add(i - 1);
                        copyHunToBe.Add(i + 2);
                    }
                    copyHunNum--;
                    copyCurrentN++;
                    getOrderHuCardsList(copyHuList, copyOrderCards, copyCurrentN, targetN, copyHunNum, targetHunNum, isEye, copyHunToBe);
                }

                if (hunNum >= 1 && targetHunNum >= 1
                    && getOneCardNumInList(orderCards, i) >= 1
                    && getOneCardNumInList(orderCards, i + 2) >= 1)
                {
                    copyOrderCards = new List<int>(orderCards);
                    copyCurrentN = currentN;
                    copyHunNum = hunNum;
                    copyHuList = new List<int>(huList);
                    copyHuList.Add(i);
                    copyHuList.Add(i + 2);
                    copyOrderCards.Remove(i);
                    copyOrderCards.Remove(i + 2);
                    copyHunToBe = new List<int>(hunToBe);
                    copyHunToBe.Add(i + 1);
                    copyHunNum--;
                    copyCurrentN++;
                    getOrderHuCardsList(copyHuList, copyOrderCards, copyCurrentN, targetN, copyHunNum, targetHunNum, isEye, copyHunToBe);
                }
            }
        }

        /// <summary>
        /// 获取某张牌在列表中的数量
        /// </summary>
        /// <param name="orderCards">序牌牌池</param>
        /// <param name="card">目标牌</param>
        /// <returns>目标牌数量</returns>
        public int getOneCardNumInList(List<int> orderCards, int card)
        {
            int num = 0;
            for (int i = 0; i < orderCards.Count; i++)
            {
                if (orderCards[i] == card)
                    num++;
            }
            return num;
        }

        /// <summary>
        /// 递归获取字牌牌型组合
        /// </summary>
        /// <param name="combineList"></param>
        /// <param name="huList"></param>
        /// <param name="orderCards"></param>
        /// <param name="currentN"></param>
        /// <param name="targetN"></param>
        public void getCharHuCardsList(List<int> huList, List<int> charCards, int currentN, int targetN, int hunNum, int targetHunNum, bool isEye, List<int> hunToBe)
        {
            List<int> copyCharCards;
            List<int> copyHuList;
            int copyCurrentN;
            int copyHunNum;
            List<int> copyHunToBe;
            if (currentN == targetN)
            {
                if (isEye)
                {
                    if (!isAddCharEye)
                    {
                        for (int card = 1; card <= 7; card++)
                        {
                            if (hunNum >= 1 && targetHunNum >= 1)
                            {
                                List<int> eyeHuList = new List<int>();
                                eyeHuList.Add(card);
                                int huNum = convertHuListToNum(eyeHuList, ListType.Char);
                                List<int> eyeHunToBe = new List<int>();
                                eyeHunToBe.Add(card);
                                string hunToBeStr = convertHunToBeToStr(eyeHunToBe);
                                addHuNumToString(huNum, hunToBeStr, charCombineSbWithEyeDic, charCombineWithEyeNumDic, "char_combine_eye_", targetHunNum);
                            }
                            else
                            {
                                List<int> eyeHuList = new List<int>();
                                eyeHuList.Add(card);
                                eyeHuList.Add(card);
                                int huNum = convertHuListToNum(eyeHuList, ListType.Char);
                                addHuNumToString(huNum, "", charCombineSbWithEyeDic, charCombineWithEyeNumDic, "char_combine_eye_", targetHunNum);
                            }
                        }
                        isAddCharEye = true;
                    }

                    for (int card = 1; card <= 7; card++)
                    {
                        if (getOneCardNumInList(charCards, card) >= 2)
                        {
                            copyHuList = new List<int>(huList);
                            copyHuList.Add(card);
                            copyHuList.Add(card);
                            int huNum = convertHuListToNum(copyHuList, ListType.Char);
                            string hunToBeStr = convertHunToBeToStr(hunToBe);
                            addHuNumToString(huNum, hunToBeStr, charCombineSbWithEyeDic, charCombineWithEyeNumDic, "char_combine_eye_", targetHunNum);
                        }
                        if (hunNum >= 1 && targetHunNum >= 1 && getOneCardNumInList(charCards, card) >= 1)
                        {
                            copyHuList = new List<int>(huList);
                            copyHuList.Add(card);
                            int huNum = convertHuListToNum(copyHuList, ListType.Char);
                            copyHunToBe = new List<int>(hunToBe);
                            copyHunToBe.Add(card);
                            string hunToBeStr = convertHunToBeToStr(copyHunToBe);
                            addHuNumToString(huNum, hunToBeStr, charCombineSbWithEyeDic, charCombineWithEyeNumDic, "char_combine_eye_", targetHunNum);
                        }
                    }
                }
                else
                {
                    int huNum = convertHuListToNum(huList, ListType.Char);
                    string hunToBeStr = convertHunToBeToStr(hunToBe);
                    addHuNumToString(huNum, hunToBeStr, charCombineSbDic, charCombineNumDic, "char_combine_", targetHunNum);
                }
                return;
            }

            for (int i = 1; i <= 7; i++)
            {
                if (getOneCardNumInList(charCards, i) >= 3)
                {
                    copyCharCards = new List<int>(charCards);
                    copyCurrentN = currentN;
                    copyHuList = new List<int>(huList);
                    for (int n = 0; n < 3; n++)
                    {
                        copyCharCards.Remove(i);
                        copyHuList.Add(i);
                    }
                    copyCurrentN++;
                    getCharHuCardsList(copyHuList, copyCharCards, copyCurrentN, targetN, hunNum, targetHunNum, isEye, hunToBe);
                }

                if (hunNum >= 1 && targetHunNum >= 1 && getOneCardNumInList(charCards, i) >= 2)
                {
                    copyCharCards = new List<int>(charCards);
                    copyCurrentN = currentN;
                    copyHuList = new List<int>(huList);
                    copyHunNum = hunNum;
                    copyCharCards.Remove(i);
                    copyCharCards.Remove(i);
                    copyHuList.Add(i);
                    copyHuList.Add(i);
                    copyCurrentN++;
                    copyHunNum--;
                    copyHunToBe = new List<int>(hunToBe);
                    copyHunToBe.Add(i);
                    getCharHuCardsList(copyHuList, copyCharCards, copyCurrentN, targetN, copyHunNum, targetHunNum, isEye, copyHunToBe);
                }

                if (hunNum >= 2 && targetHunNum >= 2 && getOneCardNumInList(charCards, i) >= 1)
                {
                    copyCharCards = new List<int>(charCards);
                    copyCurrentN = currentN;
                    copyHuList = new List<int>(huList);
                    copyHunNum = hunNum;
                    copyCharCards.Remove(i);
                    copyHuList.Add(i);
                    copyCurrentN++;
                    copyHunNum -= 2;
                    copyHunToBe = new List<int>(hunToBe);
                    copyHunToBe.Add(i);
                    getCharHuCardsList(copyHuList, copyCharCards, copyCurrentN, targetN, copyHunNum, targetHunNum, isEye, copyHunToBe);
                }
            }
        }

        public void writeAllCombineListToFile()
        {
            Console.WriteLine("开始打印文件...");
            foreach (KeyValuePair<string, StringBuilder> kv in orderCombineSbDic)
            {
                inputNumStrToFile(kv.Value.ToString(), kv.Key);
            }
            foreach (KeyValuePair<string, StringBuilder> kv in charCombineSbDic)
            {
                inputNumStrToFile(kv.Value.ToString(), kv.Key);
            }
            foreach (KeyValuePair<string, StringBuilder> kv in orderCombineSbWithEyeDic)
            {
                inputNumStrToFile(kv.Value.ToString(), kv.Key);
            }
            foreach (KeyValuePair<string, StringBuilder> kv in charCombineSbWithEyeDic)
            {
                inputNumStrToFile(kv.Value.ToString(), kv.Key);
            }
            Console.WriteLine("打印完毕...");
        }

        private string convertHunToBeToStr(List<int> hunTobe)
        {
            string str = "";
            for (int i = 0; i < hunTobe.Count; i++)
            {
                if (i != hunTobe.Count - 1)
                    str += hunTobe[i] + ":";
                else
                    str += hunTobe[i];
            }
            return str;
        }

        private int convertHuListToNum(List<int> huList, ListType type)
        {
            List<int> countArr = convertHuListToCountArr(huList);
            int num = convertCountArrToNum(countArr, type);
            return num;
        }

        private List<int> convertHuListToCountArr(List<int> huList)
        {
            List<int> countArr = new List<int>(9);
            for (int i = 0; i < 9; i++)
            {
                countArr.Add(0);
            }
            for (int index = 0; index < huList.Count; index++)
            {
                switch (huList[index])
                {
                    case 1:
                        countArr[0]++;
                        break;
                    case 2:
                        countArr[1]++;
                        break;
                    case 3:
                        countArr[2]++;
                        break;
                    case 4:
                        countArr[3]++;
                        break;
                    case 5:
                        countArr[4]++;
                        break;
                    case 6:
                        countArr[5]++;
                        break;
                    case 7:
                        countArr[6]++;
                        break;
                    case 8:
                        countArr[7]++;
                        break;
                    case 9:
                        countArr[8]++;
                        break;
                }
            }
            return countArr;
        }

        private int convertCountArrToNum(List<int> countArr, ListType type)
        {
            int max = type == ListType.Order ? 9 : 7;
            int num = 0;
            for (int n = 0; n < max; n++)
            {
                if (type == ListType.Order)
                    num += (int)(countArr[n] * Math.Pow((double)10, (double)(8 - n)));
                else if (type == ListType.Char)
                    num += (int)(countArr[n] * Math.Pow((double)10, (double)(6 - n)));
            }
            return num;
        }


        /// <summary>
        /// 胡牌写入文件
        /// </summary>
        private void inputNumStrToFile(string numStr, string fileName)
        {
            string outputFilePath = outputPath + "\\" + fileName + ".tbl";
            deleteFileIfExist(outputFilePath);
            using (FileStream fsWrite = new FileStream(outputFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter sw = new StreamWriter(fsWrite);
                sw.Write(numStr);
                sw.Flush();
                sw.Close();
                fsWrite.Close();
            }
        }

        /// <summary>
        /// 如果输出文件已经存在，先删除
        /// </summary>
        private void deleteFileIfExist(string path)
        {
            if (File.Exists(path) && File.GetAttributes(path) != FileAttributes.Directory)
            {
                File.Delete(path);
            }
        }
    }
}
