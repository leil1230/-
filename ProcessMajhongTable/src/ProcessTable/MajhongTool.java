package ProcessTable;

import java.util.ArrayList;
import java.util.List;

public class MajhongTool {
	
	public List<Integer> getCards(int cNum, CardType type) {
		int cardNum = cNum;
		List<Integer> cards = new ArrayList<>();
		int max = type == CardType.Order ? 8 : 6;
		int card = 1;
		for (int i = max; i >= 0; i--) {
			int multiNum = (int)Math.pow((double)10, (double)i);
			int count = cardNum / multiNum - (cardNum / (multiNum * 10)) * 10;
			for (int index = 0; index < count; index++) {
				cards.add(card);
			}
			card++;
		}
		return cards;
	}

	public void getTingList(List<List<Integer>> allTingList, List<Integer> cards, int laiziNum, List<Integer> laiziToBe, boolean isCheckEye, boolean checkEye, CardType type) {
		List<Integer> copyCards;
		List<Integer> copyLaiziToBe;
		int copyLaiziNum;
		
		if (cards.size() == 0) {
			allTingList.add(laiziToBe);
			return;
		}
		
		int card = cards.get(0);
		
		if (checkEye) {
			// 成对子
			if (!isCheckEye && cards.size() >= 2 && card == cards.get(1)) {
				copyCards = new ArrayList<>(cards);
				copyCards.remove(0);
				copyCards.remove(0);
				getTingList(allTingList, copyCards, laiziNum, laiziToBe, true, checkEye, type);
			}
			
			// 一个癞子成对子
			if (!isCheckEye && cards.size() >= 1 && laiziNum >= 1) {
				copyCards = new ArrayList<>(cards);
				copyLaiziToBe = new ArrayList<>(laiziToBe);
				copyLaiziNum = laiziNum;
				copyCards.remove(0);
				copyLaiziToBe.add(card);
				copyLaiziNum--;
				getTingList(allTingList, copyCards, copyLaiziNum, copyLaiziToBe, true, checkEye, type);
			}
			
		}
		
		// 成刻子
		if (cards.size() >= 3 && card == cards.get(1) && card == cards.get(2)) {
			copyCards = new ArrayList<>(cards);
			copyCards.remove(0);
			copyCards.remove(0);
			copyCards.remove(0);
			getTingList(allTingList, copyCards, laiziNum, laiziToBe, isCheckEye, checkEye, type);
		}
		
		// 一个癞子成刻子
		if (cards.size() >= 2 && card == cards.get(1) && laiziNum >= 1) {
			copyCards = new ArrayList<>(cards);
			copyLaiziToBe = new ArrayList<>(laiziToBe);
			copyLaiziNum = laiziNum;
			copyCards.remove(0);
			copyCards.remove(0);
			copyLaiziToBe.add(card);
			copyLaiziNum--;
			getTingList(allTingList, copyCards, copyLaiziNum, copyLaiziToBe, isCheckEye, checkEye, type);
		}
		
		// 两个癞子成刻子
		if (cards.size() >= 1 && laiziNum >= 2) {
			copyCards = new ArrayList<>(cards);
			copyLaiziToBe = new ArrayList<>(laiziToBe);
			copyLaiziNum = laiziNum;
			copyCards.remove(0);
			copyLaiziToBe.add(card);
			copyLaiziNum -= 2;
			getTingList(allTingList, copyCards, copyLaiziNum, copyLaiziToBe, isCheckEye, checkEye, type);
		}
		
		if (type == CardType.Order) {
			// 成顺子
			if (cards.size() >= 3 && cards.contains((Object)(card + 1)) && cards.contains((Object)(card + 2))) {
				copyCards = new ArrayList<>(cards);
				copyCards.remove(0);
				copyCards.remove((Object)(card + 1));
				copyCards.remove((Object)(card + 2));
				getTingList(allTingList, copyCards, laiziNum, laiziToBe, isCheckEye, checkEye, type);
			}
			
			// 一个癞子成顺子(两张连续牌)
			if (cards.size() >= 2 && cards.contains((Object)(card + 1)) && laiziNum >= 1) {
				copyCards = new ArrayList<>(cards);
				copyLaiziToBe = new ArrayList<>(laiziToBe);
				copyLaiziNum = laiziNum;
				copyCards.remove(0);
				copyCards.remove((Object)(card + 1));
				copyLaiziNum--;
				if (card == 1)
					copyLaiziToBe.add(card + 2);
				else if (card == 8)
					copyLaiziToBe.add(card - 1);
				else
				{
					copyLaiziToBe.add(card - 1);
					copyLaiziToBe.add(card + 2);
				}
				getTingList(allTingList, copyCards, copyLaiziNum, copyLaiziToBe, isCheckEye, checkEye, type);
			}
			
			// 一个癞子成顺子(两张间隔)
			if (cards.size() >= 2 && cards.contains((Object)(card + 2)) && laiziNum >= 1) {
				copyCards = new ArrayList<>(cards);
				copyLaiziToBe = new ArrayList<>(laiziToBe);
				copyLaiziNum = laiziNum;
				copyCards.remove(0);
				copyCards.remove((Object)(card + 2));
				copyLaiziToBe.add(card + 1);
				copyLaiziNum--;
				getTingList(allTingList, copyCards, copyLaiziNum, copyLaiziToBe, isCheckEye, checkEye, type);
			}
			
			// 两个癞子成顺子
			if (cards.size() >= 1 && laiziNum >= 2) {
				copyCards = new ArrayList<>(cards);
				copyLaiziToBe = new ArrayList<>(laiziToBe);
				copyLaiziNum = laiziNum;
				copyCards.remove(0);
				copyLaiziNum -= 2;
				if (card == 1) {
					copyLaiziToBe.add(card + 1);
					copyLaiziToBe.add(card + 2);
				} else if (card == 9) {
					copyLaiziToBe.add(card - 1);
					copyLaiziToBe.add(card - 2);
				} else if (card == 2) {
					copyLaiziToBe.add(card - 1);
					copyLaiziToBe.add(card + 1);
					copyLaiziToBe.add(card + 2);
				} else if (card == 8) {
					copyLaiziToBe.add(card + 1);
					copyLaiziToBe.add(card - 1);
					copyLaiziToBe.add(card - 2);
				} else {
					copyLaiziToBe.add(card - 2);
					copyLaiziToBe.add(card - 1);
					copyLaiziToBe.add(card + 1);
					copyLaiziToBe.add(card + 2);
				}
				getTingList(allTingList, copyCards, copyLaiziNum, copyLaiziToBe, isCheckEye, checkEye, type);
			}
		}
		
		
	}
}
