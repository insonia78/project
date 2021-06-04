package com.perscholas.springdatajpa.repository;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import com.perscholas.springdatajpa.models.Book;

@Repository
public interface BookRepository extends CrudRepository<Book, Integer> {
	Book findById(Long id);
	Book findByTitle(String title);
}
