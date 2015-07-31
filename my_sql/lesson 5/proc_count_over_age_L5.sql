
DROP procedure if exists show_over_age;

delimiter $
create procedure show_over_age(anage int)
begin
select last_name, first_name, birth,death,age 
from pres_age
where age > anage   
order by age desc ; 
  
 
end $ 
delimiter ;