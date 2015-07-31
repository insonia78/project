SELECT
CONCAT(last_name, ', ', first_name),
TIMESTAMPDIFF(YEAR, birth, death) 
FROM president
WHERE
TIMESTAMPDIFF(YEAR, birth, death) > 65 AND DEATH IS NOT NULL
;