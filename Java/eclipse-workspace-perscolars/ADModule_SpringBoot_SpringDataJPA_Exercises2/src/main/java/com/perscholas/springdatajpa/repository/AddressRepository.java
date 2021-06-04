package com.perscholas.springdatajpa.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.perscholas.springdatajpa.models.Address;

@Repository
public interface AddressRepository extends JpaRepository<Address, Long> {

}