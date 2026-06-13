namespace UserAuthApp.Models
{
    public class MenuItem
    {
        public int id { get; set; }
        public string item_name { get; set; } = string.Empty;
        public string item_description { get; set; } = string.Empty;
        public decimal price { get; set; } 
        public string image_url { get; set; } = string.Empty;
        public int category_id { get; set; }
    }
}
