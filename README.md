# ✅ Görev Yöneticisi API

Bu proje, ASP.NET Core Web API kullanılarak geliştirilmiş bir **görev yönetim sistemi**dir. Kullanıcılar giriş yaparak kendi görevlerini oluşturabilir, güncelleyebilir ve silebilirler. API JWT (JSON Web Token) ile kimlik doğrulama ve yetkilendirme mekanizmasına sahiptir.

---

## ✨ Proje İçeriği
- **ASP.NET Core Web API** ile RESTful servisler
- **MSSQL** veritabanı kullanımı
- **Entity Framework Core** ile veritabanı işlemleri
- **JWT Authentication** ile kimlik doğrulama ve yetkilendirme
- **Swagger UI** ile API dokümentasyonu

---

## ⚡ Kurulum

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/hasannaysall/GorevYoneticisi.git
cd GorevYoneticisi
```

### 2. Bağımlılıkları Yükleyin
```bash
dotnet restore
```

### 3. Veritabanı Bağlantısını Yapılandırın
**`appsettings.json`** dosyasında **ConnectionStrings** kısmını düzenleyin:
```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\hasan\\OneDrive\\Belgeler\\GorevYoneticisiDb.mdf;Integrated Security=True;Connect Timeout=30"
}
```

### 4. Veritabanını Migrasyonlarla Oluşturun
```bash
dotnet ef database update
```

### 5. Projeyi Çalıştırın
```bash
dotnet run
```

---

## 🔒 Kimlik Doğrulama & JWT Kullanımı

1. **Giriş yaparak JWT Token alın:**
   - **Endpoint:** `POST /api/Auth/login`
   - **Request Body:**
     ```json
     {
       "kullaniciAdi": "admin",
       "sifre": "123456"
     }
     ```
   - **Dönen JWT Token:**
     ```json
     {
       "Token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
     }
     ```

2. **JWT Token ile Yetkilendirilmiş API isteği gönderin:**
   - **Header'a** şu bilgiyi ekleyin:
     ```http
     Authorization: Bearer [JWT_TOKEN]
     ```
   - **Örnek GET isteği (Postman veya cURL ile):**
     ```bash
     curl -X GET "https://localhost:7139/api/Task" \
     -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..." \
     -H "accept: application/json"
     ```

---

## ⚖ API Endpoint'leri

### **Kullanıcı Authentication**
| HTTP Metodu | Endpoint          | Açıklama |
|------------|-----------------|------------|
| `POST`    | `/api/Auth/login` | Kullanıcı girişi ve JWT token alma |

### **Görev CRUD** (Yetkilendirme Gerekli!)
| HTTP Metodu | Endpoint           | Açıklama |
|------------|------------------|------------|
| `GET`    | `/api/Task`       | Tüm görevleri getir |
| `GET`    | `/api/Task/{id}`  | Belirtilen ID'li görevi getir |
| `POST`   | `/api/Task`       | Yeni bir görev ekle |
| `PUT`    | `/api/Task/{id}`  | Belirtilen görevi güncelle |
| `DELETE` | `/api/Task/{id}`  | Belirtilen görevi sil |

---

## ✨ Swagger UI
API'yi test etmek için Swagger UI'yi kullanabilirsiniz.

**Swagger Arayüzünü Aç:**
```
https://localhost:7139/swagger/index.html
```

---


