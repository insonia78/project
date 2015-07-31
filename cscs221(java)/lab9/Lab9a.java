
/**
 * Write a description of class Lab9a here.
 * 
 * @author (your name) 
 * @version (a version number or a date)
 */
public class Lab9a {
        public static int calls;
            public static void main(String[] args) {
                int n, k;

                System.out.println("Pascal Triangle");
                for (int z = 0 ; z <=10; z++){
                    if(z == 0){
                    System.out.printf("     k=%1d",z);
                    }
                    else{
                        System.out.printf("  k="+z);
                    }
                }
                System.out.println("");
                for (n = 0; n <= 10; ++n) {
                    System.out.print("n="+n);
                    for (k = 0; k <= n; ++k) {
                        calls = 0; 
                        binCoef(n,k);
                        System.out.printf("%5d", calls);
                    }
                    System.out.printf("%n");
                }
            }

            public static int binCoef(int n, int k) {
                calls++;
                // Use the recursive definition above to
                // compute and return C(n,k).
                if (k == n){
                    return 1;
                }
                else if( k == 0){
                   return 1; 
                }
                else{
                   int var1 = binCoef(n -1,k-1);
                   int var2 = binCoef(n-1,k);
                
                return var1+var2;
            }
            }
        }
