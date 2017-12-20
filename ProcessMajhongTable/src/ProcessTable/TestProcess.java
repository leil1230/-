package ProcessTable;

import java.util.ArrayList;
import java.util.List;

public class TestProcess {

	public static void main(String[] args) {
		MajhongTool tool = new MajhongTool();
		List<Integer> cards = tool.getCards(3421000, CardType.Char);
		List<List<Integer>> allTingList = new ArrayList<>();
		List<Integer> laiziToBe = new ArrayList<>();
		tool.getTingList(allTingList, cards, 4, laiziToBe, false, true, CardType.Char);
		int a= 0;
		int b = a;
	}
}
