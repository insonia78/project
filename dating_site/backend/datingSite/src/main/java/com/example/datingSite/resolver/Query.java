package com.example.datingSite.resolver;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import com.coxautodev.graphql.tools.GraphQLQueryResolver;
import com.example.datingSite.model.Characteristics;
import com.example.datingSite.repository.CharacteristicsRepository;

@Component
public class Query implements GraphQLQueryResolver {
    private CharacteristicsRepository characteristicsRepository;

    @Autowired
    public Query(CharacteristicsRepository characteristicsRepository)
    {
        this.characteristicsRepository = characteristicsRepository;
    }
    public Iterable<Characteristics> findAllCharacteristics() {
        return characteristicsRepository.findAll();
      }
}
