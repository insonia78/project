;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-beginner-reader.ss" "lang")((modname |homework 3|) (read-case-sensitive #t) (teachpacks ((lib "image.rkt" "teachpack" "2htdp"))) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ((lib "image.rkt" "teachpack" "2htdp")))))

;Thomas Zangari
;Homework II
;;signature entry -> string
;;purpose: it consumes a entry and it returns the telephone number of it
;Data definition
;;entry: (make-entry string string string)
;;interp.: name, the telephone number , the email  

;test
(check-expect(getphonenumber data (entry-name data))"666-7771")
(check-expect(getphonenumber data "Sarah Wee")"No phone with that name")
;definition
(define-struct entry(name phone email))

(define data(make-entry "Sarah Lee" "666-7771" "lee@classy-university.edu"))

(define (getphonenumber d name)
  (cond[(string=? (entry-name d) name) (entry-phone d)]
       [else "No phone with that name"]))

 

;;signature entry number -> string  
;;purpose: it consumes a entry and a number and it returns a shorter string
;;Data Definition
;;entry: (make-entry string string string)
;;interp.: name, the telephone number , the email  

;test

(check-expect(shortenname data 5)"Sarah")
(check-expect(shortenname data 3)"Sar")
;definition
(define (shortenname d length)
  (substring (entry-name d) 0 length))


;;signature bid-evaluation: string number auction-entry -> auction-entry
;;purpose: it evaluates if the bid is open or clouse if it is open it process the offer
;;Data Definition
;;auction-entry: (make-auction-entry number string number string)
;;interp.: item number, name, price offered , the status of the bid 

;test 
(check-expect(current-offer-status "Thomas" 40.00 current-offer ) new-offer)
(check-expect(current-offer-status "thomas" 20.00 current-offer) (make-auction-entry 12345 "Antonio" 30.00 "Closed"))
(check-expect(current-offer-status "Thomas" 40.00 current-offer-closed) "The Bid is Closed")
(check-expect(current-offer-status "Thomas" -40.00 current-offer )"Invalid Entry")

;definition
(define-struct auction-entry(item-number name-of-highest-bid current-bid status))

  (define current-offer(make-auction-entry 12345 "Antonio" 30.00 "Open"))
  (define  new-offer (make-auction-entry 12345 "Thomas" 40.00 "Open"))
  (define current-offer-closed(make-auction-entry 12345 "Antonio" 30.00 "Closed"))

;; it first checks if the bid is open  
(define (current-offer-status name amount bid)
   (if (string=? (auction-entry-status bid) "Open") (bid-evaluation name amount bid) "The Bid is Closed")) 

 ;; it evaluates the new bid with the old bid   
(define (bid-evaluation name amount bid)  
  (cond [(< amount 0)"Invalid Entry"]
        [(> (auction-entry-current-bid bid) amount)(make-auction-entry (auction-entry-item-number bid) (auction-entry-name-of-highest-bid bid) (auction-entry-current-bid bid) "Closed")]
        [else (make-auction-entry (auction-entry-item-number bid) name amount "Open")])) 