using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddProduct = "new product added";
        public static string DeleteProduct = "product deleted";
        public static string UpdateProduct = "product updated";

        public static string AddCategory = "new category added";
        public static string DeleteCategory = "category deleted";
        public static string UpdateCategory = "category updated";

        public static string UserNotFound = "Kullanici Bulunamadi";
        public static string PasswordError = "Şifre Hatali";
        public static string SuccessfulLogin = "Sisteme Giris Basarili";
        public static string UserAlreadyExists = "Kullanici Zaten Mevcut";
        public static string UserRegistered = "Kullanici Basariyla Kaydedildi";
        public static string AccessTokenCreated = "Access Token Basariyla Olusturuldu";

        public static string ProductNameAlreadyExists="Bu isimde zaten ürün var";
        public static string CategoryNameAlreadyExists = "Bu isimde zaten kategori var";
        public static string CategoryCount = "kategori ekleme limitiniz doldu.";
        public static string AuthorizationDenied="Yetkiniz yok! ";
    }
}
