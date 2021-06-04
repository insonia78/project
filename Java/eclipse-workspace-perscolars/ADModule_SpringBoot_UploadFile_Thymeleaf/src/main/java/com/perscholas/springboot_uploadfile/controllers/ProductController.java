package com.perscholas.springboot_uploadfile.controllers;

import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;

import com.perscholas.springboot_uploadfile.models.Product;

@Controller
public class ProductController {

	@GetMapping("/")
	public String inputProduct(Model model) {
		model.addAttribute("product", new Product());
		return "product_form";
//		return "index";
	}
	
	@PostMapping("/saveProduct")
	public String fileUpload(@RequestParam("images") MultipartFile [] files,
			Model model, Product product, RedirectAttributes redirect) throws IOException {
		System.out.println("fileUpload method.");
		System.out.println("Product Name: " + product.getName());
		String uploadDir = "/Users/Charlie/Documents/Programming/Per Scholas/ClassroomWorkspace/ADModule_SpringBoot_UploadFile_Thymeleaf/src/main/resources/static/images";
		
		for (MultipartFile file : files) {
			if (!file.getOriginalFilename().isEmpty()) {
				System.out.println("file.getOriginalFilemane is not empty.");
				System.out.println(file.getOriginalFilename());
				BufferedOutputStream outputStream = new BufferedOutputStream(
						new FileOutputStream(
								new File(uploadDir, file.getOriginalFilename())));
				outputStream.write(file.getBytes());
				outputStream.flush();
				outputStream.close();
			} else {
				redirect.addFlashAttribute("msg", "Please select at least one file..");
				return "redirect:./";
			}
		}
		model.addAttribute("msg", "Multiple files uploaded successfully");
		model.addAttribute("product", product);
		return "view_product_detail";
	}
}