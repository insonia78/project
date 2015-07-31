# View vstudent joins grade_event, student and score tables
# to display the students that have completed quizzes
# and tests with the scores received for them.
DROP VIEW IF EXISTS vstudent;
CREATE VIEW vstudent AS
SELECT student.student_id, name, date, score, category
FROM grade_event INNER JOIN score INNER JOIN student
ON grade_event.event_id = score.event_id
AND score.student_id = student.student_id
ORDER BY name;