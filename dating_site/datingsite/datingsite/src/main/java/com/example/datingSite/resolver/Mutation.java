package com.example.datingSite.resolver;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import graphql.GraphQLException;
import graphql.kickstart.tools.GraphQLMutationResolver;
import javassist.NotFoundException;

import java.util.ArrayList;
import java.util.Optional;
import java.util.regex.Pattern;

import com.example.datingSite.model.*;
import com.example.datingSite.repository.*;

enum HairColor{
  BROWN("Brown"),
  BLACK("Black"),
  WHITE("White"),
  SANDY("Sandy"),
  GRAY_OR_PARTIALLY_GRAY("Gray or Partially Gray"),
  RED("Red"),
  BLOND("Blond"),
  BLUE("Blue"),
  GREEN("Green"),
  ORANGE("Orange"),
  PINK("Pink"),
  PURPLE("Purple"),
  BALD("Bald"),
  OTHER("Other");


  private String value;

  HairColor(final String value) {
      this.value = value;
  }

  public String getValue() {
      return value;
  }

  @Override
  public String toString() {
      return this.getValue();
  }
}
enum EyeColor{
  BROWN("Brown"),
  BLACK("Black"),  
  BLUE("Blue"),
  GRAY("Gray"),
  GREEN("Green"),
  HAZEL("Hazel"),
  PINK("Pink"),
  MAROON("Maroon"),
  MULTICOLORED("Multicolored"),
  OTHER("Other");


  private String value;

  EyeColor(final String value) {
      this.value = value;
  }

  public String getValue() {
      return value;
  }

  @Override
  public String toString() {
      return this.getValue();
  }
 }
 enum Etnicity{
  BLACK("Black"),  
  WHITE("White"),
  ASIAN("Asian"),
  MIXEDORMULTIPLEETHNICGROUP("Mixed or Multiple ethnic groups"),
  OTHERETHNICGROUP("Other ethnic groups");


  private String value;

  Etnicity(final String value) {
      this.value = value;
  }

  public String getValue() {
      return value;
  }

  @Override
  public String toString() {
      return this.getValue();
  }
 }

@Component
public class Mutation implements GraphQLMutationResolver {
  private CharacteristicsRepository characteristicsRepository;
  private PhotosRepository photosRepository;
  private MemberRepository memberRepository;

  @Autowired
  public Mutation(CharacteristicsRepository characteristicsRepository, PhotosRepository photosRepository,
      MemberRepository memberRepository) {
    this.characteristicsRepository = characteristicsRepository;
    this.photosRepository = photosRepository;
    this.memberRepository = memberRepository;
  }

  public Photos createPhotos(ArrayList<String> photos_path) {
    Photos photo = new Photos();
    photo.setPhoto_path(photos_path);
    this.photosRepository.save(photo);
    return photo;
  }

  public Photos updatePhotos(Long id, ArrayList<String> photo_path) throws NotFoundException {

    Optional<Photos> optPhotos = photosRepository.findById(id);

    if (optPhotos.isPresent()) {
      Photos photos = optPhotos.get();

      if (photo_path != null)
        photos.setPhoto_path(photo_path);

      photosRepository.save(photos);
      return photos;
    }

    throw new GraphQLException("Photos not found");
  }

  public boolean deletePhotos(Long id) {
    photosRepository.deleteById(id);
    return true;
  }

