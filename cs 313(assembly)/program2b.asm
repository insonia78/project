
#
# prgram 2 created by Thomas Zangari csci 313
#
# The program calculates the min , max and sum of an array .It uses a random generator to fill the array each time 
#

                        .data
Prompt:                 .asciiz "Enter the numbers that you want to store in the array: "
Continue:               .asciiz  "\nDo you want to continue y for yes n for no "   
PromptingMax:           .asciiz  "The Maximum Value is:\n"
PromptingMin:           .asciiz  "The Minimum Valus is:\n"
PromptingSum:           .asciiz  "\nThe Sum is:\n"
PromptingSort:          .asciiz  "The sorted array:"
PromptingArrayFull:     .asciiz  "The array is full\n"
NewLine:                .asciiz  "\n"    
Space:                  .asciiz  "  "
answer:                 .word    'y'
flag:                   .word    1                         # used as a boolean
x:                      .word    1                         # variable to perform the random number
array:                  .word    0:5                       # declaring the capacity of the array to 5 integers
bit:                    .word    0                         # holds the size of the data
SortIndex:              .word    1                         # holds the index to perform the sorting 
ValueForLoop:           .word    5                         # holds the value for how many iteration the loop performs
Buffer:                 .space   12
                        .globl   main
                        
                        .text
#loading the variables to the registers                         
              
              main:
                        lw             $t5,answer          # Loading flag to continue the loop 
                        lw             $t4,bit             # bit -> $t4 holds the size of the data           
                        lw             $s0,SortIndex       # SortIndex -> $s0 holds the index to perform the sort
                        lw             $s5,flag            # flag -> $s5 used as a boolean to print the array when is not sorted 
                                                           # and when is sorted
                        lw             $s4,x               # x -> $s4 holds the value to perform random numbers 
                        lw             $t7,ValueForLoop    # ValueForLoop -> $t6 
                   while:       
                        # creates the random number       
                        mul           $s4,$s4,65          # $s4 * 65 -> $s4
                        add           $s4,$s4,27          # $s4 + 27 -> $s4 
                        rem           $s4,$s4,256         # %s4 mod(256) -> $s4
                        
                                              
                        # storing the random number in the array                                                                   
                        la            $t0, array          # load base address of array into register $t0 
                        move          $t1,$s4             # $s4 -> $t1
                        mul           $t2, $t4, 4         # creating the offset -> $t2
                        add           $t3, $t0, $t2       # offset + base address -> $t3
                        sw            $t1, ($t3)          # stroing the $t1 -> ($t3) 
                        add           $t4,$t4,1           # increasing the index $t4 + 1 -> $t4
                                        
                        bne           $t4,$t7   while      #  $t4 != 5 -> while
                        # setting the offset and the index to zero 
                        li            $t4,0             #  0 -> $t4 index
                        li            $t2,0             # 0 -> $t2 offset
                        j             Print             # printing the unsorted array
                        
                  
