package thursday.collections;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.EnumMap;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Scanner;
import java.util.TreeMap;

public class Main {

	public static void main(String[] args) {

		// slide 7

		Wrapper<Integer> iWrapper = new Wrapper<Integer>(25);
		Wrapper<Double> dWrapper = new Wrapper<Double>(25.0);
		Wrapper<Scanner> scanWrapper = new Wrapper<Scanner>(new Scanner(System.in));
		Wrapper<Wrapper<Long>> lwWrapper = new Wrapper<Wrapper<Long>>(new Wrapper<Long>(100L));

		System.out.println(iWrapper.getValue());
		System.out.println(dWrapper.getValue());
		System.out.println(scanWrapper.getValue());
		System.out.println(lwWrapper.getValue().getValue());
		System.out.println("********************");

		// slide 14

		DynamicArray<Integer> x = new DynamicArray<Integer>(5);
		System.out.println("Collection Size: " + x.size());
		x.add(22);
		System.out.println(x.getAt(0));
		x.setAt(0, 33);
		System.out.println(x.getAt(0));
		x.add(44);
		x.add(55);
		x.add(66);
		x.add(77);
		x.add(88);

		for (int i = 0; i < x.size(); i++) {
			System.out.println(x.getAt(i));
		}
		System.out.println("Collection Size: " + x.size());
		System.out.println("********************");
		
		//slide 18
		
		ArrayList<Integer> iList = new ArrayList<Integer>(100);
		System.out.println(iList.size());
		for(int i = 0; i<100;++i) 
			iList.add(i);
			
			System.out.println("Size: "+iList.size());
			System.out.println("Index of 50: "+iList.indexOf(50));
			System.out.println("Contains 80: "+iList.contains(80));
			System.out.println("Contians 128: "+iList.contains(128));
			boolean success = iList.remove((Integer)80);
			System.out.println("Remove value 80: "+success);
			success  = iList.remove((Integer)120);
			System.out.println("Remove value 120: "+success);
			Integer removed = iList.remove(80);
			System.out.println("Remove index 80: "+removed);
			for(Integer i: iList)
				System.out.print(i +" ");
			System.out.println();
			System.out.println("********************");
			// slide 19
			
			int sum=0;
			for(Integer i : iList)
				sum+=i;
			System.out.println(sum);
			
			int max = Integer.MIN_VALUE;
			for(int i=0 ;i< iList.size();i++){
				if(max<iList.get(i)) 
					max=iList.get(i);
			}
			System.out.println(max);
			System.out.println("********************");

			// slide 22
			List<Integer> a = Arrays.asList(3,4,6,7,9,12,15,17,23); 
			List<Integer> b= Arrays.asList(3,5,7,9,10,13,15,18,23);
			List<Integer> c = new ArrayList<Integer>();
			
			int iA = 0, iB = 0;
			while(iA<a.size() && iB <b.size()) {
				Integer vA = a.get(iA), vB = b.get(iB);
				if(vA < vB) iA++; else
					if(vB<vA) iB++; else {
						c.add(vA);
						iA++;iB++;
					}
			}
			System.out.println(c);
			System.out.println("********************");
			List<Integer> d = new ArrayList<Integer>();

			// slide 23
			for(Integer i: a) {
				if(Collections.binarySearch(b, i) >= 0) d.add(i);
			}
			System.out.println(d);
			System.out.println("********************");
			//slide 26
			List<Integer> xArrayList = new ArrayList<Integer>();
			List<Integer> xLinkedList = new LinkedList<Integer>();
			for(int i = 0;i<10;i++) {
				xArrayList.add(i);
				xLinkedList.add(i);
			}
			xArrayList.remove(5);
			xArrayList.remove(7);
			xLinkedList.remove(5);
			xLinkedList.remove(7);
			System.out.println("xArrayList");
			for(Integer i: xArrayList)
				System.out.print(i+" ");
			System.out.println();
			System.out.println("xLinkedList");
			for(Integer i: xLinkedList)
				System.out.print(i+" ");
			System.out.println();
			System.out.println("********************");
			EnumMap<DayOfWeek, Integer> map = new EnumMap<DayOfWeek, Integer>(DayOfWeek.class);
			map.put(DayOfWeek.Sunday, 25);
			map.put(DayOfWeek.Monday, 25);
			map.put(DayOfWeek.Tuesday, 25);
	
			System.out.println(map);
			System.out.println("********************");
			HashMap<String, Integer> myHashMap = new HashMap<String, Integer> ();
			for(int i=0;i<DayOfWeek.values().length;i++) {
				myHashMap.put(DayOfWeek.values()[i].toString(), i+1);
			}
			System.out.println("myHashMap: ");
			myHashMap.forEach((k,v)->System.out.print(k+ "=" +v+" "));
			
			//System.out.println(myHashMap);
			TreeMap<String, Integer> sorted = new TreeMap<String, Integer>();
			sorted.putAll(myHashMap);
			System.out.println();
			System.out.println("sorted: ");
			System.out.println(sorted); // sorted by KEY
			System.out.println("********************");
			//slide 51
			



			

				
			
	}// main

}//class
