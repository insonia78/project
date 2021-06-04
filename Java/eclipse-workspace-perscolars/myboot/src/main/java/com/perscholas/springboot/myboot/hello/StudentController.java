package com.perscholas.springboot.myboot.hello;

import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class StudentController {

	@Autowired
	private StudentRepository studentRepository;

	@GetMapping("/students")
	public List <Student> getAllStudents() {
		List<Student> students = studentRepository.findAll();
        return students;
    }
	
	 @GetMapping("/students/{accountNo}")
	  Student findStudent(@PathVariable Long accountNo) {

	    return studentRepository.findByAccountNo(accountNo);
	  }
}
