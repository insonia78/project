package com.example.datingSite.repository;


import org.springframework.data.jpa.repository.JpaRepository;

import com.example.datingSite.model.Characteristics;

public interface CharacteristicsRepository extends JpaRepository<Characteristics,Long> {
    
}
