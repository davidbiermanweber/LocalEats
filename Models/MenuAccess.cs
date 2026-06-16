namespace UserAuthApp.Models
{
    public class MenuAccess
    {
        public int id { get; set; }
        public int user_id { get; set; } 
        public int menu_item_id { get; set; }
        bool can_view {get; set;}
    }
}
