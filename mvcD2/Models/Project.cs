﻿namespace mvcD2.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Emp_project> Emp { get; set; }
    }
}
