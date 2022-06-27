using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProductReviewManagement
{
    public class Management
    {
        private readonly DataTable dataTable = new DataTable();
        public void display(List<ProductReview> recordData)
        {
            foreach (var list in recordData)
            {
                Console.WriteLine("Product id = " + list.ProductId + "User id = " + list.UserId + "Rating is = " + list.Rating + " Review is = " + list.Review + " isLike = " + list.isLike);
            }
        }
        public void topRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews orderby productReview.Rating descending select productReview).Take(3).ToList();
            Console.WriteLine("\n Top 3 records = ");
            display(recordData);
        }
        public void selectedRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews where (productReview.ProductId == 1 || productReview.ProductId == 4 || productReview.ProductId == 9) && productReview.Rating > 3 select productReview).ToList();
            Console.WriteLine("\n Rating grater than 3 with product id 1,4,9 = ");
            display(recordData);
        }
        public void retrieveCountOfRecords(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            Console.WriteLine("\n Product id and count = ");
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + " = " + list.Count);
            }
        }
        public void retrieveProductdAndReview(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.Select(x => new { ProductId = x.ProductId, Review = x.Review });
            Console.WriteLine("\n Product id and review = ");
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + "----------" + list.Review);
            }
        }
        public void skipTopFiveRecords(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews select productReview).Skip(5).ToList();
            Console.WriteLine("\n Top 5 records from list = ");
            display(recordData);
        }
        public void productIDAndReviewUsingSelectLINQ(List<ProductReview> productReviews)
        {
            var recordData = productReviews.Select(reviews => new { ProductID = reviews.ProductId, Review = reviews.Review });
            Console.WriteLine("Product ID\t|\tReview");
            foreach (var list in recordData)
            {
                Console.WriteLine("\t" + list.ProductID + "\t|\t" + list.Review);
            }
        }
        public DataTable createTable(List<ProductReview> listProductReviews)
        {
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("UserId");
            dataTable.Columns.Add("Rating");
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike");
            return dataTable;
        }
        public void RetrieveRecordsWithIsLikeTrue(DataTable table)
        {
            var recordData = from productReview in table.AsEnumerable() where (productReview.Field<bool>("isLike") == true) select productReview;
            Console.WriteLine("Records with is like true = ");
            foreach (var lists in recordData)
            {
                Console.WriteLine("Product id = " + lists.Field<int>("ProductId") + "User id = " + lists.Field<int>("UserId") + "Rating is = " + lists.Field<double>("Rating") + " Review is = " + lists.Field<string>("Review") + " isLike = " + lists.Field<bool>("isLike"));
            }
        }
        public void findAvrageRating(List<ProductReview> listProductReviews)
        {
            var recordData = listProductReviews.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Average = x.Average(y => y.Rating) });
            foreach (var list in recordData)
            {
                Console.WriteLine(list.ProductId + "----------" + list.Average);
            }
        }
        public void recordsWithNiceReview(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews where (productReview.Review.Equals("Nice")) select productReview).ToList();
            Console.WriteLine("\n Records with nice review = ");
            display(recordData);
        }
        public void getRecordsWithUserIdTen(List<ProductReview> listProductReviews)
        {
            var recordData = (from productReview in listProductReviews where (productReview.UserId == 10) orderby productReview.Rating descending select productReview).ToList();
            Console.WriteLine("\n Records whose user id 10 with rating  = ");
            display(recordData);
        }
    }

}