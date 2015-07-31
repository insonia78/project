;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname lab2_part3_partial) (read-case-sensitive #t) (teachpacks ((lib "testing.ss" "teachpack" "htdp") (lib "guess.ss" "teachpack" "htdp") (lib "world.ss" "teachpack" "htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "testing.ss" "teachpack" "htdp") (lib "guess.ss" "teachpack" "htdp") (lib "world.ss" "teachpack" "htdp")))))
;; Part II #3

;SIGNATURE pay-back: (cond x [( range) string or number])
;PURPOSE: To calculate the interest to give back to the client base on its purcase on the credit card
; tests: INCOMPLETE FILL IN USE THE 4 charge amount/pay back from the table
(check-expect (pay-back 400)1)
(check-expect (pay-back 1400)5.75)
(check-expect (pay-back 2000)10)
(check-expect (pay-back 2600)14.75)
; define - ADD THE other (constant) defines (lab2 handout) below and define the function
(define (first$500 x) 
  (* .0025 x))
(define(first$1500 x)
  (+(* (- x 500) 0.005)(first$500 500)))
(define (first$2500 x)
    (+(*(- x 1500) 0.0075)(first$1500 1500)))
(define (first>2500 x)
  (+(* (- x 2500) .01)(first$2500 2500)))
 (first$1500 1500)

; define the function
(define (pay-back x)
  (cond [(<= x  0) "invalid entry"]
        [(<= x 500) (first$500 x)]
        [(<= x 1500)(first$1500 x)]
        [(<= x 2500)  (first$2500 x)]
        [else (first>2500 x) ]))

 
