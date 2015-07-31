;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-intermediate-lambda-reader.ss" "lang")((modname lab10-starter) (read-case-sensitive #t) (teachpacks ()) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ())))

;; Lab(Lambda and Higher Order Functions)
;;
;; Purpose: To write programs using Higher-order functions for Lists and using lambda 
;; [Be sure that your language is set to intermediate: lambda]
;;
;; Design functions using higher-order functions and lambda to do the following.  
;; Be sure to write a purpose, signature and enough check-expect examples to fully test the function.
;;
;; 1) short-strings: consumes a list of strings and a length and returns the list of those strings that 
;;    are less than or equal to the given length. Hint: (string-length str): returns the length of the string
;;
;; Signature: short-strings: list-of-strings number -> list-of-strings
;; Purpose: consumes a list of strings and a length and returns the list of those strings that 
;;          are less than or equal to the given length.
;; Tests:
(check-expect(short-string (list "ca" "dog" "paperino" "elefante" "pitone") 3)(list "ca" "dog"))

;; Definition: short-strings
(define (short-string alist number)
  (filter 
   (lambda (x) (<= (string-length x)number)) 
   alist))


;; 2) translate: consumes a listof posns, along with two numbers (deltaX and deltaY) which represent the change 
;;    in the x-coordinate and the change in the y-coordinate, and produces lists of Posns. For each Posn (x,y), 
;;    translate produces a Posn (x+deltaX, ,y+deltaY).
;;
;; Signature: translate: list-of-make-posn number number -> list-of-make-posn 
;; Purpose: consumes a listof posns, along with two numbers (deltaX and deltaY) which represent the change 
;;    in the x-coordinate and the change in the y-coordinate, and produces lists of Posns.
;; Tests:
(check-expect (translate (list (make-posn 3 4)(make-posn 7 3)(make-posn 2 1)) 3 4)(list (make-posn 6 8)(make-posn 10 7)(make-posn 5 5)))
;; Definition: translate
(define (translate alist deltaX deltaY)
  (map
   (lambda (x)
     (make-posn(+ deltaX (posn-x x)) (+ deltaY (posn-y x))))
     alist ))

;; 3) FindandReplaceString : consumes a list of Stings along with two Strings.  It replaces all instances of the 
;;    first String with the second String.
;;
;; Signature: FindandReplaceString: list-of-strings string string -> list-of-strings
;; Purpose: consumes a list of Stings along with two Strings.  It replaces all instances of the 
;;          first String with the second String.
;; Tests:
  (check-expect(FindandReplaceString (list "cat" "dog" "cat" "pitone" "cavallo") "cat" "elefante")(list "elefante" "dog" "elefante" "pitone" "cavallo"))
;; Definition: FindandReplaceString
(define (FindandReplaceString alist string1 string2)
  (map
   (lambda(x)
      (if(string=? x string1) string2 x  )) alist))


;; 4) betweenAandB? Consumes a list of numbers along with two numbers (A and B) and determines if all the numbers 
;;    are between A and B, inclusive.   
;;
;; Signature: betweenAandB?: 
;; Purpose: consumes a list of numbers along with two numbers (A and B) and determines if all the numbers 
;;          are between A and B, inclusive.
;; Tests:
(check-expect (betweenAandB? (list 1 2 3 4 5) 0 6)true  )
(check-expect (betweenAandB? (list 1 2 3 4 5) 1 6) true)
(check-expect (betweenAandB? (list 1 2 3 4 5) 2 6) false)

;; Definition: betweenAandB?
(define (betweenAandB? aLoN A B)
  (andmap
   (lambda (x)
     (and (>= x A)
          (<= x B)))
   aLoN))


;; 5)  An airline maintains information on its flights using the following data definition:
;; A flight is a (make-flight string string string)

(define-struct flight (from to frequency))
;; Example: (make-flight "Boston" "Chicago" “daily”))
;; The frequency is one of “daily”, “weekday” or “weekend”.
;;

(define myflights 
  (list
   (make-flight "Boston" "Chicago" "daily")
   (make-flight "New York" "Providence" "weekend")
   (make-flight "Paris" "Moscow" "weekday")))

;; a) Write a function service-between? that consumes two city names and a list of flights and determines 
;;    whether (true or false) there is a flight from the first city to the second.
;;
;; Signature: service-between?: String String ListOfFlights -> Boolean
;; Purpose: consumes two city names and a list of flights and determines 
;;          whether (true or false) there is a flight from the first city to the second.

;; >>>>>>Tests: USE the list myflights defined above to write enough check-expects to completely test your code.
;test:

(check-expect(service-between? myflights "Boston" "Chicago")true)
(check-expect(service-between? myflights "Boston" "New York")false)
(check-expect(service-between? myflights "Providence" "New York")false)
(check-expect(service-between? myflights "Boston" "Providence")false)

;; Definition: service-between?
(define (service-between? aLoN A B)
  (ormap
   (lambda (x)
     (and (string=? (flight-from x) A)
          (string=? (flight-to x) B)))
   
   aLoN))

(

;; b) Write a function daily-to that consumes a city name and a list of flights and returns a list 
;;    of cities (strings) to which the airline has a daily flight from the given city.
;; 
;; Signature: daily-to: String ListOfFlights  -> ListOfString
;; Purpose: consumes a city name and a list of flights and returns a list 
;;          of cities (strings) to which the airline has a daily flight from the given city.
;; >>>>>>Tests: USE the list myflights defined above to write enough check-expects to completely test your code.


;; Definition: daily-to
 
 (define (daily-to alist

