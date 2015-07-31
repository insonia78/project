;; The first three lines of this file were inserted by DrRacket. They record metadata
;; about the language level of this file in a form that our tools can easily process.
#reader(lib "htdp-intermediate-lambda-reader.ss" "lang")((modname |program 1|) (read-case-sensitive #t) (teachpacks ()) (htdp-settings #(#t constructor repeating-decimal #f #t none #f ())))
(define-struct vote (choice1 choice2 choice3)) 
;;Vote is a structure(make-vote String String String)
;;interp. a name, a name, a name;

;;define canditates variables
(define one "A")
(define two "B")
(define three "C")
(define four "D")
(define five "E")

;;list of canditates
;-empty
;- (cons String empty)
(define candidates(list one two three four five))

;list of votes
;-empty
;(cons make-vote)
(define votes(list (make-vote five two three) 
                   (make-vote five three four) 
                   (make-vote two three four) 
                   (make-vote five four one)
                   (make-vote five three one) ))

;signature top-votes-for : list-of-votes string -> number
;purpose it returns the number of vote for the first choice

;test
(check-expect (top-votes-for votes one)0)
(check-expect (top-votes-for votes two)1)
(check-expect (top-votes-for votes three)0)
(check-expect (top-votes-for votes four)0)
(check-expect (top-votes-for votes five)4)

;define

(define (top-votes-for alist name)
  (cond
      [(empty? alist)0]
      [(string=? (vote-choice1 (first alist)) name)  (+ 1 (top-votes-for(rest alist) name))]
      [else (top-votes-for(rest alist) name)]))


;signature top-two-votes : list-of-votes string -> number
;purpose it returns the number of votes for the first two choices

;test
(check-expect (top-two-votes votes one)0)
(check-expect (top-two-votes votes two)2)
(check-expect (top-two-votes votes three)3)
(check-expect (top-two-votes votes four)1)
(check-expect (top-two-votes votes five)4)
;define
(define (top-two-votes alist name)
   (cond[(empty? alist)0]
        [(string=? (vote-choice1 (first alist)) name) (+ 1 (top-two-votes(rest alist) name))]
        [(string=? (vote-choice2 (first alist)) name) (+ 1(top-two-votes (rest alist) name))]
        [else (top-two-votes(rest alist) name)]))

;signature total-points-for : list-of-votes string -> number
;purpose it returns the total points from the position of the choice of the vote

;test
(check-expect (total-points-for votes one)2)
(check-expect (total-points-for votes two)5)
(check-expect (total-points-for votes three)7)
(check-expect (total-points-for votes four)4)
(check-expect (total-points-for votes five)12)

;define
(define (total-points-for alist name)
  (cond[(empty? alist)0]
       [(string=? (vote-choice1 (first alist)) name) (+ 3(total-points-for(rest alist) name))]
       [(string=? (vote-choice2 (first alist))name) (+ 2(total-points-for(rest alist) name))]
       [(string=? (vote-choice3 (first alist))name) (+ 1(total-points-for(rest alist) name))]
       [else (total-points-for(rest alist) name)]))



;; problem is here
;; it accepts a list of candidates and a list of votes that are defined in the top of the program 
(define-struct voting-tally(name n-of-votes))

;;a Voting-Tally is a structure(make-voting-Tally String number)
;; interp. a name, a number of votes

;;list of voting-tally
;-empty
;- (cons String number empty)


;;signature eliminate-no-votes: list-of-voting-tally -> list-of-voting-tally 
;; purpose it eliminates those candidates that have no vote


(define (eliminate-no-votes alist)
  (cond [(empty? alist)empty]
        [(> (voting-tally-n-of-votes (first alist)) 0) (cons (make-voting-tally (voting-tally-name (first alist)) (voting-tally-n-of-votes (first alist)))  (eliminate-no-votes(rest alist)))]
        [else (eliminate-no-votes (rest alist))]))
;;signature tally-by-all: list-of-canditates list-of-votes -> list-of-votting-tally
;;purpose: it creates a voting-tally-list with the top-votes

;test
(check-expect(tally-by-all-list candidates votes)(list(make-voting-tally "B" 1)
                                                      (make-voting-tally "E" 4)))
;define                                                      
(define (tally-by-all alist avotes)
  (tally-by-list top-votes-for alist avotes))    
;define 
;signature tally-by-all-list :list-of-canditates list-of-votes -> list-of-voting-tally
;purpose it creates a list of votting-tally by first-wins-all 
(define (tally-by-all-list alist avotes)
    (eliminate-no-votes (tally-by-all alist avotes)))
  
;;signature tally-by-approval: list-of-canditates list-of-votes -> list-of-votting-tally
;;purpose:it returns a list aof vatting tally by the first two canditates receive points

;test
(check-expect (tally-by-approval-list candidates votes)(list
                                                       (make-voting-tally "B" 2)
                                                       (make-voting-tally "C" 3)
                                                       (make-voting-tally "D" 1)
                                                       (make-voting-tally "E" 4)))


