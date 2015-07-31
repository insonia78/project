TYPE=VIEW
query=select `l7sampdb`.`president`.`last_name` AS `last_name`,`l7sampdb`.`president`.`first_name` AS `first_name`,`l7sampdb`.`president`.`birth` AS `birth`,timestampdiff(YEAR,`l7sampdb`.`president`.`birth`,`l7sampdb`.`pres_term`.`term_start_date`) AS `age` from (`l7sampdb`.`pres_term` join `l7sampdb`.`president` on((`l7sampdb`.`president`.`pres_id` = `l7sampdb`.`pres_term`.`pres_id`))) group by `age`
md5=e7d10899dbcb71313f34c62cd8e43276
updatable=0
algorithm=0
definer_user=root
definer_host=localhost
suid=1
with_check_option=0
timestamp=2015-02-09 02:28:09
create-version=1
source=select `president`.`last_name` AS `last_name`,`president`.`first_name` AS `first_name`,`president`.`birth` AS `birth`,timestampdiff(YEAR,`president`.`birth`,`pres_term`.`term_start_date`) AS `age` from (`pres_term` join `president` on((`president`.`pres_id` = `pres_term`.`pres_id`))) group by `age`
client_cs_name=utf8
connection_cl_name=utf8_general_ci
view_body_utf8=select `l7sampdb`.`president`.`last_name` AS `last_name`,`l7sampdb`.`president`.`first_name` AS `first_name`,`l7sampdb`.`president`.`birth` AS `birth`,timestampdiff(YEAR,`l7sampdb`.`president`.`birth`,`l7sampdb`.`pres_term`.`term_start_date`) AS `age` from (`l7sampdb`.`pres_term` join `l7sampdb`.`president` on((`l7sampdb`.`president`.`pres_id` = `l7sampdb`.`pres_term`.`pres_id`))) group by `age`
