;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname examples) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;; thomas zangari Lab 4

(define-struct centry (name home office cell))
(define-struct phone (area number))
(define Centry1
(make-centry "Shriram Fisler"
(make-phone 207 "363-2421")
(make-phone 101 "776-1099")
(make-phone 208 "112-9981"))) 


;;Data Definition of a phone:
;; A Phone is a structure (make-phone Number Number)
;;interp. 3-digit area code and 7-digit if the phone number 
;;Data Definition of a Centry
;;A C


;;findcellphone#:string Centry -> Phone or String
;;purpose: to find if a name maches the 
;test
(check-expect(findcellphone# "Shriram Fisler"  Centry1)(make-phone 208 "112-9981"))
(check-expect(findcellphone# "Shriram"  Centry1)"The name does not match")
;definition
(define (findcellphone# name c)
  (if(string=?(centry-name c) name) (centry-cell c) "The name does not match")) 

;;x+:Posn -> Posn
;;purpose to encrement the value of x by 3
;test
(check-expect (x+ (make-posn 2 3))(make-posn 5 3))
(check-expect (x+ (make-posn 6 2))(make-posn 9 2))
;definition
(define (x+ aposn)
  (make-posn(+(posn-x aposn) 3)(posn-y aposn)))

;;y-:Posn -> Posn
;;purpose to decrement the value of y by -3
;test
(check-expect (y- (make-posn 2 3))(make-posn 2 0))
(check-expect (y- (make-posn 6 2))(make-posn 6 -1))
;definition
(define (y- aposn)
  (make-posn(posn-x aposn)(-(posn-y aposn) 3)))
;;posn-up-x Posn Number -> Posn
;;purpose to change the value of x by the value typed 

;test
(check-expect (posn-up-x (make-posn 1 2)100)(make-posn 100 2))
(check-expect (posn-up-x (make-posn 1 2)-100)(make-posn -100 2))

;define             
 (define (posn-up-x posn anumber)             
     (make-posn anumber (posn-y posn)))  

;;posn-up-y Posn Number -> Posn
;;purpose  to change of y by the value typed

;test
(check-expect (posn-up-y (make-posn 1 2)100)(make-posn 1 100))
(check-expect (posn-up-y (make-posn 1 2)-100)(make-posn 1 -100))

;define             
 (define (posn-up-y posn anumber)             
     (make-posn(posn-x posn)anumber)) 

;;newposn-up-x Posn -> Posn
;;purpose to increment the value of x by 3
;test
(check-expect (newposn-up-x (make-posn 2 3))(make-posn 5 3))
(check-expect (newposn-up-x (make-posn 6 2))(make-posn 9 2))
;definition
(define (newposn-up-x aposn)
  (make-posn(+(posn-x aposn) 3)(posn-y aposn)))

;;Problem 3 

(define-struct velocity (dx dy))

; A Velocity is a structure: (make-velocity Number Number)
; interp. (make-velocity d e) means that the object moves d steps along the horizontal 
; and e steps along the vertical per tick


(define-struct ufo (loc vel))
; A UFO is a structure: (make-ufo Posn Velocity)
; interp. (make-ufo p v) is at location p moving at velocity v

(define velocity1(make-velocity 2 3))
(define ufo1(make-ufo (make-posn 3 4) velocity1))



;; posn+:Posn Velocity -> Posn 
;;purpose: to add the Posn to the velocity
;test
(check-expect (posn+ (make-posn 22 80) (make-velocity 8 -3)) (make-posn 30 77))
(check-expect (posn+ (make-posn 22 80) (make-velocity -5 -3)) (make-posn 17 77))
;; define
(define (posn+ apon1 avelocity)
  (make-posn(+(posn-x apon1) (velocity-dx avelocity))(+(posn-y apon1) (velocity-dy avelocity))))

;; ufo-move1:ufo -> ufo
;;purpose make a ufo move from one position to the next with changing posn and velocity
;test
(check-expect (ufo-move1 (make-ufo (make-posn 22 80) (make-velocity 8 -3)))
 (make-ufo (make-posn 30 77)(make-velocity 8 -3)))
(check-expect (ufo-move1 (make-ufo (make-posn 22 80) (make-velocity -5 -3)))
              (make-ufo (make-posn 17 77)(make-velocity -5 -3))) 
;; define
(define (ufo-move1 aufo)
  (make-ufo (posn+ (ufo-loc aufo) (ufo-vel aufo)) (ufo-vel aufo)))
 

 
