package com.example.datingSite.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

import com.example.datingSite.model.User;

public interface UserRepository extends JpaRepository<User, Long> {
    Optional<User> findByEmail(String email);
    boolean existsByEmail(String email);
}