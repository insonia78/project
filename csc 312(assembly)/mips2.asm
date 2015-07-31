              .data
#deifne the variables.
First:        .word    3
Second:       .word    5
Answer:       .word    0
Str1:         .asciiz   "The sum of"
Str2:          .asciiz   " and "
Str3:         .asciiz   " is "
Str4:         .asciiz  ".\n"

              .text
# Add the intergers and store the sum.
              lw       $t0, First
              lw       $t1, Second
              add      $t2, $t0, $t1
              sw       $t2, Answer
# Print the output line and return.
              li       $v0, 4
              la       $a0, Str1
              syscall
              li       $v0, 1
              lw       $a0, First
              syscall
              li       $v0, 1
              la       $a0, Str2
              syscall  
              li       $v0, 1
              lw       $a0, Second
              syscall
              li       $v0, 4
              la       $a0, Str3
              syscall
              li       $v0, 1
              lw       $a0, Answer
              syscall
              li       $v0, 4
              la       $a0, Str4
              syscall
              li       $v0, 10
              syscall
                                              