package org.perscholas.springbootsoapexample.service;

import java.util.HashMap;
import java.util.Map;

import javax.annotation.PostConstruct;

import org.perscholas.springbootsoapexample.Student;
import org.springframework.stereotype.Service;

@Service
public class StudentService {

	
	//students map is a mock database for us for testing, can be replaced with a database
    private static final Map<String, Student> students = new HashMap<>();

    @PostConstruct
    public void initialize() {

        Student peter = new Student();
        peter.setName("Peter");
        peter.setStudentId(101);
        peter.setAge(21);

        Student maria = new Student();
        peter.setName("Maria");
        peter.setStudentId(102);
        peter.setAge(21);
        
        students.put(peter.getName(), peter);
        students.put(maria.getName(), maria);
    }

    public Student getStudents(String name) {
        return students.get(name);
    }
}
