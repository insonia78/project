;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |lab 1|) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;; lab 1 Author Thomas zangari date 9/5/2014
;; signature slope:number number number number -> number
;; purpose: to determine the slope bettwen two points

;test
(check-expect(slope  1  1  2  2 )1)
(check-expect(slope  2  1  1  2 ) -1)
(check-expect(slope  1  0  2  0 ) 0)

;definition
(define (slope X1 Y1 X2 Y2)
  (/(- Y2 Y1)(- X2 X1)))
                 
          
 ;values            
(slope 1 2 3 4 )

;;signature  string-first: string -> string-ith 0 
;;purpose: to extract the first letter of a word

;test
(check-expect(string-first "Apple")"A")
(check-expect(string-first "horse")"h")
(check-expect(string-first "pen")"p")

;definition
(define i 0)
(define (string-first word) 
  (string-ith word i))

(string-first "thomas")


;;signature string-last: string -> string-1th word (-(string length word) 1)
;;purpose: get the last letter of the word

;;test
(check-expect(string-last "Shoe")"e")
(check-expect(string-last "hello")"o")
(check-expect(string-last "job")"b")

;;definition 
(define (string-last word) 
  (string-ith word (- (string-length word) 1)))

(string-last "thomas")