  public Member createMember(String email, String password) throws Exception {
    Member m = new Member();
    if (email != null) {
      String regex = "^[a-zA-Z0-9_!#$%&'*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$";
      Pattern pattern = Pattern.compile(regex);
      if (!pattern.matcher(email).matches())
        throw new GraphQLException("Email not valid");

      m.setEmail(email);
    }
    if (password != null) {
      String regex = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8, 20}$";
      Pattern pattern = Pattern.compile(regex);
      if (!pattern.matcher(email).matches())
        throw new GraphQLException("Password not valid");
      m.setPassword(password);
    }
    this.memberRepository.save(m);
    return m;
  }

  public Member updateMember(String email, String password) throws Exception {

    Optional<Member> member = memberRepository.findByEmail(email);

    if (member.isPresent()) {
      Member m = member.get();

      if (email != null) {
        String regex = "^[a-zA-Z0-9_!#$%&'*+/=?`{|}~^.-]+@[a-zA-Z0-9.-]+$";
        Pattern pattern = Pattern.compile(regex);
        if (!pattern.matcher(email).matches())
          throw new GraphQLException("Email not valid");

        m.setEmail(email);
      }
      if (password != null) {
        String regex = "^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&-+=()])(?=\\S+$).{8, 20}$";
        Pattern pattern = Pattern.compile(regex);
        if (!pattern.matcher(email).matches())
          throw new GraphQLException("Password not valid");
        m.setPassword(password);
      }
      memberRepository.save(m);
      return m;
    }
    throw new GraphQLException("Member not found");
  }

  public Boolean deleteMember(String email) {
      return memberRepository.deleteByEmail(email) .get();    
  }

  public Characteristics createCharacteristics(String email,String first_name, String middle_name, String last_name, String gender,
      Integer age, String hair_color, String eye_color, String height, String weight, String etnicity, String message) {
    Characteristics c = new Characteristics();
    Member m = c.getMember();
    

    if(email == null)
       throw new GraphQLException("Data is Missing");
    if(first_name == null)
      throw new GraphQLException("Data is Missing");
    if(last_name == null)
      throw new GraphQLException("Data is Missing");
    if(gender == null)
      throw new GraphQLException("Data is Missing");
    if(age == null)
      throw new GraphQLException("Data is Missing");
    if(hair_color == null)
      throw new GraphQLException("Data is Missing");
    if(eye_color == null)
      throw new GraphQLException("Data is Missing");
    if(height == null)
      throw new GraphQLException("Data is Missing");
    if(weight == null)
      throw new GraphQLException("Data is Missing");
    if(etnicity == null)
      throw new GraphQLException("Data is Missing");       

    if(email != null)
    {
         if(memberRepository.findByEmail(email).get() == null)
            throw new GraphQLException("Invalid Data"); 
         m.setEmail(email);    
    }
    if(first_name != null)
    {
      
      if (!first_name.toUpperCase().matches( "[A-Z]*" ))
        throw new GraphQLException("FirstName Invalid Format");
        c.setFirst_name(first_name);
    }
    
    if(middle_name != null)
    {
      
      if (!middle_name.toUpperCase().matches( "[A-Z]*" ))
        throw new GraphQLException("MiddleName Invalid Format");
        c.setMiddle_name(middle_name);
    }
    if(last_name != null)
    {
      if (!last_name.toUpperCase().matches( "[A-Z]*" ))
        throw new GraphQLException("LastName Invalid Format");
        c.setLast_name(last_name);
    }
    if(gender.equals("M") || gender.equals("F"))
       c.setGender(gender);
    if(!(gender.equals("M") || gender.equals("F")))
         throw new GraphQLException("Invalid Gender");
    
    if(age != null)       
    {
      if(age < 18 && age > 100)
         throw new GraphQLException("Age range is Invalid");    
      c.setAge(age);
    }
    if(hair_color.equals(HairColor.BALD.toString()) || hair_color.equals(HairColor.BLACK.toString()) || hair_color.equals(HairColor.BLOND.toString())
      || hair_color.equals(HairColor.BLUE.toString()) || hair_color.equals(HairColor.BROWN.toString()) || hair_color.equals(HairColor.GRAY_OR_PARTIALLY_GRAY.toString())
      || hair_color.equals(HairColor.GREEN.toString()) || hair_color.equals(HairColor.ORANGE.toString()) 
      || hair_color.equals(HairColor.OTHER.toString()) || hair_color.equals(HairColor.PINK.toString())
      || hair_color.equals(HairColor.PURPLE.toString()) || hair_color.equals(HairColor.RED.toString())
    ){
      c.setHair_color(hair_color);
    }
    if(!(hair_color.equals(HairColor.BALD.toString()) || hair_color.equals(HairColor.BLACK.toString()) || hair_color.equals(HairColor.BLOND.toString())
    || hair_color.equals(HairColor.BLUE.toString()) || hair_color.equals(HairColor.BROWN.toString()) || hair_color.equals(HairColor.GRAY_OR_PARTIALLY_GRAY.toString())
    || hair_color.equals(HairColor.GREEN.toString()) || hair_color.equals(HairColor.ORANGE.toString()) 
    || hair_color.equals(HairColor.OTHER.toString()) || hair_color.equals(HairColor.PINK.toString())
    || hair_color.equals(HairColor.PURPLE.toString()) || hair_color.equals(HairColor.RED.toString())
    )) {
      throw new GraphQLException("Hair color not valid");
    } 
    if(height.compareTo("2.1") >= 0 || height.compareTo("10.11") <= 0 )
    {
      c.setHeight(height);  
    }
    if(!(height.compareTo("2.1") >= 0 || height.compareTo("10.11") <= 0 ))
    {
        throw new GraphQLException("Height not in range");  
    }
    if(weight.compareTo("100.1") >= 0 || weight.compareTo("300.16") <= 0 )
    {
        c.setWeight(weight);   
    }
    if(!(weight.compareTo("100.1") >= 0 || weight.compareTo("300.16") <= 0 ))
    {
        throw new GraphQLException("Weight not in range");  
    }
    if(eye_color.equals(EyeColor.BLACK.toString()) || eye_color.equals(EyeColor.BLUE.toString()) || eye_color.equals(EyeColor.BROWN.toString())
      || eye_color.equals(EyeColor.GRAY.toString()) || eye_color.equals(EyeColor.GREEN.toString()) || eye_color.equals(EyeColor.HAZEL.toString())
      || eye_color.equals(EyeColor.MAROON.toString()) || eye_color.equals(EyeColor.MULTICOLORED.toString()) 
      || eye_color.equals(EyeColor.OTHER.toString()) || eye_color.equals(EyeColor.PINK.toString())
       
    ){
      c.setEye_color(eye_color);
    }
    c.setMessage(message);
    if(!(eye_color.equals(EyeColor.BLACK.toString()) || eye_color.equals(EyeColor.BLUE.toString()) || eye_color.equals(EyeColor.BROWN.toString())
      || eye_color.equals(EyeColor.GRAY.toString()) || eye_color.equals(EyeColor.GREEN.toString()) || eye_color.equals(EyeColor.HAZEL.toString())
      || eye_color.equals(EyeColor.MAROON.toString()) || eye_color.equals(EyeColor.MULTICOLORED.toString()) 
      || eye_color.equals(EyeColor.OTHER.toString()) || eye_color.equals(EyeColor.PINK.toString())
       
    )){
      throw new GraphQLException("Eye color not present");
    }
    if(etnicity.equals(Etnicity.ASIAN.toString()) || etnicity.equals(Etnicity.BLACK.toString())|| etnicity.equals(Etnicity.MIXEDORMULTIPLEETHNICGROUP.toString())
      || etnicity.equals(Etnicity.WHITE.toString())){
       c.setEtnicity(etnicity);
    }
    if(!(etnicity.equals(Etnicity.ASIAN.toString()) || etnicity.equals(Etnicity.BLACK.toString())|| etnicity.equals(Etnicity.MIXEDORMULTIPLEETHNICGROUP.toString())
      || etnicity.equals(Etnicity.WHITE.toString()))){
        throw new GraphQLException("Ethnicity wrong format");
    }
    this.characteristicsRepository.save(c);
    return c;
  }

  public Characteristics updateCharacteristics(Long id, String first_name, String middle_name, String last_name,
      String gender, Integer age, String hair_color, String eye_color, String height, String weight, String etnicity,
      String message) throws NotFoundException {
    Optional<Characteristics> optCharacteristics = characteristicsRepository.findById(id);
    
    if(first_name == null)
      throw new GraphQLException("Data is Missing");
    if(last_name == null)
      throw new GraphQLException("Data is Missing");
    if(gender == null)
      throw new GraphQLException("Data is Missing");
    if(age == null)
      throw new GraphQLException("Data is Missing");
    if(hair_color == null)
      throw new GraphQLException("Data is Missing");
    if(eye_color == null)
      throw new GraphQLException("Data is Missing");
    if(height == null)
      throw new GraphQLException("Data is Missing");
    if(weight == null)
      throw new GraphQLException("Data is Missing");
    if(etnicity == null)
      throw new GraphQLException("Data is Missing");
      
    if (optCharacteristics.isPresent()) {
      Characteristics c = optCharacteristics.get();      
    String names = "^([a-zA-Z]{2,}\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\s?([a-zA-Z]{1,})?)";
    
    if(first_name != null)
    {
      Pattern pattern = Pattern.compile(names);
      if (!pattern.matcher(first_name).matches())
        throw new GraphQLException("Invalid Format");
        c.setFirst_name(first_name);
    }
    if(middle_name != null)
    {
      Pattern pattern = Pattern.compile(names);
      if (!pattern.matcher(middle_name).matches())
        throw new GraphQLException("Invalid Format");
        c.setMiddle_name(middle_name);
    }
    if(last_name != null)
    {
      Pattern pattern = Pattern.compile(names);
      if (!pattern.matcher(last_name).matches())
        throw new GraphQLException("Invalid Format");
        c.setLast_name(last_name);
    }
    if(gender.equals("M") || gender.equals("F"))
       c.setGender(gender);
    if(!(gender.equals("M") || gender.equals("F")))
         throw new GraphQLException("Invalid Gender");
    
    if(age != null)       
    {
      if(age < 18 && age > 100)
         throw new GraphQLException("Age range is Invalid");    
      c.setAge(age);
    }
    if(hair_color.equals(HairColor.BALD.toString()) || hair_color.equals(HairColor.BLACK.toString()) || hair_color.equals(HairColor.BLOND.toString())
      || hair_color.equals(HairColor.BLUE.toString()) || hair_color.equals(HairColor.BROWN.toString()) || hair_color.equals(HairColor.GRAY_OR_PARTIALLY_GRAY.toString())
      || hair_color.equals(HairColor.GREEN.toString()) || hair_color.equals(HairColor.ORANGE.toString()) 
      || hair_color.equals(HairColor.OTHER.toString()) || hair_color.equals(HairColor.PINK.toString())
      || hair_color.equals(HairColor.PURPLE.toString()) || hair_color.equals(HairColor.RED.toString())
    ){
      c.setHair_color(hair_color);
    }
    if(!(hair_color.equals(HairColor.BALD.toString()) || hair_color.equals(HairColor.BLACK.toString()) || hair_color.equals(HairColor.BLOND.toString())
    || hair_color.equals(HairColor.BLUE.toString()) || hair_color.equals(HairColor.BROWN.toString()) || hair_color.equals(HairColor.GRAY_OR_PARTIALLY_GRAY.toString())
    || hair_color.equals(HairColor.GREEN.toString()) || hair_color.equals(HairColor.ORANGE.toString()) 
    || hair_color.equals(HairColor.OTHER.toString()) || hair_color.equals(HairColor.PINK.toString())
    || hair_color.equals(HairColor.PURPLE.toString()) || hair_color.equals(HairColor.RED.toString())
    )) {
      throw new GraphQLException("Hair color not valid");
    } 
    if(height.compareTo("2.1") >= 0 || height.compareTo("10.11") <= 0 )
    {
      c.setHeight(height);  
    }
    if(!(height.compareTo("2.1") >= 0 || height.compareTo("10.11") <= 0 ))
    {
        throw new GraphQLException("Height not in range");  
    }
    if(weight.compareTo("100.1") >= 0 || weight.compareTo("300.16") <= 0 )
    {
        c.setWeight(weight);   
    }
    if(!(weight.compareTo("100.1") >= 0 || weight.compareTo("300.16") <= 0 ))
    {
        throw new GraphQLException("Weight not in range");  
    }
    if(eye_color.equals(EyeColor.BLACK.toString()) || eye_color.equals(EyeColor.BLUE.toString()) || eye_color.equals(EyeColor.BROWN.toString())
      || eye_color.equals(EyeColor.GRAY.toString()) || eye_color.equals(EyeColor.GREEN.toString()) || eye_color.equals(EyeColor.HAZEL.toString())
      || eye_color.equals(EyeColor.MAROON.toString()) || eye_color.equals(EyeColor.MULTICOLORED.toString()) 
      || eye_color.equals(EyeColor.OTHER.toString()) || eye_color.equals(EyeColor.PINK.toString())
       
    ){
      c.setEye_color(eye_color);
    }
    c.setMessage(message);
    if(!(eye_color.equals(EyeColor.BLACK.toString()) || eye_color.equals(EyeColor.BLUE.toString()) || eye_color.equals(EyeColor.BROWN.toString())
      || eye_color.equals(EyeColor.GRAY.toString()) || eye_color.equals(EyeColor.GREEN.toString()) || eye_color.equals(EyeColor.HAZEL.toString())
      || eye_color.equals(EyeColor.MAROON.toString()) || eye_color.equals(EyeColor.MULTICOLORED.toString()) 
      || eye_color.equals(EyeColor.OTHER.toString()) || eye_color.equals(EyeColor.PINK.toString())
       
    )){
      throw new GraphQLException("Eye color not present");
    }
    if(etnicity.equals(Etnicity.ASIAN.toString()) || etnicity.equals(Etnicity.BLACK.toString())|| etnicity.equals(Etnicity.MIXEDORMULTIPLEETHNICGROUP.toString())
      || etnicity.equals(Etnicity.WHITE.toString())){
       c.setEtnicity(etnicity);
    }
    if(!(etnicity.equals(Etnicity.ASIAN.toString()) || etnicity.equals(Etnicity.BLACK.toString())|| etnicity.equals(Etnicity.MIXEDORMULTIPLEETHNICGROUP.toString())
      || etnicity.equals(Etnicity.WHITE.toString()))){
        throw new GraphQLException("Ethnicity wrong format");
    }
    this.characteristicsRepository.save(c);
    return c;
    }

    throw new GraphQLException("Characteristics not found");
  }

  public boolean deleteCharacteristics(Long id) {
    characteristicsRepository.deleteById(id);
    return true;
  }

}
