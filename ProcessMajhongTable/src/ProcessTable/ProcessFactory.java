package ProcessTable;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class ProcessFactory {

	MajhongTool tool = new MajhongTool();
	
	private StringBuilder processSb = new StringBuilder();
	
	private String fileName;
	
	private CardType type;
	
	private int laiziNum;
	
	private boolean isCheckEye;
	
	public ProcessFactory(String fileName, CardType type, int laiziNum, boolean isCheckEye) {
		this.fileName = fileName;
		this.type = type;
		this.laiziNum = laiziNum;
		this.isCheckEye = isCheckEye;
	}
	
	public void ProcessFile() {
		loadFile();
		generateInfoFile();
	}
	
	private void loadFile() {
		try {
			String path = Thread.currentThread().getContextClassLoader().getResource("").getPath().replace("%20", " ") + "ProcessBefore" + File.separator + fileName;
			BufferedReader br = new BufferedReader(new FileReader(path));
			String str = null;
			while ((str = br.readLine()) != null) {
				processOneLine(str);
			}
			br.close();
		} catch (IOException e) {
			System.out.println("∂¡»°id≈‰÷√Œƒº˛¥ÌŒÛ:" + e.getMessage());
		}
	}
	
	private void processOneLine(String info) {
		int cardNum = Integer.parseInt(info);
		List<Integer> cards = tool.getCards(cardNum, type);
		List<List<Integer>> allTingList = new ArrayList<>();
		List<Integer> laiziToBe = new ArrayList<>();
		tool.getTingList(allTingList, cards, laiziNum, laiziToBe, false, isCheckEye, type);
		String tingStr = getTingStr(allTingList);
		processSb.append(info + "=" + tingStr + "\r\n"); 
	}
	
	
	private String getTingStr(List<List<Integer>> allTingList) {
		List<Integer> tingList = new ArrayList<>();
		String str = "";
		for (List<Integer> list : allTingList) {
			for (int card : list) {
				if (!tingList.contains((Object)(card))) {
					tingList.add(card);
				}
			}
		}
		
		for (int i = 0; i < tingList.size(); i++) {
			if (i == tingList.size() - 1)
				str += tingList.get(i);
			else 
				str += tingList.get(i) + ":";
		}
		
		return str;
	}	
	
	private void generateInfoFile() {
		try {
			String outPath = Thread.currentThread().getContextClassLoader().getResource("").getPath().replace("%20", " ") + "ProcessAfter" + File.separator + fileName;
			FileOutputStream out = new FileOutputStream(new File(outPath));
			out.write(processSb.toString().getBytes());
			out.close();
		} catch (IOException e) {
			System.out.println("–¥»Î≈‰÷√Œƒº˛¥ÌŒÛ" + e.getMessage());
		} 
	}
	
	
	
}
