package com.example.datingSite.model;
import javax.validation.constraints.AssertTrue;
import javax.validation.constraints.Max;
import javax.validation.constraints.Min;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.validation.constraints.Email;

import javax.persistence.*;

@Entity
public class Member {

    @Id
    @Column(name = "email", nullable = false)    
    private String email;
       
    @Column(name = "password", nullable = false)
    private String password;    
    @OneToOne(fetch = FetchType.LAZY,cascade =  CascadeType.ALL, mappedBy = "member") 
    private Characteristics characteristics;
    
    public Member() {
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Characteristics getCharacteristics() {
        return characteristics;
    }

    public void setCharacteristics(Characteristics characteristics) {
        this.characteristics = characteristics;
    }

    public Member(String email, String password, Characteristics characteristics) {
        this.email = email;
        this.password = password;
        this.characteristics = characteristics;
    }

}
