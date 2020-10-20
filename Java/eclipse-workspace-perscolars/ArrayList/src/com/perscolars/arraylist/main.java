package com.perscolars.arraylist;

import java.util.*;
import java.util.Arrays;

public class main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		List<Integer> list1 = Arrays.asList(3,4,6,7,9,12,15,17,23);
		List<Integer> list2 = Arrays.asList(3,5,7,9,10,13,15,18,23);
        ArrayList<Integer> contains = new ArrayList<Integer>(); 
		ArrayList<Integer> sorts = new ArrayList<Integer>(10);
        for(int i = 0; i < sorts.size();i++)
        {
        	sorts.add((int)Math.random());
        }
        Collections.sort(sorts, new MyInteger());
         System.out.println(sorts.toArray().length);       
        for(Integer i : sorts)
        {
        	System.out.println(i);
        }
        
        for(Integer i : list2)
		{
		      if(list1.contains(i))
		      {
		         contains.add(i);
		         System.out.println(i);
		      }
		}
		
		
	}
	

}
class MyInteger implements Comparator<Integer>{
		
		@Override
		public int compare(Integer x, Integer y)
		{
			if((int) x < (int) y)
				return 1;
			else
				return -1;
		}
	}