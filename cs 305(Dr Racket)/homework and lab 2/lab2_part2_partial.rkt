;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname lab2_part2_partial) (read-case-sensitive #t) (teachpacks ((lib "testing.ss" "teachpack" "htdp") (lib "guess.ss" "teachpack" "htdp") (lib "world.ss" "teachpack" "htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "testing.ss" "teachpack" "htdp") (lib "guess.ss" "teachpack" "htdp") (lib "world.ss" "teachpack" "htdp")))))
;; Part II 
;; 2a

;SIGNATURE average: number number number number -> number
;PURPOSE:consumes 4 numbers and returns the average
;tests:
(check-expect (average 60 70 80 90) 75)
(check-expect (average 100 100 0 0) 50)
;define
(define (average s1 s2 s3 s4)
  (/(+ s1 s2 s3 s4) 4))


;; 2b
;SIGNATURE letergrade:(cond(and(>= number number)(<= number number) string])
;PURPOSE:assigne a letter grade do a numeric grade
; tests:
(check-expect (lettergrade 92) "A.  Great work!")
(check-expect (lettergrade 90) "A.  Great work!")
(check-expect (lettergrade 84) "B.  Good.")
(check-expect (lettergrade 80) "B.  Good.")
(check-expect (lettergrade 73) "C.  passing.")
(check-expect (lettergrade 70) "C.  passing.")
(check-expect (lettergrade 66) "D.  Try harder.")
(check-expect (lettergrade 60) "D.  Try harder.")
(check-expect (lettergrade 59.9)"F.  You failed")
;define
(define (lettergrade g)
  (cond [(and (>= g 90)(<= g 100)) "A.  Great work!"]
        [(and (>= g 80)(<= g 90))  "B.  Good."]
        [(and (>= g 70)(<= g 80)) "C.  passing."]
        [(and (>= g 60)(<= g 70)) "D.  Try harder."]
        [else "F.  You failed"])) 

;; 2c
;SIGNATURE findletter: number number number number -> string
;PURPOSE:assign the average of 4 grades to an a letter grade 
;tests:
(check-expect (findlettergrade 60 70 80 90) "C.  passing.")
(check-expect (findlettergrade 100 100 100 100) "A.  Great work!")
;define
(define ( averageA s1 s2 s3 s4)
  (/(+ s1 s2 s3 s3) 4))

(define (findlettergrade s1 s2 s3 s4)
 (cond [(and (>= (averageA s1 s2 s3 s3) 90)(<= (averageA s1 s2 s3 s3) 100)) "A.  Great work!"]
        [(and (>= (averageA s1 s2 s3 s3)80)(<=(averageA s1 s2 s3 s3) 90))  "B.  Good."]
        [(and (>= (averageA s1 s2 s3 s3) 70)(<= (averageA s1 s2 s3 s3) 80)) "C.  passing."]
        [(and (>= (averageA s1 s2 s3 s3) 60)(<= (averageA s1 s2 s3 s3) 70)) "D.  Try harder."]
        [else "F.  You failed"])) 



 


 
