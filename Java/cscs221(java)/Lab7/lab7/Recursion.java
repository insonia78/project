public class Recursion{
public static void main(String[] args){

System.out.println("the final value is: " + mystery(5));
}

public static int mystery(int n)
{
  System.out.println("method " + n);
  if (n == 0){
     System.out.print("return 1");
    return 1;
}
  else{
    System.out.print("return: "+3 * mystery (n - 1));
    System.out.println(": " + n + " numeber " + n +"-1");
    return 3 * mystery (n - 1);
}
}
}


