DROP TABLE IF EXISTS pres_term;

create table  pres_term
(
  pres_id  int unsigned NOT NULL,
  term_start_date date NOT NULL,
  term_End_date   date  NULL,
  number_of_election_won int NOT NULL,
  reason_for_leaving_office   text  NULL,
  term_id int unsigned not null auto_increment,
  primary key ( pres_id,term_id),
  foreign key (term_id) references president(pres_id)

     
);