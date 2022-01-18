# AvtoService Api

###### Sistem-ə giriş etmək


    /api/auths/register
    {
      firstName
      lastName
      email
      password
    }



Sistem-ə admin kimi daxil olmaq üçün aşağıdaki uzantıya doğru email və parolu göndərmək lazımdı . Doğru giriş zamanı Api sənə {token} döndərəcək . Onu bəzi requestlərdə göndərmək lazımdır


    /api/auths/login
    {
      email,password
    }




###### Maşın üçün requestlər


    api/cars/getall
    -masinlarin hamsini getirir
    
    api/cars/getmains
    -ana sehifede gorunen masinlar
    
    api/cars/getcars?brandId=1
    -masinlardan markasinin id-si 1 olanları getirir  (istediyin markanin id-sini yazib hemin markadaki masinlari getire bilersen)
    
    api/cars/getcarbyid?carid=1
    -masinlardan id-si 1 olan masini getirir (maşının haqqında ətraflı hissəsi üçün bundan istifadə elə)  
    
    api/cars/showinhome
    -maşının id dəyərini vermək bəs edir  (bu "anasəhifədə göstər" butonuna basılanda işləyəcək - ana səhifədə göstərəcək)
    
    api/cars/removefromhome
    -maşının id dəyərini vermək bəs edir  (bu "anasəhifədə göstər" butonuna basılıb ləğv ediləndə işləyəcək - ana səhifədə göstərməyəcək)
    
    api/cars/delete
    -masini silir dəyər olaraq id-sini vermək bəs edir 
    
    api/cars/update
    -masini update edir dəyərləri əlavə edərkən verilən dəyərlər ola bilər 
    
    api/cars/add
    -maşın əlavə etmək üçün request  (javascriptdə formdata-dan istifadə edib özəllikləri qoya bilərsən)
    
    {
      phoneNumber:string,
      city  :string,
      brandId  :integer,
      model  :string,
      graduationDate  :string,
      banName  :string,
      colorName  :string,
      motor  :string,
      motorPower  :string,
      fuelType  :string,
      gearBox  :string,
      transmitter  :string
      isNew  :boolean     - true ya false deyerini alir
      price   :string
      detail  :string
      mainPhoto  :file,
      photos  : file array tipi
      carSupplies  :number array tipi    - maşın təchizatları seçildikdə İd-ləri bir arraya əlavə edib buna at
    }
  
  
  

###### Ehtiyat hissələri üçün requestlər


    api/spareparts/getall  
    
    api/spareparts/getbybrand?brandid=1  - markalara görə filtrələmək
    
    api/spareparts/getbymodel?modelid=1  - modellərə görə filtrələmək
    
    api/spareparts/getbyyear?year=2000   - il-ə görə filtrələmək
    
    api/spareparts/get?id=1              - id-si 1 olanın detalları gəlir
    
    api/spareparts/add 
    
    
     deyerler:  
     {
       Year
       ModelId,
       BrandId,
       Detail,
       Photos
    }           
          
    api/spareparts/delete
    api/spareparts/update
    
   

###### Ehtiyat hisselerinin videolari


    api/sparepartvideos/getvideos    - {Url  Description}
    api/sparepartvideos/add
    {
      File,
      Description  - Melumat
    }
    api/sparepartvideos/delete?videoid=1  - Id-si 1 olan videonu silir



###### Daşıma xidmətləri üçün requestlər


    api/transcares/getall  
    api/transcares/get?id=1              - id-si 1 olanın detalları gəlir
    api/transcares/add 
     deyerler:  
     {
       Detail
       TransCarePhotos
       
     }           
          
    api/transcares/delete
    api/transcares/update
    
    

###### Modeller üçün requestlər
  
  
    api/models/getmodelsbybrand?brandid=1   - Id-si 1 olan markanin modellerini getirir
    api/models/add   - model elave edir
    {
     Name, BrandId
    }



###### Markalar ucun requestler


    api/brands/add
    api/brands/getall 


