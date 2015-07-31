;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |lab 8|) (read-case-sensitive #t) (teachpacks ((lib "image.ss" "teachpack" "2htdp") (lib "universe.ss" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.ss" "teachpack" "2htdp") (lib "universe.ss" "teachpack" "2htdp")))))
;;Exercise 1

;; Structure and Data Definitions:  
(define-struct    worker  (employee rate hours))

; Worker is a structure: (make-worker String   Number  Number). 
; interp. (make-worker n r h) combines the name (n) 
; with the pay rate (r) and the number of hours (h) worked.
; represents the work done by an hourly employee

; Low (list of workers) is one of: 
; – empty
; – (cons Worker Low)
; interp. an instance of Low represents the work efforts of some hourly employees
(define L1 empty)
(define L2 (cons (make-worker "Robby" 11.95 39) empty))
(define L3 (cons (make-worker "Matthew" 12.95 45) 
                 (cons  (make-worker "Robby" 11.95 39) empty)))
; FindWagesofListofWorkers:  Low -> List-of-numbers
; compute the weekly wages for all given weekly worker records 

(check-expect (FindWagesofListofWorkers L2)   (cons (*  11.95  39) empty))
(check-expect (FindWagesofListofWorkers L3)  (cons (* 12.95  45) (cons (*  11.95  39) empty)))
;signature FindWagesofListofWorkers: list-of-(make-workers)->lis-of-(make-workers)
;purpose finds the salary of a list of workers calculating the base salary and the hours
(define (FindWagesofListofWorkers alist)
  (cond[(empty? alist)null]
       [(worker? (first alist))(cons(calculate(first alist)) (FindWagesofListofWorkers (rest alist)))]
       [else (FindWagesofListofWorkers(rest alist))]))
;helper function calculate : list -> number  
(define (calculate alist)
  (* (worker-rate alist)(worker-hours alist)))


;;Exercise 2
(define-struct gross_paycheck(name gross-weekly-wage tax))
;;gross_pay is a structure(String Number Number)
(define-struct paycheck (name gross-weekly-wage tax net-weekly-wage))
;; a paycheck is a (make-paycheck string number number number)
;; a Lop is a list of paychecks
;; Examples
;define
 (define gross_paycheck1(cons (make-gross_paycheck "thomas" 500 0.07)
                              (cons (make-gross_paycheck "antonio" 600 0.07)
                                    (cons(make-gross_paycheck "francesco" 500 0.07) empty)))) 
;;helper function create_paycheck: make-gross_pay -> make-paycheck
;;creates a make-paycheck object 
 (define (create_paycheck alist)
   (make-paycheck (gross_paycheck-name alist)(gross_paycheck-gross-weekly-wage alist)(gross_paycheck-tax alist)(net(gross_paycheck-gross-weekly-wage alist)(gross_paycheck-tax alist))))
  
;;function
;; creates a list of make-paycheck
  (define (loop_paycheck1 alist)
    (cond[(empty? alist)null]
         [(gross_paycheck? (first alist))(cons(create_paycheck(first alist))(loop_paycheck1(rest alist)))])) 
   
;; helper function net : number number -> number
;; creates the net-weekly-wage  for the make-paycheck object
  (define (net apay atax)
  (- apay (* apay atax))) 

;; (loop_paycheck gross_paycheck) -> paycheck1
(define paycheck1 (loop_paycheck1 gross_paycheck1))
;list of paycheck -> paychecklist1
(define paychecklist1 (cons paycheck1 empty))

;; FindPaycheckforListofWorkers: Low -> Lop
;; READ THE NEXT 4 lines BEFORE you define worker1 below
(define worker1 (cons paycheck1 empty)) 
(define low1 (cons worker1 empty))

 ;test
(check-expect (FindPaycheckforListofWorkers low1) paychecklist1)
    
      
;; helper function
;; FindPaycheckforWorker: Worker -> Paycheck
;; purpose: returns the paycheck of a worker
(check-expect (FindPaycheckforWorker worker1) paycheck1)
(define (FindPaycheckforWorker aWorker)
  ( first aWorker))  
      
;; FindPaycheckforListofWorkers
(define (FindPaycheckforListofWorkers alow)
  (FindPaycheckforWorker alow))

;exercise 3
;a
;test
(check-expect(sum alist)6)
;define alist of Posn
(define alist(cons(make-posn 2 3)(cons(make-posn 3 2)(cons (make-posn 1 1) empty))))

;sum: list-of-(make-posn)->number
;purpose computes the sum of the x coordinate 
(define (sum alist)
  (cond [(empty? alist)0]
  [else (+ (posn-x (first alist))(sum(rest alist)))]))


;b
;test
(check-expect(translate alist) alist1)
;define the list of the alist with the y coordinate increased by 1
(define alist1(cons(make-posn 2 4)(cons(make-posn 3 3)(cons (make-posn 1 2) empty))))

;translate: list-of-(make-posn)->list-of-(make-posn)
;it creates the list with the y coordinate increased by 1
(define (translate l)
  (cond[(empty? l)null]
       [else (cons (addy (first l))(translate (rest l)))]))

;;helper function addy list-> (make-posn x (y+1))
;it computes the increase of the y coordinate 
(define (addy l)
  (make-posn (posn-x l) (+ (posn-y l) 1))) 
;c
;test
(check-expect(legal values) alist)
;;defines a list of make-posn
(define values(cons(make-posn 2 3)(cons(make-posn 3 2)(cons (make-posn 200 300)(cons (make-posn 1 1) empty)))))

;;legal: list-of-make-posn -> list-of-make-posn
;; creates a new make-posn list with the accepted coordinates
;accepted coordinates x >=0 x<=100 and y>=0 y<=200
(define (legal l)
  (cond[(empty? l)null]
       [(and (and(>=(posn-x (first l))0)(<=(posn-x (first l)) 100))(and(>=(posn-y (first l))0)(<=(posn-y (first l)) 200)))(cons (make-posn (posn-x (first l)) (posn-y (first l))) (legal(rest l)))]
       [else (legal(rest l))]))

