select  president.first_name,president.last_name,president.birth,
president.death,pres_term.term_start_date,pres_term.term_End_date,pres_term.reason_for_leaving_office
from  pres_term Inner join president 
on president.pres_id = pres_term.pres_id where  pres_term.term_End_date = president.death;