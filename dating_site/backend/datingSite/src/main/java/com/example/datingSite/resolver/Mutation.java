package com.example.datingSite.resolver;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import javassist.NotFoundException;

import java.util.ArrayList;
import java.util.Optional;

import com.coxautodev.graphql.tools.GraphQLMutationResolver;
import com.example.datingSite.model.*;
import com.example.datingSite.repository.*;

public class Mutation implements GraphQLMutationResolver {
    private CharacteristicsRepository characteristicsRepository;
    private PhotosRepository photosRepository;
    
    @Autowired
    public Mutation(CharacteristicsRepository characteristicsRepository, PhotosRepository photosRepository) {
		this.characteristicsRepository = characteristicsRepository;
		this.photosRepository = photosRepository;
	}
    
    public Photos createPhotos(ArrayList<String> photos_path)
    {
        Photos photo = new Photos();
        photo.setPhoto_path(photos_path);
        this.photosRepository.save(photo);
        return photo;
    }
    
    public Photos updatePhotos(Long id , ArrayList<String> photo_path) throws NotFoundException {

        Optional<Photos> optPhotos = photosRepository.findById(id);
        
        if (optPhotos.isPresent()) {
            Photos photos = optPhotos.get();
      
            if ( photo_path != null)
                photos.setPhoto_path(photo_path);            
      
            photosRepository.save(photos);
            return photos;
          }
      
          throw new NotFoundException("Not found Photos to update!");
    }
    public boolean deletePhotos(Long id) {
        photosRepository.deleteById(id);
        return true;
    }
    public Characteristics createCharacteristics(String first_name,
    String middle_name,
    String last_name,
    String gender,
    Integer age,
    String hair_color,
    String eye_color,
    Double height,
    Double weight,
    String etnicity,
    String message)
    {
        Characteristics c = new Characteristics();
        c.setFirst_name(first_name);
        c.setLast_name(last_name);
        c.setMiddle_name(middle_name);
        c.setGender(gender);
        c.setAge(age);
        c.setHair_color(hair_color);
        c.setHeight(height);
        c.setWeight(weight);
        c.setMessage(message);
        c.setEye_color(eye_color);
        c.setEtnicity(etnicity);
        this.characteristicsRepository.save(c);
        return c;
    }
    
    public Characteristics updateCharacteristics(Long id ,String first_name,
    String middle_name,
    String last_name,
    String gender,
    Integer age,
    String hair_color,
    String eye_color,
    Double height,
    Double weight,
    String etnicity,
    String message) throws NotFoundException
    {
        Optional<Characteristics> optCharacteristics = characteristicsRepository.findById(id);
        
        if (optCharacteristics.isPresent()) {
            Characteristics c = optCharacteristics.get();
      
            if (first_name != null)
                c.setFirst_name(first_name);
            if(middle_name != null)
               c.setMiddle_name(middle_name);
            if( last_name != null)
               c.setLast_name(last_name);
            if( age != null)
              c.setAge(age);
            if( gender != null)
              c.setGender(gender);
            if( hair_color != null)
              c.setHair_color(hair_color);
            if( eye_color != null)
               c.setEye_color(eye_color);
            if( height != null)
               c.setHeight(height);
            if( weight != null)
               c.setWeight(weight);
            if( etnicity != null)
               c.setEtnicity(etnicity);
            if( message != null)
              c.setMessage(message);                                        
      
            characteristicsRepository.save(c);
            return c;
          }
      
          throw new NotFoundException("Not found Characteristics to update!");
    }
    public boolean deleteCharacteristics(Long id) {
        characteristicsRepository.deleteById(id);
        return true;
    }


}
