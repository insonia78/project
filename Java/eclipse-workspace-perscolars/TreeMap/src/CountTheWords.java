import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.*;

public class CountTheWords {
  private BufferedReader bufferedReader = null;

  public static void main(String[] args) {
    // TODO Auto-generated method stub
    String location = "D:\\projects\\PerScholas\\exercises\\JAVA\\9.8.20\\TreeMap\\MobyDick.txt";
    File file = new File(location);
    TreeMap<String, Integer> words = new TreeMap<String, Integer>();
    TreeMap<String, Integer> sortedWords = new TreeMap<String, Integer>();
    CountTheWords count = new CountTheWords();
    words = count.bufferedReaderTreeMap(location);
    sortedWords = count.sortByValues(words);

    System.out.println(count.bufferedReaderTreeMap(location));
    count.writeToFile(sortedWords);
  }

  public void writeToFile(TreeMap<String, Integer> map) {
    try {
      FileWriter myWriter = new FileWriter("D:\\projects\\PerScholas\\exercises\\JAVA\\9.8.20\\TreeMap\\demo.txt");
      myWriter.write(map.toString());

      System.out.println("test " + map);
      myWriter.close();
      System.out.println("Successfully wrote to the file.");
    } catch (IOException e) {
      System.out.println("An error occurred.");
      e.printStackTrace();
    }

  }

  private TreeMap<String, Integer> bufferedReaderTreeMap(String fileName) {
    TreeMap<String, Integer> map = new TreeMap<String, Integer>();
    try {
      BufferedReader bufferedReader = new BufferedReader(new FileReader(new File(fileName)));
      String available;
      while ((available = bufferedReader.readLine()) != null) {
        String[] lineArray = available.split("\\s+");
        for (int i = 0; i < lineArray.length; i++) {
          if (map.containsKey(lineArray[i])) {
            Integer value = map.get(lineArray[i]);
            value++;
            map.put(lineArray[i], value);
          } else {
            map.put(lineArray[i], 1);
          }
        }
      }
    } catch (FileNotFoundException e) {
      e.printStackTrace();
    } catch (IOException e) {
      e.printStackTrace();
    } finally {
      if (bufferedReader != null) {
        try {
          bufferedReader.close();
        } catch (IOException e) {
          e.printStackTrace();
        }
      }
    }
    return map;
  }

  private HashMap<String, Integer> bufferedReaderToArrayList(String fileName) {
    HashMap<String, Integer> map = new HashMap<String, Integer>();
    try {
      BufferedReader bufferedReader = new BufferedReader(new FileReader(new File(fileName)));
      String available;
      while ((available = bufferedReader.readLine()) != null) {
        String[] lineArray = available.split("\\s+");
        for (int i = 0; i < lineArray.length; i++) {
          if (map.containsKey(lineArray[i])) {
            Integer value = map.get(lineArray[i]);
            value++;
            map.put(lineArray[i], value);
          } else {
            map.put(lineArray[i], 1);
          }
        }
      }
    } catch (FileNotFoundException e) {
      e.printStackTrace();
    } catch (IOException e) {
      e.printStackTrace();
    } finally {
      if (bufferedReader != null) {
        try {
          bufferedReader.close();
        } catch (IOException e) {
          e.printStackTrace();
        }
      }
    }
    return map;
  }

  public TreeMap<String, Integer> sortByValues(TreeMap<String, Integer> unsortedMap) {

    List<Map.Entry<String, Integer>> list
      = new LinkedList<>(unsortedMap.entrySet());
//calls the sort on list by calling a lambda expression that calls the compareTo method
    Collections.sort(list, (Map.Entry<String, Integer> FirstElement,
                            Map.Entry<String, Integer> secondElement)
      -> (secondElement.getValue()).compareTo(FirstElement.getValue()));
//creates the return TreeMap, takes list items, and puts them in sortedMap
    TreeMap<String, Integer> sortedMap = new TreeMap<>();
    for (Map.Entry<String, Integer> listElement : list) {
      sortedMap.put(listElement.getKey(), listElement.getValue());
    }
//frequency.clear();//clear unused class TreeMap
    return sortedMap;
  }
}


