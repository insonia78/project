# Program 1 for csci 312 author: thomas zangari
                   .data
# Defining the variable 
A:                 .word   23
B:                 .word   7
CompA:             .word   0       # two's complenment of variable A
Sum:               .word   0       # Variable for the sum of A and B
ALessB:            .word   0       # Subtracting A and B
BLessA:            .word   0       # Subtracting B and A
Space:             .asciiz "       "
                  
                  .text 
                           
# Adding the integers A  B
                  lw      $t0,A            # $t0 <- A 
                  lw      $t1,B            # $t1 <- B
                  add     $t2, $t0, $t1    # $t2 <- $t0 + $t1    
                  sw      $t2, Sum
# Subtracting A and B
                  sub     $t3, $t0, $t1    # $t3 <- $t0 - $t1
                  sw      $t3, ALessB      
# Subtracting B and A
                  sub     $t4, $t1, $t0    # $t4  <- $t1 - $t0
                  sw      $t4, BLessA
# Assignin the two's compliments of A
                                
                  neg     $t5, $t0        # $t5   <- $t0
                  sw      $t5, CompA
                  
                 
# Print the output line 
                 li       $v0, 1      # $v0 <- 1
                 lw       $a0, A      # $a0 <- A 
                 syscall
                 li       $v0, 4
                 la       $a0, Space
                 syscall
                 li       $v0, 1 
                 lw       $a0, B
                 syscall
                 li       $v0, 4
                 la       $a0, Space
                 syscall
                 li       $v0, 1
                 lw       $a0, CompA
                 syscall
                 li       $v0, 4
                 la       $a0, Space
                 syscall
                 li       $v0, 1
                 lw       $a0, Sum
                 syscall
                 li       $v0, 4
                 la       $a0, Space
                 syscall  
                 li       $v0, 1
                 lw       $a0, ALessB
                 syscall
                 li       $v0, 4
                 la       $a0, Space
                 syscall
                 li       $v0, 1
                 lw       $a0, BLessA
                 syscall
                 li      $v0, 10
                 syscall
                 
                 23       7       -23       30       16       -16
-- program is finished running  --


                 
                 
                  
                                   
                                                                       
                                                                       