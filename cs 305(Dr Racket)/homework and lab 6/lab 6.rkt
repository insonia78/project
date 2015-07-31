;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |lab 6|) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;;Lab 6
;signature sum: list -> number
;purpose returs the sum of the list
;exercise 1

;test
(check-expect(sum empty)0)
(check-expect(sum L1)4)

;define
(define L1(cons 2(cons -1(cons 1(cons 1(cons 1 empty))))))

(define(sum list) 
(cond[(null? list) 0]
     [else (+(first list)(sum(rest list)))]))

;;exercise 2
;signature count : list -> number
;purpose: returns the count of how many elements are > 0 in the list
;test
(check-expect(count empty)0)
(check-expect(count L1)1)

;define
(define (count list)
  (cond[(null? list)0]
       [(< (first list) 0) (+ 1 (count(rest list)))]
       [else (count(rest list))]))

;exercise 3
;signature lenght: list -> number
;purpose: return the length of the list
(check-expect(lenght empty)0)
(check-expect(lenght L1)5)

(define(lenght list)
  (cond[(null? list)0]
       [else (+ 1 (lenght(rest list)))]))