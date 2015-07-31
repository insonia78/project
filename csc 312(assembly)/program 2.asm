#
# program 2 by thomas zangari csci 312
#
                 .data
 word:           .asciiz        "\n"                 
                 
                 .text
                 
                 li            $t0, 0    # First value of the  loop 
                 li            $t1, 3    # End value of the loop
                 li            $t2, 1    # first value for the fibonacci sequence 
                 li            $t3, 1    # second value of  the fibonacci sequence 
                 li            $t4, 0    # second sum counter
                 
                
 
  # Printing the first two values of the fibonacci sequence 
 
                 li            $v0, 1         #
                 move          $a0, $t2       # outputing the register $t2
                 syscall
                 
                 li            $v0,4          #
                 la            $a0, word      # creating a space 
                 syscall
                 
                 li            $v0, 1         #
                 move          $a0, $t3       #   outputing  the register $t3  
                 syscall
                 
                 li            $v0,4          # 
                 la            $a0, word      #   crating a space 
                 syscall
 
 # looping the sum of $t2, $t2 + $t3 and the sum of $t4, $t2 + $t3
 
 top:            bgt           $t0, $t1, next       #loop
                 add           $t2, $t2, $t3        # $t2 <- $t2 + $t3
                 
                 li            $v0, 1               # outputing the register $t2
                 move          $a0, $t2             #
                 syscall
                
                 li            $v0,4                # 
                 la            $a0, word            # creating a space
                 syscall                
                 
                 add           $t4, $t2, $t3        # $t4 <- $t2 + $t3
                 
                 li            $v0,1                #
                 move          $a0, $t4             # outputing the register $t4
                 syscall
                 
                 li            $v0,4                # 
                 la            $a0, word            # creating a space
                 syscall
                 
                 move          $t3, $t4             # $t3 <- $t4   
                 
                 addi           $t0, $t0, 1          # adding 1 to count 
                 
                 j              top                              
                 
                  
                 
# Returning to operating system
next:           li             $v0, 10
                syscall     
                
1
1
2
3
5
8
13
21
34
55

-- program is finished running  --
