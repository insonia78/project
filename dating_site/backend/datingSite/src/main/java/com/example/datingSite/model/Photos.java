package com.example.datingSite.model;

import java.util.ArrayList;

import javax.persistence.*;


@Entity
public class Photos {

    @Id @GeneratedValue
    @Column(name = "photos_id", nullable = false)
    private Long id;
    
    @Column(name="photo_path")
    private ArrayList<String> photo_path;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public ArrayList<String> getPhoto_path() {
        return photo_path;
    }

    public void setPhoto_path(ArrayList<String> photo_path) {
        this.photo_path = photo_path;
    }

    public Photos() {
    }

    public Photos(ArrayList<String> photo_path) {
        this.photo_path = photo_path;
    }   

}
