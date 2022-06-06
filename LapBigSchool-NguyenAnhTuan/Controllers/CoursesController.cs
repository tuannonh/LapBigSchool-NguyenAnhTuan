﻿using LapBigSchool_NguyenAnhTuan.Models;
using LapBigSchool_NguyenAnhTuan.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LapBigSchool_NguyenAnhTuan.Controllers
{
    
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Courses
        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel();
            {
                viewModel.Categories = _dbContext.Categories.ToList();
            }
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(CourseViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                viewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", viewModel);
            }    
            var course = new Course
            {
                LectureId = User.Identity.GetUserId(),
                DateTime = viewModel.GetDateTime(),
                CategoryId = viewModel.Category,
                Place = viewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}