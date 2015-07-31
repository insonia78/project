;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-intermediate-lambda-reader.ss" "lang")((modname examples) (read-case-sensitive #t) (teachpacks ((lib "image.ss" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.ss" "teachpack" "2htdp")))))
;; lab 1 Author Thomas zangari date 9/5/2014
;; monthlypay:number -> number
;; purpose: to determine the monthly pay


;;test:
(check-expect (monthly-pay 1) 58.25)
(check-expect (monthly-pay 2) 66.50)
(check-expect (monthly-pay 5) 91.25)
(check-expect (monthly-pay 10) 132.50)

;definition 
(define (monthly-pay  hrs) 
  (+ (* 8.25 hrs) 50 ))
  


  


(define-struct person(father mother name date eyes))

(define Eva(make-person Fred Eva "Gustav""1265""blue"))
(define Dave(make-person empty empty "bettina" 

(check-expect (blue-eyed-ancestor? Eva)true)
(define(blue-eyed-ancestor? aFTN)
  ((lambda(x)
     (string=? (person-eyes x) "blue")) aFTN))