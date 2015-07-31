;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname lab5) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))
; Scheme definition of a checking account:
(define-struct checking-account(name current-balance monthly-interest-rate))

; Data definition of a checking account:
; a Checking-account is a structure (make-checking String Number Number) 
;; interp.: a name, the current balace, the monthly interest

; Scheme definition of a savings account:
(define-struct savings-account(name current-balance number-of-withdrawls fee-over-the-limit limit-of-withdrawls-before-paying-fee))
; Data definition of a savings account:
; a checking-account is a structure (make-savings String Number Number Number Number)
;; interp. name, current balance,number of withdrwals fees applayed for over the limit withdraw, cealing of withdraw with out fees

;definition for checking account
(define monthly-int-rate 0.015) 
(define checking-account1(make-checking-account "Thomas" 10000 monthly-int-rate))
 
;definition for savings-account
(define fee-over-the-lim 0.010)
(define limit-of-withdrawls-before-paying 20)
(define savings-account1(make-savings-account "Antonio" 10000  15 fee-over-the-lim limit-of-withdrawls-before-paying )) 

;signature account -> account 
;purpose:
;checking-account it increases the amount of the balance
;savings-account it sets the number of withdrawls to 0
  ;test
  (check-expect (start-month checking-account1)(make-checking-account (checking-account-name checking-account1) 10150 monthly-int-rate))
  (check-expect (start-month savings-account1)(make-savings-account (savings-account-name savings-account1) (savings-account-current-balance savings-account1)
                     0 fee-over-the-lim limit-of-withdrawls-before-paying))
  ;definition
 (define (start-month anaccount)
   (cond[(checking-account? anaccount)(make-checking-account (checking-account-name anaccount)
            (+(*(checking-account-current-balance anaccount)monthly-int-rate)(checking-account-current-balance anaccount)) 
            monthly-int-rate)]
        [(savings-account? anaccount)(make-savings-account (savings-account-name anaccount) (savings-account-current-balance anaccount)
                     (*(savings-account-number-of-withdrawls anaccount)0) fee-over-the-lim limit-of-withdrawls-before-paying)]))

;signature account number -> boolean
;purpose:
;checking-account? it checks if their is enough amount to withdraw
;savings-account? it checks if their is enough amount to withdraw and adds if applaiable the fee for limit of withdraws
;test
(check-expect(enough-funds checking-account2 50000)false)
(check-expect(enough-funds checking-account2 5000)true)
(check-expect(enough-funds savings-account2  50000) false)
(check-expect(enough-funds savings-account2  5000) true)
(check-expect(enough-funds savings-account3  5000) true)
(check-expect(enough-funds savings-account3  50000) false)

;define
(define checking-account2(make-checking-account "Thomas" 10000 monthly-int-rate))
(define savings-account2(make-savings-account "Antonio" 10000  15 fee-over-the-lim limit-of-withdrawls-before-paying ))
(define savings-account3(make-savings-account "Antonio" 10000  21 fee-over-the-lim limit-of-withdrawls-before-paying ))

;definition 
(define(enough-funds anaccount amount)
  (cond[(checking-account? anaccount)(if(>= (checking-account-current-balance anaccount)amount) true false)]
       [(savings-account? anaccount) (check-for-avaiability anaccount amount)]))

(define(check-for-avaiability anaccount amount)
  (if (>=(savings-account-current-balance anaccount)(check-withdraw-status anaccount amount)) true false))
(define(check-withdraw-status anaccount amount)
  (if(> (savings-account-number-of-withdrawls anaccount) limit-of-withdrawls-before-paying)(+ amount (* amount fee-over-the-lim)) amount))

;;signature withdraw: account amount -> account
;purpose:
;checking-account it return the ammount minus the withdraw
;savings-account it returns the ammount minus the withdraw if fees are applaiable then it diminuscis the balance

;test
(check-expect(withdraw checking-account3 50000)checking-account3)
(check-expect(withdraw checking-account3 5000)
             (make-checking-account (checking-account-name checking-account3)
                                            5000 monthly-int-rate))
(check-expect(withdraw savings-account4  50000)savings-account4 )
(check-expect(withdraw savings-account2  5000)(make-savings-account "Antonio" 5000  15 fee-over-the-lim limit-of-withdrawls-before-paying ) )
(check-expect(withdraw savings-account5  5000)(make-savings-account "Antonio" 4950  21 fee-over-the-lim limit-of-withdrawls-before-paying ))
(check-expect(withdraw savings-account3  50000) savings-account5)

;define
(define checking-account3(make-checking-account "Thomas" 10000 monthly-int-rate))
(define savings-account4(make-savings-account "Antonio" 10000  15 fee-over-the-lim limit-of-withdrawls-before-paying ))
(define savings-account5(make-savings-account "Antonio" 10000  21 fee-over-the-lim limit-of-withdrawls-before-paying ))

;definition
(define (withdraw anaccount amount)
  (cond[(checking-account? anaccount) (if(and (enough-funds anaccount amount) true)
                      (make-checking-account (checking-account-name anaccount)
                                             (-(checking-account-current-balance anaccount) amount) monthly-int-rate) anaccount)]
       [(savings-account? anaccount) (if(and(enough-funds anaccount amount) true)
            (make-savings-account (savings-account-name anaccount)  
                                    (-(savings-account-current-balance anaccount)(check-withdraw-status anaccount amount)) 
                                             (savings-account-number-of-withdrawls anaccount) 
                                                  fee-over-the-lim limit-of-withdrawls-before-paying) anaccount)]))  


