package com.example.datingSite.repository;


import org.springframework.data.jpa.repository.JpaRepository;

import com.example.datingSite.model.Member;

public interface MemberRepository extends JpaRepository<Member,Long> {
    
}
