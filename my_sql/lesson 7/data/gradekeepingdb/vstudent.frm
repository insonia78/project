TYPE=VIEW
query=select `gradekeepingdb`.`student`.`student_id` AS `student_id`,`gradekeepingdb`.`student`.`name` AS `name`,`gradekeepingdb`.`grade_event`.`date` AS `date`,`gradekeepingdb`.`score`.`score` AS `score`,`gradekeepingdb`.`grade_event`.`category` AS `category` from ((`gradekeepingdb`.`grade_event` join `gradekeepingdb`.`score`) join `gradekeepingdb`.`student` on(((`gradekeepingdb`.`grade_event`.`event_id` = `gradekeepingdb`.`score`.`event_id`) and (`gradekeepingdb`.`score`.`student_id` = `gradekeepingdb`.`student`.`student_id`)))) order by `gradekeepingdb`.`student`.`name`
md5=434a76a6689de9c91905c1e0e70ece12
updatable=1
algorithm=0
definer_user=root
definer_host=localhost
suid=2
with_check_option=0
timestamp=2015-01-04 04:54:25
create-version=1
source=SELECT student.student_id, name, date, score, category\nFROM grade_event INNER JOIN score INNER JOIN student\nON grade_event.event_id = score.event_id\nAND score.student_id = student.student_id\nORDER BY name
client_cs_name=utf8
connection_cl_name=utf8_general_ci
view_body_utf8=select `gradekeepingdb`.`student`.`student_id` AS `student_id`,`gradekeepingdb`.`student`.`name` AS `name`,`gradekeepingdb`.`grade_event`.`date` AS `date`,`gradekeepingdb`.`score`.`score` AS `score`,`gradekeepingdb`.`grade_event`.`category` AS `category` from ((`gradekeepingdb`.`grade_event` join `gradekeepingdb`.`score`) join `gradekeepingdb`.`student` on(((`gradekeepingdb`.`grade_event`.`event_id` = `gradekeepingdb`.`score`.`event_id`) and (`gradekeepingdb`.`score`.`student_id` = `gradekeepingdb`.`student`.`student_id`)))) order by `gradekeepingdb`.`student`.`name`
