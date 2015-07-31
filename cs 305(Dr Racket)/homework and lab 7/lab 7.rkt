;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |lab 7|) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;; Example 3 
;; data definition
;A list-of-names is one of
; - empty;
;-(cons String List-of-names

(define list1(cons 1(cons "A"(cons "B"(cons "C"(cons "D" empty))))))

;signature 

(check-expect (NumberofNames empty)0)
(check-expect (NumberofNames (cons "me" empty))1)
(check-expect (NumberofNames list1)4)

(define (NumberofNames alist)
  (cond [(empty? alist)0]
        [(string? (first alist))(+ 1 (NumberofNames (rest alist)))]
        [else  (NumberofNames (rest alist))]))
   

;;example 4
; A list-of-numbers (lon) is either
; -- empty,or
; -- (cons n lon) where n is a number and lon is a lost-of-numbers
;test

(check-expect (centigrade empty)empty)
(check-expect (centigrade (cons 32 empty)) (cons 0 empty))
(check-expect (centigrade (cons 212 (cons 32 empty)))(cons 100(cons 0 empty)))
(check-expect (centigrade (cons "string"(cons 212 (cons 32 empty))))(cons 100(cons 0 empty)))
;define Farenheit->Centigrade -> Number
;purpose converts a number in centigrade
(define (Farenheit->Centigrade atemp)
  (* 5/9 (- atemp 32)))

;;centigrade list -> list
;; it converts the content of a list in centigrade
(define (centigrade atemp)
  (cond [(empty? atemp) empty]
        [(number? (first atemp)) (cons(Farenheit->Centigrade(first atemp))(centigrade(rest atemp)))]
        [else (centigrade(rest atemp))]))

;;example 5
;A list-of-names (lon) is either a 
;-- empty,or

;test
(check-expect(shortname L1 4)(cons "thom" (cons "anto" (cons "fran" empty))))
(check-expect(shortname L2 4)(cons "thom" (cons "anto" (cons "fran" empty))))
(check-expect(shortname L1 10)L1)
(check-expect(shortname (cons "thomas" empty) 10)(cons "thomas" empty))
(check-expect(shortname null 0)null)
;define
(define L1(cons "thomas"(cons "antonio"(cons "francesco" empty))))
(define L2(cons "thomas"(cons 2 (cons "antonio"(cons "francesco" empty)))))
;sginature shortname: list-of-names -> list-of-names
;purpose it returns the list of name wiht the names shorten
(define(shortname alist value)
  (cond[(empty? alist)empty]
  [(string? (first alist))(cons(short(first alist) value)(shortname(rest alist) value))]
  [else (shortname(rest alist) value)]))

;helper function 
;computes the actual shorten of the string 
(define (short str value)
  (if (> value (string-length str )) str  (substring str 0 value)))


;;example 6
;; a list-of-names is either 
;-- false,or 
;-- true

;test
(check-expect(name? aL1)true)
(check-expect(name? aL2)false)

;define
(define aL1(cons "Flatt"(cons "thomas"(cons "antonio"(cons "francesco" empty)))))
(define aL2(cons "thomas"(cons "antonio"(cons "francesco" empty))))

;definition list-of-names -> boolean
;purpose it checks if a name exist if it exist it returns true else false
(define (name? alist)
  (cond[(empty? alist) false]
       [(string=? (first alist) "Flatt") true]
       [else (name?(rest alist))]))

;example 7
; a list-of-names is either 
;-- false
;-- true
;test
(check-expect(checkLenght? empty)false)
(check-expect(checkLenght? (cons "12345678910" empty))true)
(check-expect(checkLenght? aL3)true)
(check-expect(checkLenght? aL4)false)

;;define  
(define aL4(cons "123456" (cons "thomas" (cons "baku" empty))))
(define aL3(cons "12345678910" (cons "thomas" (cons "bakuslakyinsky" empty))))
;definition list -> Boolean
;purpose:it checks if the lenght of the name is more then 10  if yes returns true else false
 (define(checkLenght? alist)
   (cond[(empty? alist) false]
        [else 
         (cond [(> (string-length (first alist)) 10) true]
        [else (checkLenght? (rest alist))])]))

;;example 8
;a list-of-numbers is either 
;; -- false 

;test
(check-expect(check listn1)false)
(check-expect(check listn2)true)

;define
(define listn1(cons 1(cons 2(cons -1 empty))))
(define listn2(cons 0(cons -1(cons -2 empty))))

;;definition list -> boolean
;;purpose it checks if the list as a number > 1 if yes return false else true
(define(check alist)
  (cond
    [(empty? alist) true]
    [else (cond 
      [(>=(first alist) 1) false]
    [else (check (rest alist))])]))