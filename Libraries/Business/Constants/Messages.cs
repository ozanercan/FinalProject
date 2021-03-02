using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string ProductNameAlreadyExists = "Böyle bir ürün adı zaten var.";
        public static string ProductsListed = "Ürünler listelendi.";
        public static string ProductGet = "Ürün getirildi.";
        public static string ProductGetProductDetails = "Ürün detayları listelendi.";
        public static string ProductGetByUnitPrice = "Birim fiyatına uygun ürünler listelendi.";
        public static string ProductGetAllByCategory = "Kategoriye göre ürünler listelendi.";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir.";
        public static string ProductUpdated = "Ürün güncellendi.";

        public static string CategoryLimitExceded = "Kategori limiti aşıldığı ürün eklenemez.";

        public static string CategoryCountError = "Kategori miktari bulunamadı.";

        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "Kullanıcı kayıt edildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre yanlış.";
        public static string UserAlreadyExists = "Kullanıcı zaten var.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
