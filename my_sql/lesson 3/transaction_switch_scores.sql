start transaction;
update score set score = 13 where event_id = 5 and student_id = 8;
update score set score = 18 where event_id = 5 and student_id = 9;
commit;
select * from score where event_id = 5 and student_id in(8,9);

  