#
# prgram 1 created by Thomas Zangari csci 313
#
# The program calculates the quadratic formula from values entered by the user  
#

                        .data
Prompt:                 .asciiz "Enter the value that you want to calculate: "
Continue:               .asciiz  "\nDo you want to continue y for yes n for no "   
a:                      .asciiz  "Enter the first costant\n"                                       
b:                      .asciiz  "Enter the second constant\n"
c:                      .asciiz  "Enter the third constant\n" 
PromptingResult:        .asciiz  "The result is "
answer:                 .word   'y'

Buffer:                 .space  12
                        .globl  main
                        .text
#loading the variables to the registers                         
                        
              main:
                        lw             $t5,answer          # Loading flag to continue the loop  
                        
              
                   while:       
                                
                        li            $v0, 4              # $v0 <- 4 value for displaying
                        la            $a0, Prompt         # $a0 <- Prompt diplaying the Prompt variable
                        syscall
                        li            $v0,5               # $vo <- 5 value for accepting a keyboard entry that is an integer
                        syscall
                        move          $t3,$v0             # $t3 <- $v0
                                        
                        #ascking to enter the first constant 
                        
                        li            $v0,4                 # $v0 <- 4 value for displaying
                        la            $a0,a                # $a0 <- Prompt diplaying the Prompt variable
                        syscall
                        li            $v0,5               # $vo <- 5 value for accepting a keyboard entry that is an integer
                        syscall
                        move          $s0,$v0                            # $t4 <- lo 
                        #asking to enter the second constant
                        li            $v0, 4              # $v0 <- 4 value for displaying
                        la            $a0,b                # $a0 <- Prompt diplaying the Prompt variable
                        syscall
                        li            $v0,5               # $vo <- 5 value for accepting a keyboard entry that is an integer
                        syscall
                        move          $s1,$v0      
                        #ascking to enter the third constant
                        li            $v0, 4              # $v0 <- 4 value for displaying
                        la            $a0,c                # $a0 <- Prompt diplaying the Prompt variable
                        syscall
                        li            $v0,5               # $vo <- 5 value for accepting a keyboard entry that is an integer
                        syscall
                        move          $s2,$v0             #v$s2 <- $v0
                       
                       #making the calculationss 
                                              
                        mult          $t3,$t3             # $t3 * $t3  
                        mflo          $t4
                        mult          $s0,$t4             # $s0(constant) + $t4
                        mflo          $t0                 # $t0 <- lo 
                        mult          $s1,$t3             # $s1(constant) * $t3
                        mflo          $t1                 # $t1 <- lo
                        add           $t0,$t0,$t1         # $t0 <- $t0 + $t1
                        add           $t0,$t0,$s2         # $t0 <- $t0 + $s2
                        # prompting the result
                        li            $v0, 4                # $v0 <- 4 for prompting to the screen
                        la            $a0, PromptingResult # $a0 <- Prompting_result variable
                        syscall
                        li            $v0, 1              #  $v0 <- 1 for integer output
                        move          $a0,$t0             #  $a0 <- $t0 
                        
                        syscall
                        li            $v0, 4              # $v0 <- 4 for prompting to the screen
                        la            $a0, Continue       # $a0 <- Continue variable
                        syscall
                        # prompt of a caracter
                        li            $v0,8              # $v0 <- 8  
                        la            $a0,Buffer         # $a0 <- Buffer
                        li            $a1, 12            # $a1 <- 12
                        syscall
                        lb            $t6  0($a0)        # $t6 <- 0($a0)
                        beq           $t5, $t6 while     # if $t5 == $t6 -> while
                        
                       
                       
                         # Ending the program
                        li             $v0, 10 
                        syscall                  

# Test
# x = 1 a = 1 b = 1 c = 1 Result 3
# x = 2 a = 1 b = 1 c = 2 Result 8
# x = 1000 a = 1 b = 2 c = 3 Result 1002003 
# Enter the value that you want to calculate: 1
# Enter the first costant
# 1
# Enter the second constant
# 1
# Enter the third constant
# 1
# The result is 3
# Do you want to continue y for yes n for no y
# Enter the value that you want to calculate: 2
# Enter the first costant
# 1
# Enter the second constant
# 1
# Enter the third constant
# 2
# The result is 8
# Do you want to continue y for yes n for no y
# Enter the value that you want to calculate: 1000
# Enter the first costant
# 1
# Enter the second constant
# 2
# Enter the third constant
# 3
# The result is 1002003
# Do you want to continue y for yes n for no n

# -- program is finished running --

