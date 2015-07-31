;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |homework 1 recoverd|) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;; Hw #1 Thomas zangari cs305
;;signature distance-origin: sqrt (* number number) (* number number) -> number
;;purpose: to find the distance of two points from the origin 


;1a
;variables
(define x 8)
(define y 36)

;expression
(sqrt(+ (* x x) (* y y)))

;#1b
;;signature distance-origin: sqrt (* number number) (* number number) -> number
;;purpose: to find the distance of two points from the origin 

;;test
(check-expect(distance-origin 3 4)5)
(check-expect(distance-origin 5 12)13)

;definition
(define (distance-origin x y)
   (sqrt(+ (* x x) (* y y)))) 




;;#2a
;;signature string-join: string "_" string -> string
;;purpose: to concatenate two words with an underscore in the middle  



;; variables
(define prefix "hello")
(define suffix "world")

;expression
(string-append prefix "_" suffix )

;;#2b
;;signature string-join: string "_" string -> string
;;purpose: to concatenate two words with an underscore in the middle  

;test
(check-expect(string-join "my" "name")"my_name")
(check-expect(string-join "Ciao" "Prof")"Ciao_Prof")

;definition
(define (string-join prefix suffix)
  (string-append prefix "_" suffix ))


;#3a
;;signature string-insert: string "_" string -> string
;;purpose: to insert an "_" between a  underscore in the middle  


;variables
(define str "helloworld")
(define i 5)

;expression
(string-append (substring str 0 i) "_" (substring str i) )

;#3b
;;signature string-insert: string "_" string -> string
;;purpose: to insert an "_" between a  underscore in the middle  


;test
(check-expect(string-insert "myname" "_" 2)"my_name")
(check-expect(string-insert "CiaoProf" "_" 4)"Ciao_Prof")
(check-expect(string-insert "" "" 0)"")
;definition
(define(string-insert str underscore i)
  (string-append (substring str 0 i) underscore (substring str i) ))


;#4a
;;signature string-insert: string "_" string -> string
;;purpose: to insert an "_" between a  underscore in the middle 

;expression
(cond [(and (>= i 1) (<= i (string-length str)))(string-append (substring str 0 (- i 1))(substring str i))]
      [else " out of range"])

;#4b
;;signature string-delete: string "_" string -> string
;;purpose: to delete an ith letter from a string 

;test  
(check-expect(string-delete "myname" 2)"mname")
(check-expect(string-delete "CiaoProf" 8)"CiaoPro")
(check-expect (string-delete "a"1)"")
(check-error (string-delete "" 0) )


(define(string-delete str i)
  (string-append (substring str 0 (- i 1))(substring str i)))


;#5
;;signature string-delete: string "_" string -> string
;;purpose: to delete an ith letter from a string 

;test
(check-expect(string-remove-last "myname" 1)"mynam")
(check-expect(string-remove-last "CiaoProf" 1)"CiaoPro")
(check-expect(string-remove-last "" 0)"")
;define
(define (string-remove-last str i )
 (substring str 0 (-(string-length str) i)))

;#6
;;signature string-delete: string "_" string -> string
;;purpose: to delete an ith letter from a string 

;test
(check-expect(string-rest "myname" 1)"yname")
(check-expect(string-rest "CiaoProf" 1)"iaoProf")
(check-expect(string-rest "" 0)"")
;define
(define (string-rest str i )(substring str i ))

;#7a
;;signature
;;purpose: convert two bool to true or false 
(define b1 true)
(define b2 false)

(or(not b1) (not b2))

;#7b
;;signature bool-imply: bool bool -> bool
;;purpose: to check the results of two boolean in certain condition 

;test
(check-expect(bool-imply true false)false)
(check-expect(bool-imply false true)true)

;definition
(define(bool-imply b1 b2)
  (if(and b1 true ) false (if(and b2 true) true false)))


       
;#8
;;signature bool=?: bool bool -> bool
;;purpose: check two bool values and return true or false 

;test
(check-expect (bool=? true false) false)
(check-expect (bool=? (= 9 8) false) true)

;defintion
(define(bool=? x y)
  (if (and x y) true (if(and (not x) (not y)) true false)))              
