using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        internal static readonly string UserAdded;
        internal static readonly string CustomerAdded;
        internal static readonly string ColorNameInvalid;
        internal static readonly string CarUndelivered;
        internal static readonly string RentalAdded;
        internal static readonly string BrandNameInvalid;
        public static string NameInvalid = "Geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";

        public static string CarAdded = "Ürün Eklendi";
        public static string CarDeleted = "Ürün Silindi";
        public static string CarUpdated = "Ürün Güncellendi";
        public static string CarsListed = "Ürünler Listelendi";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandListed = "Markalar Listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorsListed = "Renkler Listelendi";
        internal static string CannotBeRented;
        internal static string NoCar;
        internal static string CarDescriptionInvalid;
        internal static string CarDailyPriceInvalid;
    }
}
