namespace GymWebApp.Models.ViewModel
{
    public class OfferFilterViewModel
    {
        public PageResult<Offer> PagedOffers { get; set; }
        public string? SortOrder { get; set;}
        public string? FilterType { get; set; }
    }
}
