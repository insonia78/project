;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |lab 3|) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
;Thomas Zangari

;#1

;;signature slope: (/(-(posn-y p2)(posn-y p1))(-(posn-x p2)(posn-x p1))))->number
;;purpose: To find the slope between 2 points
;;Data definition
;;Entry (make-posn number number)
;;enterp.: number number

;test
(check-expect (slope(make-posn 0 0)(make-posn 2 3)) 1.5)

;definition
(define (slope p1 p2)
    (/(-(posn-y p2)(posn-y p1))(-(posn-x p2)(posn-x p1))))

;;signature distance: (sqrt (+ (sqr (- (posn-x p1) (posn-x p2))) (sqr (- (posn-y p1) (posn-y p2)))))) -> number
;;purpose: To find the distance between 2 points
;;Data definition
;;Entry (make-posn number number)
;;enterp.: number number

;test
(check-within (distance(make-posn 0 0) (make-posn 2 3)) 3.605551275463989 .01)
;definition
(define (distance p1 p2)
 (sqrt (+ (sqr (- (posn-x p1) (posn-x p2))) (sqr (- (posn-y p1) (posn-y p2))))))
 
;;signature distance: (/ (+ (posn-x p1) (posn-x p2)) 2)(/ (+ (posn-y p1) (posn-y p2)) 2))) -> number
;;purpose: To find the midpoint between 2 points
;;Data definition
;;Entry (make-posn number number)
;;enterp.: number number

;test
(check-expect (midpoint (make-posn 0 0) (make-posn 2 3)) (make-posn 1 3/2))

;definition
(define (midpoint p1 p2)
 (make-posn (/ (+ (posn-x p1) (posn-x p2)) 2) 
 (/ (+ (posn-y p1) (posn-y p2)) 2)))


;#2
;a
(define-struct employee(Name Hourly-rate overtime?))
;b
;;Data Definition
;;Entry: (make-employee String number boolean)
;;interp.: name, hourly rate in numbers, if overtime is done

;c
;make-employee
;employee?
;employee-Name
;employee-Hourly-rate
;employee-overtime?
;eq?
;equals?

;d
(define en(make-employee "thomas" 15.00 true))


;2
;;signature EmployeeRaise:(+ (*number number) number) -> number
;;purpose: it calculates the increase inthe employee hourly rate

;test
(check-expect(EmployeeRaise en)16.5)
;define
(define (EmployeeRaise en)
  (+ (* (employee-Hourly-rate en) .1) (employee-Hourly-rate en)))
 

;;signature EmployeeRecord: if(string string ) -> bool
;;purpose:it checkes if tho record names are the same
;test
(check-expect(EmployeeRecord? "Antonio")false)
(check-expect(EmployeeRecord? "thomas")true)
;define
(define(EmployeeRecord? name)
  (if (string=? (employee-Name en) name) true false)) 

;;signature EmployeePay : cond(hour) -> number
;;signature normalPay:  number number -> number
;;signature extratime: number number -> number
;;signature overPay: cond[bool] -> number
;;purpose:It the calculates the pay cheking if an employee is elegible for overpay
;test
(check-expect(EmployeePay en 55 )1837.5)
(check-expect(EmployeePay en2 55)"Error")
(check-expect(EmployeePay en3 40) 600)
(check-expect(EmployeePay en4 -5)"Invalid Entry")
(check-expect(EmployeePay en5 20)300)
 
;define
(define en2(make-employee "antonio" 15.00 false))
(define en3(make-employee "giuseppe" 15.00 true))
(define en4(make-employee "francesco" 15.00 false))
(define en5(make-employee "thomas" 15.00 true))
;definition
(define(EmployeePay em wh)
  (cond [(< wh 0) "Invalid Entry"]
        [(<= wh 40) (normalPay em wh)]
        [else (overPay em wh)]))
;define normalPay
(define(normalPay em wh)
  (*(employee-Hourly-rate em) wh))
;define extratime pay
(define(extratime em wh)
  (*(+ (* (employee-Hourly-rate en) .5)(employee-Hourly-rate en))wh))

;define decision if the employee is eligeble for overtime
(define(overPay em wh)
  (cond [(and(employee-overtime? em) true) (+(extratime em wh)(normalPay em 40))]
        [else "Error"] ))

