TYPE=VIEW
query=select `sampdb`.`president`.`last_name` AS `last_name`,`sampdb`.`president`.`first_name` AS `first_name`,`sampdb`.`president`.`birth` AS `birth`,timestampdiff(YEAR,`sampdb`.`president`.`birth`,`sampdb`.`pres_term`.`term_start_date`) AS `age` from (`sampdb`.`pres_term` join `sampdb`.`president` on((`sampdb`.`president`.`pres_id` = `sampdb`.`pres_term`.`pres_id`))) group by `age`
md5=19a48c6063587337b52e877a8359e220
updatable=0
algorithm=0
definer_user=root
definer_host=localhost
suid=1
with_check_option=0
timestamp=2015-02-09 02:23:05
create-version=1
source=select `president`.`last_name` AS `last_name`,`president`.`first_name` AS `first_name`,`president`.`birth` AS `birth`,timestampdiff(YEAR,`president`.`birth`,`pres_term`.`term_start_date`) AS `age` from (`pres_term` join `president` on((`president`.`pres_id` = `pres_term`.`pres_id`))) group by `age`
client_cs_name=utf8
connection_cl_name=utf8_general_ci
view_body_utf8=select `sampdb`.`president`.`last_name` AS `last_name`,`sampdb`.`president`.`first_name` AS `first_name`,`sampdb`.`president`.`birth` AS `birth`,timestampdiff(YEAR,`sampdb`.`president`.`birth`,`sampdb`.`pres_term`.`term_start_date`) AS `age` from (`sampdb`.`pres_term` join `sampdb`.`president` on((`sampdb`.`president`.`pres_id` = `sampdb`.`pres_term`.`pres_id`))) group by `age`