;define
(define (tally-by-approval alist avotes)
  (tally-by-list top-two-votes alist avotes))  
     
     
;define
;signature tally-by-approval-list:list-of-canditates list-of-votes -> list-of-votting-tally
;it eliminates those candidates that dont receive a vote

(define (tally-by-approval-list alist avotes)
  (eliminate-no-votes(tally-by-approval alist avotes)))
  
;;signature tally-by-place-points:list-of-canditates list-of-votes -> list-of-votting-tally
;it eliminates those candidates that dont receive a vote

;test
(check-expect (tally-by-place-points-list candidates votes)(list
                                                           (make-voting-tally "A" 2)
                                                           (make-voting-tally "B" 5)
                                                           (make-voting-tally "C" 7)
                                                           (make-voting-tally "D" 4)
                                                           (make-voting-tally "E" 12)))
;define
(define (tally-by-place-points alist avotes)
  (tally-by-list total-points-for alist avotes))  
     
      
;define
;;signature tally-by-place-points-list :list-of-canditates list-of-votes -> list-of-votting-tally
;;purpose it eliminates those candidates that dont have a vote
(define (tally-by-place-points-list alist avotes)
         (eliminate-no-votes (tally-by-place-points candidates votes)))


;signature compare-vote-types; a-list-of-voting-tally  list-of-voting-tally -> Number
;purpose: it compares two voting-tally list and returns the discrepancy from the two vote strategies  

;signature number-of-people-voting: list-of-votes -> Number
;purpose it returns the number of people voting 


;signature tally-by:  function list-of-names list-of-votes -> list-of-voting-tally
;purpose  it creates an abstract function  
(define (tally-by  R alist avotes)
  (cond
     [(empty? alist)empty]
     [(empty? avotes)empty]
     [else (cons (make-voting-tally (first alist) (R votes (first alist)))(tally-by R (rest alist) (rest avotes)))]))

;signature tally-by-list : function list-of-canditates list-of votes -> list-of-votting-tally
;purpose: it eliminates those votes that are == to 0 ad creates a list of voting tally
(define (tally-by-list R alist avotes)
         (eliminate-no-votes (tally-by R candidates votes)))


;signature highestscore: list-of-voting-tally list-of-voting-tally -> list-of-voting-tally
;purpose retrives the voting-tally whit the most points 

;helper function: createlistofnumbers:  list-of-votting-tally -> list-of-numbers
;purpose: creates a list-of-numbers  from the votes of the voting tally 

;helper function sorting : list-of-numbers -> list-of-numbers
;purpose sorts in discending order the list of numbers

(check-expect(highestscore (sorting (createlistofnumbers( tally-by-place-points-list candidates votes))) ( tally-by-place-points-list candidates votes))(list (make-voting-tally "E" 12)))

 
  (define (createlistofnumbers alist)
    (cond
      [(empty? alist)alist]
      [else (cons(voting-tally-n-of-votes (first alist)) (createlistofnumbers (rest alist)))]))
  
  (define(sorting alist1)
    (sort alist1 >))
  
 
 
 (define (highestscore alist1 alist2)
   (cond
     [(empty? alist2)empty]
     [(= (first alist1) (voting-tally-n-of-votes(first alist2)))(cons (first alist2)(highestscore alist1 (rest alist2)))]
     [else (highestscore alist1 (rest alist2))]))
    

 
;signature winner-by-all: list-of-candidates list-of-votes -> string
;purpose it returns the winner by the process of winner by all scheme

;test
(check-expect (winner-by-all candidates votes)"E")
 

(define(winner-by-all alist avotes)
  (voting-tally-name (first (highestscore (sorting (createlistofnumbers(tally-by-all-list alist avotes)))(tally-by-all-list alist avotes)))))
 
;signature winner-by-approval: list-of-candidates list-of-votes -> string
;purpose it returns the winner by winner by approval scheme

;test
(check-expect (winner-by-approval candidates votes)"E")
 
(define(winner-by-approval alist avotes)
  (voting-tally-name (first (highestscore (sorting (createlistofnumbers(tally-by-approval-list alist avotes)))(tally-by-approval-list alist avotes)))))

;signature winner-by-points-per-place: list-of-candidates list-of-votes -> string
;purpose it returns the winner by winner-by-points-per-place scheme

;test
(check-expect (winner-by-points-per-place candidates votes)"E")
 
(define(winner-by-points-per-place alist avotes)
  (voting-tally-name (first (highestscore (sorting (createlistofnumbers(tally-by-place-points-list alist avotes)))(tally-by-place-points-list alist avotes)))))

;signature winner-all: list-of-candidates list-of-votes -> string
;purpose it uses a abstraction to calculate the differenet winning schemes 
;test
(check-expect (winner-by tally-by-place-points-list candidates votes )"E")
(check-expect (winner-by tally-by-approval-list candidates votes)"E")
(check-expect (winner-by tally-by-all-list candidates votes)"E")

(define (winner-by  R alist avotes)
    (voting-tally-name (first (highestscore (sorting (createlistofnumbers( R alist avotes)))(R alist avotes)))))     
     
     
