using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaarChecker
{
    public struct QuickStatus
    {
        public string productId { set; get; }
        public decimal sellPrice { set; get; }
        public UInt32 sellVolume { set; get; }
        public UInt32 sellMovingWeek { set; get; }
        public UInt32 sellOrders { set; get; }
        public decimal buyPrice { set; get; }
        public UInt32 buyVolume { set; get; }
        public UInt32 buyMovingWeek { set; get; }
        public UInt32 buyOrders { set; get; }
    }

    public struct Summary
    {
        public UInt32 amount { set; get; }
        public decimal pricePerUnit { set; get; }
        public UInt32 orders { set; get; }
    }

    public struct Product
    {
        public string product_id { set; get; }
        public List<Summary> sell_summary { set; get; }
        public List<Summary> buy_summary { set; get; }
        public QuickStatus quick_status { set; get; }
    }

    public struct Bazaar
    {
        public bool success { set; get; }
        public UInt64 lastUpdated { set; get; }
        public SortedDictionary<string, Product> products { set; get; }
    }



    public struct Bid
    {
       public string auction_id { set; get; }
       public string bidder { set; get; }
       public string profile_id { set; get; }
       public decimal amount { set; get; }
       public UInt64 timestamp { set; get; }
    }

    public struct Auction
    {
        public string uuid { set; get; }
        public string auctioneer { set; get; }
        public string profile_id { set; get; }
        //public List<string> coop { set; get; }
        public UInt64 start { set; get; }
        public UInt64 end { set; get; }
        public string item_name { set; get; }
        public string item_lore { set; get; }
        public string extra { set; get; }
        public string category { set; get; }
        public string tier { set; get; }
        public decimal starting_bid { set; get; }
        //public string item_bytes { set; get; }
        public bool claimed { set; get; }
        //public List<string> claimed_bidders { set; get; }
        public decimal higest_bid_amount { set; get; }
        public UInt64 last_updated { set; get; }
        public bool bin { set; get; }
        public List<Bid> bids { set; get; }
    }

    public struct ActiveAuctions
    {
        public bool success { set; get; }
        public UInt16 page { set; get; }
        public UInt16 totalPages { set; get; }
        public UInt32 totalAuctions { set; get; }
        public UInt64 lastUpdated { set; get; }
        public List<Auction> auctions { set; get; }
    }



    public struct GroupedAuctions
    {
        public UInt64 LastUpdated { set; get; }
        public UInt32 TotalAuctions { set; get; }
        public SortedDictionary<string, List<Auction>> Auctions { set; get; }
    }
}
