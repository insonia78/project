DROP VIEW IF EXISTS pres_age_in_office;
CREATE VIEW pres_age_in_office AS
SELECT  last_name, first_name, birth,
TIMESTAMPDIFF(YEAR,  president.birth, pres_term.term_start_date) AS age
from  pres_term Inner join president 
on president.pres_id = pres_term.pres_id group by age;
