;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname homework5) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;test
(check-expect(wage* L1)(cons 120(cons 240(cons 360 (cons "Exeeds 100 hours" empty)))))
;define
(define L1(cons 10(cons 20(cons 30 (cons 100 empty)))))



; wage: Number -> Number
; compute the wage for given hours of work at the rate of 12 dollars per hour
(define (calculate-wage h)
(* 12 h))
;over100? Number -> Number or String
;it evaluates if an h is over o equal to 100 
(define (over100? h)
(if(>= h 100) "Exeeds 100 hours" (calculate-wage h)))

; wage* : List-of-numbers -> List-of-numbers
; compute the weekly wages for all employees given weekly hours
(define (wage* alon)
(cond
[(empty? alon) empty]
[else (cons (over100? (first alon)) (wage* (rest alon)))]))


;test
(check-expect(count (wage* L1))"there number of invalid entries are 1")
(check-expect(count (wage* L2))"there number of invalid entries are 3")

;definition
(define L2(cons 105(cons 205(cons 30 (cons 100 empty)))))

;signature count: List -> String
;;it accepts a list and returns the number of strings present in the list
(define(count l)
  (string-append "there number of invalid entries are " (number->string(checkList l)))) 

(define (checkList newList)
  (cond[(null? newList)0]
       [(string? (first newList)) (+ 1(checkList(rest newList)))]     
       [else (checkList(rest newList))]))




;;signature robotString?: List-of-String -> List-of Strings
;;purpose
;test
(check-expect(robotString? list1)(cons "a" (cons "b" (cons "c" (cons "r2d2" empty)))))
(check-expect(checkRobot? (robotString? list1))1)
(check-expect(checkRobot? (robotString? list2))0)
(check-expect (robotString? list2)(cons "a" (cons "b" (cons "c" (cons "r" empty)))))
;define
(define list1(cons "a"(cons "b"(cons"c"(cons"robot" empty)))))
(define list2(cons "a"(cons "b"(cons"c"(cons"r" empty)))))

;define
(define (robotString? newList)
  (cond[(null? newList)empty]
       [else (cons (check?(first newList))(robotString?(rest newList)))]))
;define String -> String
;purpose checks if a String equals to a String value 
(define (check? l)
  (if(string=? l "robot") "r2d2" l))

;;define checkRobot? -> Number
;;purpose returns a number of matching String with the value
(define (checkRobot? newList)
  (cond[(null? newList)0]
       [(string=? (first newList) "r2d2") (+ 1(checkRobot?(rest newList)))]     
       [else (checkRobot?(rest newList))]))
  
;;signature substitute: List-of-letters -> List-of-letters 
;;purpose subsitute one value with another
;test
(check-expect (substitute "AB" "CD" aL1) aL2)
;define
(define aL1 (cons "ABCDE" (cons "AB" (cons "CD" (cons "CD" (cons "AB" (cons "AB" empty)))))) )
(define aL2 (cons "ABCDE" (cons "CD" (cons "CD" (cons "CD" (cons "CD" (cons "CD" empty)))))) )


(define (substitute a b list)
  (cond[(null? list)empty]
       [else (cons (checkAB a b(first list))(substitute a b (rest list)))]     
       ))
(define (checkAB aa bb alist)
  (if (string=? alist aa) bb  alist))

;;signature list-of mixed values-> number
;;purpose it calculates the average of the numbers present in the list
;test
(check-expect(average bL1)0.5)
(check-expect(average bL2)0.5)

;define
(define bL1(cons 2(cons 2(cons 2(cons 2(cons "string" empty))))))
(define bL2(cons "string"(cons 2(cons 2(cons 2(cons "string" empty))))))

(define(average list)
  (/ (lenght list) (sum list)))

(define(sum list) 
(cond[(null? list) 0]
     [(number? (first list)) (+(first list)(sum(rest list)))]
     [else (sum (rest list))]))

(define(lenght list)
  (cond[(null? list)0]
       [(number? (first list)) (+ 1 (lenght(rest list)))]
       [else (lenght(rest list))]))

