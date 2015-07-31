TYPE=VIEW
query=select `sampdb`.`student`.`student_id` AS `student_id`,`sampdb`.`student`.`name` AS `name`,`sampdb`.`grade_event`.`date` AS `date`,`sampdb`.`score`.`score` AS `score`,`sampdb`.`grade_event`.`category` AS `category` from ((`sampdb`.`grade_event` join `sampdb`.`score`) join `sampdb`.`student` on(((`sampdb`.`grade_event`.`event_id` = `sampdb`.`score`.`event_id`) and (`sampdb`.`score`.`student_id` = `sampdb`.`student`.`student_id`)))) order by `sampdb`.`student`.`name`
md5=4e32231e4632f56fd81b3ed0d20cd19f
updatable=1
algorithm=0
definer_user=root
definer_host=localhost
suid=2
with_check_option=0
timestamp=2015-01-11 20:38:23
create-version=1
source=SELECT student.student_id, name, date, score, category\nFROM grade_event INNER JOIN score INNER JOIN student\nON grade_event.event_id = score.event_id\nAND score.student_id = student.student_id\nORDER BY name
client_cs_name=utf8
connection_cl_name=utf8_general_ci
view_body_utf8=select `sampdb`.`student`.`student_id` AS `student_id`,`sampdb`.`student`.`name` AS `name`,`sampdb`.`grade_event`.`date` AS `date`,`sampdb`.`score`.`score` AS `score`,`sampdb`.`grade_event`.`category` AS `category` from ((`sampdb`.`grade_event` join `sampdb`.`score`) join `sampdb`.`student` on(((`sampdb`.`grade_event`.`event_id` = `sampdb`.`score`.`event_id`) and (`sampdb`.`score`.`student_id` = `sampdb`.`student`.`student_id`)))) order by `sampdb`.`student`.`name`
