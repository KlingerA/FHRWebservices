﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreTesting.Domain.Domain;
using AspNetCoreTesting.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTesting.Api.CourseManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDbContext _dbContext;

        public CoursesController(UniversityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var courses = await _dbContext.Courses.ToListAsync();
            return Ok(courses);
        }
    }
}
