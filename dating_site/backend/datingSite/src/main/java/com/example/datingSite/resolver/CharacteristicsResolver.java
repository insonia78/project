package com.example.datingSite.resolver;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import com.example.datingSite.model.*;
import com.example.datingSite.repository.*;

import java.util.List;

import com.coxautodev.graphql.tools.GraphQLQueryResolver;

@Component
public class CharacteristicsResolver implements GraphQLQueryResolver {
    @Autowired
    private PhotosRepository photosRepository;
  
    public CharacteristicsResolver(CharacteristicsRepository characteristicsRepository) {
      this.photosRepository = photosRepository;
    }
  
    public List<Photos> getPhotos(Characteristics c) {
      return  photosRepository.findAll();
    }    

}
