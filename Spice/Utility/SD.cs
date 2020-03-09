using Spice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Utility
{
    public static class SD
    {
        public const string DefaultFoodImage = "default_food.png";
        public const string ManagerUser = "Manager";
        public const string KitchenUser = "Kitchen";
        public const string FrontDeskUser = "FrontDesk";
        public const string CustomerEndUser = "Customer";

        public const string ssCartCount = "ssCartCount";
		public const string ssCouponCode = "ssCouponCode";

		public const string StatusSubmitted = "Submitted";
		public const string StatusInProcess = "Being Prepared";
		public const string StatusReady = "Ready For Pickup";
		public const string StatusCompleted = "Completed";
		public const string StatusCanceled = "Canceled";

		public const string PaymentStatusPending = "Pending";
		public const string PaymentStatusApproved = "Approved";
		public const string PaymentStatusRejected = "Rejected";

















		public static string ConvertToRawHtml(string source)
		{
			char[] array = new char[source.Length];
			int arrayIndex = 0;
			bool inside = false;

			for (int i = 0; i < source.Length; i++)
			{
				char let = source[i];
				if (let == '<')
				{
					inside = true;
					continue;
				}
				if (let == '>')
				{
					inside = false;
					continue;
				}
				if (!inside)
				{
					array[arrayIndex] = let;
					arrayIndex++;
				}
			}
			return new string(array, 0, arrayIndex);
		}

		public static double DiscountedPrice(Coupon couponFromDb, double OriginalOrderTotal) 
		{
			if(couponFromDb == null)
			{
				return OriginalOrderTotal;
			}
			else
			{
				if (couponFromDb.MinimumAmount >  OriginalOrderTotal)
				{
					return OriginalOrderTotal;
				}
				else
				{
					//Everything is valid
					if(Convert.ToInt32(couponFromDb.CouponType)== (int)Coupon.ECouponType.Dollar)
					{
						//
						return Math.Round(OriginalOrderTotal - couponFromDb.Discount, 2);
					}

					if (Convert.ToInt32(couponFromDb.CouponType) == (int)Coupon.ECouponType.Percent)
					{
						//
						return Math.Round(OriginalOrderTotal - (OriginalOrderTotal * couponFromDb.Discount / 100), 2);
					}

				}
			}
			return OriginalOrderTotal;
		}
	}
}
