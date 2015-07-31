;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-intermediate-lambda-reader.ss" "lang")((modname |project 2|) (read-case-sensitive #t) (teachpacks ()) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ())))

;a
;; larger-items : (listof number) number  ->  (listof number)
;; to create a list with all those numbers on alon  
;; that are larger than threshold
; list-of-numbers number ->
(define (smaller_or_larger R alon threshold)
 (cond
    [(empty? alon) empty]
    [else (if (R (first alon) threshold) 
	      (cons (first alon) (smaller_or_larger R (rest alon) threshold))
	      (smaller_or_larger R (rest alon) threshold))]))
  
   
;b
;; quick-sort : (listof number)  ->  (listof number)
;; to create a list of numbers with the same numbers as
;; alon sorted in ascending order
;; assume that the numbers are all distinct 

(check-expect(quick-sort numberlist) (list 1 2 4 9 11 12 14 18))

;define
(define numberlist(list 11 9 2 18 12 14 4 1) )

;; quick-sort : (listof number)  ->  (listof number)
;; to create a list of numbers with the same numbers as
;; alon sorted in ascending order
;; assume that the numbers are all distinct 
	   	  
 (define (quick-sort alon)
 (cond
 [(empty? alon) empty]
 [else (append (quick-sort (smaller_or_larger < alon (first alon)))
 (list (first alon))
 (quick-sort (smaller_or_larger > alon (first alon))))]))

    

  ( (lambda (x y)
 (+ (* x y) x))
1 2)

( (lambda (x y)
 (+ x
 ( local ((define x (* y y)))
 (+ (* 3 x) (/ 1 x)))))
1 2)

( (lambda (x y)
 (+ x
 ( (lambda (x)
(+ (* 3 x) (/ 1 x)))
 (* y y)) ))
1 2)

;; An plane is a (make-plane string number number boolean string)
(define-struct plane (ID miles-flown miles-since-checked problems? mechanic))
;An service-status is a(make-service-status string string)



(define planes-status(list(make-plane"1230" 150000 0 false "thomas")
                      (make-plane"1231" 150000 0 true "thomas")
                      (make-plane"1232" 150000 120000 false "thomas")
                      (make-plane"2340" 100000 0 false "thomas")
                      (make-plane"2341" 100000 80000 true "thomas")
                      (make-plane"2342" 80000 0 true "thomas")
                      (make-plane"2343" 80000 0 false "thomas")
                      (make-plane"3450" 1000 0 false "thomas")
                      (make-plane"3451" 10000 0 true "thomas")
                      (make-plane"3452" 10000 10000 false "thomas")
                      (make-plane "4123"100000 62000 false "thomas")))
                       
  
;signature service-priority: list-of-planes-status -> list-of-service-status
;purpose it accepts alist of planes status an returns a list of service status with the id of the 
;plane and the priority for service

;test
  
  (define (service-priority aplane)
  (cond
    [(or (plane-problems? aplane) (> (plane-miles-since-checked aplane) 100000)) "high"]
    [(and (not (plane-problems? aplane)) (>= 100000 (plane-miles-since-checked aplane) 50000)) "medium"]
    [else "low"]))

       

;signature findplanetoservice: list-of-planes-status string -> list-of-planes-status
;purpose it returns those airplains that match the service status
;helper function service status: it returns the list of priorities and the relative id of the plane

;test
(check-expect(findplanetoservice planes-status "high")(list
                                                       (make-plane "1231" 150000 0 true "thomas")
                                                       (make-plane "1232" 150000 120000 false "thomas")
                                                       (make-plane "2341" 100000 80000  true "thomas")
                                                       (make-plane "2342" 80000  0 true "thomas")
                                                       (make-plane "3451" 10000  0 true "thomas")))
(check-expect(findplanetoservice planes-status "medium")(list
                                                         (make-plane "4123" 100000 62000 false"thomas")))
(check-expect(findplanetoservice planes-status "low")(list 
                                                      (make-plane "1230" 150000 0 false "thomas")
                                                      (make-plane "2340" 100000 0 false  "thomas")
                                                      (make-plane "2343" 80000  0 false  "thomas")
                                                      (make-plane "3450" 1000 0 false "thomas")
                                                      (make-plane "3452" 10000 10000 false "thomas")))
 
             
(define(findplanetoservice alist status)
  (filter 
    (lambda(x)
      (string=? (service-priority  x) status))alist))       
             
             
;(define (findplanetoservice1 alist status)
 ;(map (lambda(x)
  ;      (first x))
   ;   (map
    ;   (lambda(x) ;; x is a service-status
     ;    (filter 
      ;    (lambda (y) ;; y is a plane
       ;     (string=?(plane-ID y) (service-status-Id x)))
        ;  alist))
       ;(filter  ;;; this is a list of service-status structures which have been filtered based on the input priority called status
        ;(lambda (x)
         ; (string=?(service-status-priority x) status))
        ;(service-priority alist)))))
       


 