﻿namespace Tangy_Models.LearnBlazorModels
{
    public class Demo_Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
        public List<Demo_ProductProp> ProductProperties { get; set; }
    }
}