SortingArray:
                         
                        mul           $t2, $t4, 4         # creating the offset -> $t2
                        add           $t3, $t0, $t2       # offset + base address -> $t3
                        lw            $t1, ($t3)          # stroing the $t1 -> ($t3) 
                        add           $t4,$t4,1         
                        
                        #setting the index to 1 for comparison
                        move          $s0,$t4             # $t4 -> $s0            
               loop:         
                        mul           $s2, $s0, 4         # creating the offset -> $t2
                        add           $s3, $t0, $s2       # offset + base address -> $t3
                        lw            $s1, ($s3)
                        bgt           $t1,$s1 swamp       # $t1 > $s1 -> swamp   
               
               backToSort:        
                        add           $s0,$s0,1           # $s0 + 1 -> $s0 increasing the index       
                        blt           $s0,$t7 loop        # $0 < 5  
                        
                        blt           $t4,$t7 SortingArray  # $t4 < 5 out side loop
                       
                       # setting the index and offset to 0   
               zero:         
                        li            $t4,0
                        li            $t2,0
                        j             MaxValue        # jumping to perform the max value of the array
                                          
                        
  swamp:                       
                       beq            $t4,$t7 zero    # $t4 == $t6 go to zero  
                       # performing the swamp
                       sw             $t1,($s3)
                       move           $t1,$s1
                       sw             $t1,($t3)
                       j              backToSort     # returning to sort
 
   MaxValue:           # getting a new line
                       li            $v0, 4
                       la            $a0,NewLine
                       syscall
                       #  prompting the max string                
                       li            $v0, 4
                       la            $a0,PromptingMax
                       syscall
                       # getting the max value from the sorted array
                       sub           $t7,$t7,1           # $t6 - 1 -> $t6 for the last index      
                       add           $t4,$t4,$t7         # $t4 + $t6 -> $t4 getting the last index                
                       mul           $t2, $t4, 4         # creating the offset -> $t2
                       add           $t3, $t0,$t2        # offset + base address -> $t3
                       
                       lw            $t1,($t3)           # $(t3) -> $t1 
                       # printing the max value
                       li            $v0, 1              #  load system call (print integer) into syscall register 
                       move          $a0, $t1    
                       syscall
                       #setting index and offset to zero
                       li            $t4,0
                       li            $t2,0
 MinValue:             
                       # New line and Prompting the string for Min
                       li            $v0, 4
                       la            $a0,NewLine
                       syscall               
                       li            $v0, 4
                       la            $a0,PromptingMin
                       syscall
                       #getting the address for the first value of the index
                       add           $t3, $t0,$t2    # $t0 + $t2 -> $t3 
                       
                       lw            $t1,($t3)       # ($t3) -> $t1  
                       
                       li            $v0, 1            # load system call (print integer) into syscall register 
                       move          $a0, $t1    
                       syscall
                       # setting index and offset to zero
                       li            $t4,0
                       li            $t2,0                       
                       # retturning the value for the loop to the original value
                       add           $t7,$t7,1         # $t6 + 1 -> $t6 
  
  AddingTheArray:      
                        
                       
                        # getting the values from the array for the sum
                        add           $t3, $t0, $t2
                        lw            $t1, ($t3) 
                        #adding the value to a counting the total
                        add           $s6,$s6,$t1 
                        #increasing the index  
                        add           $t4,$t4,1
                        bne           $t4,$t7 AddingTheArray    # $t4 -> $t6 branch
                        # prompting the value of the sum
                        li            $v0, 4
                        la            $a0,PromptingSum
                        syscall
                        li            $v0, 1            # load system call (print integer) into syscall register 
                        move          $a0, $s6
                        syscall
                        # setting the index and offset to 0
                        li            $t4,0
                        li            $t2,0
                        
                        li            $v0, 4
                        la            $a0,NewLine
                        syscall   
                        # setting the the flag to 0 
                        mul           $s5,$s5,0
           
  Print:                 
                        # printing the array
                        add           $t3, $t0, $t2
                        lw            $t1, ($t3) 
                        li            $v0, 1            # load system call (print integer) into syscall register 
                        move          $a0, $t1          # load argument for syscall 
                        syscall 
                        li            $v0, 4
                        la            $a0,Space
                        syscall
                        
                        add           $t4,$t4,1         # incrasing the index
                        mul           $t2, $t4, 4       # creating the offset
                        blt           $t4,$t7 Print     # if $t5 == $t6 -> while
                        # setting the index and offset to zero
                        mul           $t4,$t4,0
                        mul           $t2,$t2,0
                        # the value of the flag
                        bne           $s5,0 SortingArray # $5 != 0 branch 
                        #resetting the flag to 1
                        add           $s5,$s5,1
                        #asking if the user wants to continue 
                        li            $v0, 4              # $v0 <- 4 for prompting to the screen
                        la            $a0, Continue       # $a0 <- Continue variable
                        syscall
                        # prompt of a caracter
                        li            $t4,0
                        li            $t2,0
                        li            $v0,8              # $v0 <- 8  
                        la            $a0,Buffer         # $a0 <- Buffer
                        li            $a1, 12            # $a1 <- 12
                        syscall
                        lb            $t6  0($a0)
                        beq           $t5, $t6 while    # if $t5 == $t6 -> while
                        
                         # Ending the program
                        li             $v0, 10 
                        syscall                  

