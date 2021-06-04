package com.perscholas.springboot.myboot.hello;
import java.util.List;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface StudentRepository extends JpaRepository<Student, Long>{
	
	Student findByAccountNo(Long accountNo);
    List<Student> findByNameContaining(String name);
}
