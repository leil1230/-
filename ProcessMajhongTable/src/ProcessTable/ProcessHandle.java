package ProcessTable;

public class ProcessHandle {

	public static void main(String[] args) {
		for (int i = 1; i <= 8; i++) {
			ProcessFactory factory1 = new ProcessFactory("char_combine_" + i + ".tbl", CardType.Char, i, false);
			factory1.ProcessFile();
			System.out.println("char_combine_" + i + ".tbl处理完成！！！");
			ProcessFactory factory2 = new ProcessFactory("char_combine_eye_" + i + ".tbl", CardType.Char, i, true);
			factory2.ProcessFile();
			System.out.println("char_combine_eye_" + i + ".tbl处理完成！！！");
			ProcessFactory factory3 = new ProcessFactory("order_combine_" + i + ".tbl", CardType.Order, i, false);
			factory3.ProcessFile();
			System.out.println("order_combine_" + i + ".tbl处理完成！！！");
			ProcessFactory factory4 = new ProcessFactory("order_combine_eye_" + i + ".tbl", CardType.Order, i, true);
			factory4.ProcessFile();
			System.out.println("order_combine_eye_" + i + ".tbl处理完成！！！");
		}
		System.out.println("处理完成！！！");
	}
}
