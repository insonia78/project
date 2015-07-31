;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |homework 2|) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;; Author thomas zangari 

(define (function n)
(cond
 [(<= n 1000) (* .040 1000)]
 [(<= n 5000) (+ (* 1000 .040) 
 (* (- n 1000) .045))]
 [else (+ (* 1000 .040) 
 (* 4000 .045)
 (* (- n 10000) .055))]))

(function 500)
(function 2800)
(function 15000)
;#1
;;Signarure interest: cond [(range) number]
;;Purpose: calculates a different flat interests for different values 

;test
(check-expect(interest 500) 20)
(check-expect(interest 2000) 90)
(check-expect(interest 6000) 300)
(check-expect(interest -1) "Invalid entry")
;definition
(define(interest n)
  (cond 
   [(< n 0)"Invalid entry"]
   [(<= n 1000) (* n 0.04)]
   [(<= n 5000) (* n 0.045)]
   [else (* n 0.05)]))

;#2
;a
;;Signature tax: (cond [(range)number])
;;Purpose: calucaltes the tax for different values 
;test
(check-expect(tax 240)0)
(check-expect(tax 480)72)
(check-expect(tax 490)137.2)
(check-expect(tax -1)"Invalid entry")
;definiton
(define (tax n)
  (cond
   [(< n 0)"Invalid entry"]
   [(<= n 240) 0]
   [(<= n 480) (* n 0.15)]
   [else (* n .28)]))
;b
;;Signature netpay: (- (* number number)(function(*number number))
;;Purpose: calucaltes the  netpay based on hours worked  
;test
(check-expect(netpay 10) 120)
(check-expect(netpay 30)306)
(check-expect(netpay 45)388.8)

(define hrRate 12)

;definition

(define(netpay h)
  (-(* h hrRate) (tax (* h  hrRate))))


;#3
;a
;;Signature discriminatnt: (- (* number number)(* 4 number number))
;;Purpose: calculates the discriminant of a quadratic equation
;test
(check-expect(discriminant 0 0 0)0)
(check-expect(discriminant 0 1 5)1)
(check-expect(discriminant 1 0 2) -8)
(check-expect(discriminant 2 2 2) -12)
;definition
(define (discriminant a b c)
  (- (* b b) (* 4 a c)))

;b
;;Signature how-many: cond [(<=> (* number number)(* 4 number number))]
;;Purpose: calculates how many solutions the discriminant would have 

;test
(check-expect(how-many 1 0 -1) 2)
(check-expect(how-many 1 2 1) 1)
(check-expect(how-many  1 1 1) 0)

;definition
(define (how-many a b c)
  (cond [(> (discriminant a b c) 0) 2]
        [(= (discriminant a b c) 0) 1]
        [ else 0]))

;b
;;Signature mod_how-many: (cond [(bool)number])
;;Purpose to calculate when  a equation is degenerate
;test
(check-expect(mod_how-many 0 0 -1) 0)
(check-expect(mod_how-many 0 0 0) 0)
(check-expect(mod_how-many  0 1 1) 1)
(check-expect(mod_how-many  1 2 1) 1)
;define
(define (mod_how-many a b c)
  (cond [(not(= a 0)) (how-many a b c)]
      [(not(= b 0)) 1]
      [else 0]))
                    


;#4
;;Signature charge : cond [(number number) number]
;;purpose:  given MB data transferred and base base, compute charges
;test
(check-expect (charge 100 1) 100)  
(check-expect (charge 501 1) 761.52)
(check-expect (charge 1501 1) 3002)
(check-expect (charge -1 5)"invalid entry")
(check-expect (charge 400 1)552)
;definition
(define (charge d b)
  (cond [(< d 0)"invalid entry"]  
        [(<= d 100) (* d b)]
        [ (<= d 500)
        (* (+ (* b 1.33) .05) d)]
        [ (<= d 1500)
          (* (+ (* b 1.44) .08) d)]
        [else (* (* b 2) d)]))
 
