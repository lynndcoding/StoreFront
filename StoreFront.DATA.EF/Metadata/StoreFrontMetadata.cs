using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//for validation and metadata
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreFront.DATA.EF//.Metadata
{
    class StoreFrontMetadata
    {
        #region BeerStyle Metadata
        public class BeerStyleMetadata
        {
            [Required]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Beer Style")]
            public string BeerStyle1 { get; set; }
        }
        [MetadataType(typeof(BeerStyleMetadata))]
        public partial class BeerStyle
        {
        }
        #endregion

        #region Customer Metadata


        public class CustomerMetadata
        {
            [Required(ErrorMessage = "**First Name is required**")]
            [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
            [Display(Name = "First Name")]
            public string CustFName { get; set; }
            [Required(ErrorMessage = "**Last Name is required**")]
            [StringLength(50, ErrorMessage = "Last Name cannot be more than 50 characters")]
            [Display(Name = "Last Name")]
            public string CustLName { get; set; }
            [StringLength(100, ErrorMessage = "Street Address cannot be more than 50 characters")]
            [DisplayFormat(NullDisplayText = "-N/A-")]
            [Display(Name = "Street Address")]
            public string CustStreetAddy { get; set; }
            [StringLength(50, ErrorMessage = "City cannot be more than 50 characters")]
            [Display(Name = "Customer City")]
            [DisplayFormat(NullDisplayText = "-N/A-")]
            public string CustCity { get; set; }
            [StringLength(2, ErrorMessage = "State must be 2 characters")]
            [DisplayFormat(NullDisplayText = "-N/A-")]
            [Display(Name = "Customer State")]
            public string CustState { get; set; }
            [DisplayFormat(NullDisplayText = "-N/A-")]
            [Display(Name = "Customer Zip Code")]
            public string CustZip { get; set; }
            [Required(ErrorMessage = "**Mug Club Membership Status is required**")]
            [Display(Name = "Are you a Mug Club Member Y/N?")]
            public bool IsMugClubMbr { get; set; }
            [DisplayFormat(NullDisplayText = "-N/A-")]
            [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
            [Display(Name = "First Name")]
            public string EmailAddy { get; set; }
        }

        //TODO:  FIX ERRORS HERE
        //[MetadataType(typeof(CustomerMetadata))]
        //public partial class Customer
        //{
        //    public string FullName
        //    {
        //        get { return CustFName + " " + CustLName; }
        //    }
        //}
        #endregion

        #region Employee Metadata

        public class EmployeeMetadata
        {
            [Required(ErrorMessage = "**First Name is required**")]
            [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
            [Display(Name = "First Name")]
            public string EEFirstName { get; set; }
            [Required(ErrorMessage = "**Last Name is required**")]
            [StringLength(50, ErrorMessage = "Last Name cannot be more than 50 characters")]
            [Display(Name = "Last Name")]
            public string EELastName { get; set; }

            public int DirectReportID { get; set; }//??????? NOT SURE IF NEED TO INCLUDE
            [Required(ErrorMessage = "**Direct Report is required**")]
            [StringLength(20, ErrorMessage = "Direct Report cannot be more than 20 characters")]
            [Display(Name = "Direct Report")]
            public string DirectReport { get; set; }
        }

        [MetadataType(typeof(EmployeeMetadata))]
        public partial class Employee
        {//TODO:  FIX ERRORS HERE
            //public string FullName
            //{
            //    get { return EEFirstName + " " + EELastName; }
            //}

        }
        #endregion

        #region Package Metadata

        public class PackageMetadata
        {
            [Required(ErrorMessage = "**Packaging is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Packaging - Quantity in Ounces")]
            public int PkgQty { get; set; }
            [Required(ErrorMessage = "**Price is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            public decimal Price { get; set; }
            [Required(ErrorMessage = "**Units Sold is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Units Sold")]
            public int UnitsSold { get; set; }
        }

        [MetadataType(typeof(PackageMetadata))]
        public partial class Package
        {

        }
        #endregion

        #region Product Metadata

        public class ProductMetadata
        {
            [Required(ErrorMessage = "**Beer Style is required**")]
            [Range(0, int.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Beer Style")]
            public int BeerStyleID { get; set; }
            [DisplayFormat(NullDisplayText = "-N/A-")]
            [StringLength(50, ErrorMessage = "First Name cannot be more than 50 characters")]
            [Display(Name = "Beer Name")]
            public string BeerName { get; set; }
            [Required(ErrorMessage = "**ABV is required**")]
            [Range(0, short.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Alcohol By Volume (ABV)")]
            public short ABVID { get; set; }
            [Display(Name = "Date Sole")]
            [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true, NullDisplayText = "-N/A-")]
            public System.DateTime DateSold { get; set; }
            [StringLength(50, ErrorMessage = "Label Image cannot be more than 100 characters")]
            [Display(Name = "Label Image")]
            public string BeerImage { get; set; }


            [Required(ErrorMessage = "**Units Sold is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Units Sold")]
            public int EmployeeID { get; set; }
            [Required(ErrorMessage = "**Units Sold is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Units Sold")]
            public int ProductID { get; set; }
            [Required(ErrorMessage = "**Units Sold is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Units Sold")]
            public int CustomerID { get; set; }
            [Required(ErrorMessage = "**Units Sold is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Units Sold")]
            public int DirectReportID { get; set; }
            [Required(ErrorMessage = "**Units Sold is required**")]
            [Range(0, double.MaxValue, ErrorMessage = "**Value must be a valid number, 0 or larger.**")]
            [Display(Name = "Units Sold")]
            public int PkgID { get; set; }
        }
        [MetadataType(typeof(ProductMetadata))]
        public partial class Product
        {

        }

        #endregion

        #region Status Metadata

        public class StatusMetadata
        {
            [Required(ErrorMessage = "**Product Status is required**")]
            [Display(Name = "Product Status")]
            public string ProductStatus { get; set; }

        }
        [MetadataType(typeof(StatusMetadata))]
        public partial class Status
        {

        }

        #endregion
    }
}
