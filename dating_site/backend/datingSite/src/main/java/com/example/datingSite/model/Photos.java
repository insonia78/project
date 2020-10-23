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
     
    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "characteristics_id")
    private Characteristics characteristics;

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
    public Characteristics getCharacteristics() {
        return characteristics;
    }

    public void setCharacteristics(Characteristics characteristics) {
        this.characteristics = characteristics;
    }

    public Photos(ArrayList<String> photo_path, Characteristics characteristics) {
        this.photo_path = photo_path;
        this.characteristics = characteristics;
    }

}
