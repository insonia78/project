                  .data
#
#     define a greeting message.
#
Message: .asciiz "Hello World!\n"
         .text
#
# Print the greeting message.
#
         li          $v0, 4
         la          $a0, Message
         syscall
#
# Return to the operating system.
#
        li            $v0, 10
        syscall
        
         
         