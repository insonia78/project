#
# prgram 3 created by Thomas Zangari csci 312
#
# The program finds the common devisor from 2 numbers 
#
                    .data
WordLarge:          .asciiz  "Larger"
WordSmall:          .asciiz  "Smaller"
WordReminder:       .asciiz  "Reminder"
Space:              .asciiz  "     "
Space2:             .asciiz  "         "
Line:               .asciiz  "The greatest common divisor "
JumpLine:           .asciiz  "\n"
Numerator:          .word   7764
Denominator:        .word   3648
Reminder:           .word   0
GreatComDivisior:   .word   0

  
                    .text
 #loading the variables
                    lw      $t0, Numerator         # Loading word in register $t0
                    lw      $t1, Denominator       # Loading word in register $t1
                    lw      $t2, Reminder          # Loading word in register $t2
                    lw      $t3, GreatComDivisior  # Loadinf word in register $t3
                    li      $t4, 1                 #Ending value of the loop
                                       
# printing the asciiz variables
                    
                    li      $v0,4                  #
                    la      $a0,WordLarge          # Printing word WordLarge
                    syscall
                    li      $v0,4                  # Printing word Space
                    la      $a0,Space              #
                    syscall
                    li      $v0,4                  #
                    la      $a0,WordSmall          # Printing word WordSmall
                    syscall
                    li      $v0,4                  #
                    la      $a0,Space              # Printing word Space
                    syscall
                    li      $v0,4                  # 
                    la      $a0, WordReminder      # Printing word WordReminder 
                    syscall
                    li      $v0,4                  #
                    la      $a0,Space              # Printing word Space
                    syscall
                    li      $v0,4                  #
                    la      $a0,JumpLine           # Prinitng word JumpLine
                    syscall
                    
#performing the loop                   
                     
                   
top:                bgt     $t4, $t1, next    #looping the registers $t4 and $t1  
                    
                    li      $v0, 1            #
                    move    $a0,$t0           # Printing  $a0 <- $t0 
                    syscall
                    li      $v0,4             #
                    la      $a0,Space2        # Printing $a0 <- Space2
                    syscall
                    li      $v0, 1            # 
                    move    $a0,$t1           # Printing $a0 <- $t1
                    syscall
                    li      $v0,4             #
                    la      $a0,Space2        # Printing $a0 <- Space2 
                    syscall
                   
                    div     $t0,$t1           # Dividing $t0, $t1
                    mfhi    $t2               # Moving $t2 <- hi
                    
                    li      $v0, 1            # 
                    move    $a0,$t2           # Printing $a0 <- $t2
                    syscall
                    li      $v0, 4            # 
                    la      $a0,Space2        # Printing $a0 <- Space2 
                    syscall
                    li      $v0, 4            #
                    la      $a0,JumpLine      # Printing $a0 <- JumpLine     
                    syscall
                   
                    
                    move   $t0,$t1           # Moving $t0 <- $t1
                    move   $t3,$t1           # Moving $t3 <- $t1
                    move   $t1,$t2           # Moving $t1 <- $t2
                    
                    j      top               # Jumping to the variable top 
                    
 next:              li      $v0, 4          #
                    la      $a0, Line       # Printing $a0 <- Line
                    syscall
                    li      $v0, 1          #
                    move    $a0,$t3         # Printing $a0 <- $t3
                    syscall
                   
 # Ending the program
                    li      $v0, 10 
                    syscall    
  Larger     Smaller     Reminder     
7764         3648         468         
3648         468         372         
468         372         96         
372         96         84         
96         84         12         
84         12         0         
The greatest common divisor 12
-- program is finished running --
 
                    
                    
                    
                                                           
