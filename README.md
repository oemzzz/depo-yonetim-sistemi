Depo Yönetim Sistemi
Fabrika ortamındaki depo operasyonlarını optimize etmek, raflardaki ürün hareketlerini anlık izlemek ve kullanıcı bazlı sorumluluk takibi yapmak amacıyla geliştirilmiş bir envanter yönetim sistemidir.

Projenin Amacı ve Özellikleri
Bu proje; hangi kullanıcının, hangi fabrikada, hangi raf üzerinden hangi üründen kaç adet alıp bıraktığını (audit trail) izlemek ve stok dengesini korumak için tasarlanmıştır.

Kullanıcı ve Rol Takibi: Depo içerisindeki hareketleri gerçekleştiren personelin kaydı.

Raf ve Lokasyon Bazlı Envanter: Hangi rafta hangi üründen kaç adet bulunduğunun anlık takibi.

Hareket Geçmişi (Audit Trail): Ürünlerin giriş/çıkış tarihlerinin ve işlem yapan kullanıcıların loglanması.

Kullanılan Teknolojiler
Backend: .NET, C#

Veritabanı Mimarisi: Entity Framework Core (Code First yaklaşımı)

Veritabanı Yönetimi: SQL Server, LINQ

Veritabanı Mimarisi (Code First)
Projede Code First yaklaşımı benimsenmiştir. Temel varlıklar (Entities) ve ilişkiler şu yapı üzerine kurulmuştur:

Users: Sistemi kullanan fabrika personeli.

Factories & Depots: Fabrika ve depo lokasyon bilgileri.

Racks: Depo içindeki raf yapıları.

Products: Depolanan ürün envanteri.

InventoryTransactions: Hangi kullanıcının hangi raf üzerinden ne kadar ürün alıp bıraktığını tutan hareket tablosu.
