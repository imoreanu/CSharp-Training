SELECT * FROM students_teachers
WHERE id = '1';

SELECT * FROM univ_students
ORDER BY age DESC;

SELECT *
FROM
    univ_students
INNER JOIN
    students_teachers
ON
    univ_students.student_id = students_teachers.id;

UPDATE univ_students
SET name = 'Alfred', age = '23'
WHERE student_id = 1;

INSERT INTO univ_students (student_id, name, gender, age, major)
VALUES
('13', 'Mitch', 'male', '39', 'Music'),
('14', 'Michelle', 'female', '21', 'Computer Science');

DELETE FROM univ_students 
WHERE 
name = 'Mitch';


