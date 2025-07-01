# System Architecture
## រចនាសម្ព័ន្ធរបស់ប្រព័ន្ធ (Systems Structure)
រចនាសម្ព័ន្ធរបស់ប្រព័ន្ធព័ត៌មានមួយចែកចេញជាបីផ្នែក៖
- Presentation Layer គឺជា User Interface ដែលជាផ្ទៃសម្រាប់ទំនាក់ទំនងផ្ទាល់ជាមួយអ្នកប្រើប្រាស់ ដើម្បីបញ្ចូលទិន្នន័យ ស្វែងរក កែប្រែ ឬលុបព័ត៌មាន។
- Business Logic (Application Logic) Layer គឺជាផ្នែកសម្រាប់ដោះស្រាយបញ្ហាទាក់ទងនឹងដំណើរការពាណិជ្ជកម្ម ដោយ Programmers សរសេរកូដតាមលក្ខខណ្ឌ និងគោលការណ៍ដែលបានកំណត់។ 
- Data Layer គឺជាផ្នែកសម្រាប់ផ្ទុកទិន្នន័យជានិរន្តរ៍ក្នុងតារាង។
## ស្ថាបត្យកម្មរបស់ប្រព័ន្ធ (Systems Architecture)
ជាទូទៅប្រព័ន្ធព័ត៌មានចែកចេញជាបីប្រភេទ៖
- Desktop Systems គឺជាប្រព័ន្ធដែលកើតឡើងដោយ DBMS ធម្មតា ដូចជា Microsoft Access ដែលអនុញ្ញាតឱ្យអ្នកប្រើប្រាស់ម្នាក់ ឬពីរបីនាក់ដំណើរការលើទិន្នន័យក្នុងពេលតែមួយ។
- Client-Server Systems គឺជាប្រព័ន្ធដែលត្រូវបានបង្កើតឡើងដោយ DBMS Server ដូចជា SQL Server, Oracle, និង MySQL។  Client-Server System ចែកចេញជាពីរប្រភេទទៀត៖
  - Fat Client-Server Systems គឺជាប្រព័ន្ធដែល Presentation Layer និង Application Logic Layer ត្រូវបានបង្កើតឡើងជាមួយគ្នា និងដំណើរការនៅក្នុង Client Computer ខណៈ Data Layer ស្ថិតនៅក្នុង Server Computer។ Fat Client-Server Systems ដំណើរការយឺតជាង Thin Client-Server Systems ព្រោះការដោះស្រាយបញ្ហាប្រព្រឹត្តទៅក្នុង Client Computer ហើយត្រូវទាញទិន្នន័យទាំងអស់ពី Server Computer មកកាន់ Client Computer ដែលធ្វើឱ្យ Network យឺត ប៉ុន្តែវាត្រូវបានបង្កើតឡើងដោយប្រើរយៈពេលខ្លីជាង។
  - Thin Client-Server Systems គឺជាប្រព័ន្ធដែល Application Logic Layer និង Data Layer ត្រូវបានបង្កើតឡើងជាមួយគ្នានៅក្នុង Database របស់ DBMS Server ហើយដំណើរការក្នុងការដោះស្រាយបញ្ហានៅឯ Server Computer។ ចំណែកឯ Presentation Layer ស្ថិតនៅក្នុង Client Computer មាននាទីបញ្ជូនទិន្នន័យ និងទទួលលទ្ធផលព័ត៌មានតែប៉ុណ្ណោះ។
- Distributed Systems គឺជាប្រព័ន្ធដែលមានលក្ខណៈស្រដៀងទៅនឹង Client-Server Systems ដែរ គ្រាន់តែ DBMS Server ត្រូវបានបញ្ចូលទៅក្នុង Server Computer នៃគ្រប់ Nodes ទាំងអស់របស់ Computer Network។

**ចំណាំ**: Client-Server Systems ត្រូវបានបង្កើតក្នុងលក្ខណៈ Two-tier ឬ Three-tier។ ចំពោះ Two-tier គឺ Systems ស្ថិតក្នុងប្រភេទ Fat Client-Server Systems ឬ Thin Client-Server Systems។ ចំណែកឯ Three-tier ផ្នែកទាំងបីស្ថិតនៅដាច់ពីគ្នា ដោយគេបានបង្កើត Middle Layer មួយទៀតហៅថា Application Server ដែលមាននាទីដំណើរការ Application Logic ឬ Business Logic។ នៅក្នុង Three-tier Systems គេបានប្រើ Software មួយគឺ Middleware ក្នុងការធ្វើទំនាក់ទំនងរវាងផ្នែកទាំងបី។
# User Interface Design
## ការរចនា User Interface (User Interface Design)
User Interface គឺជាផ្ទៃសម្រាប់ទំនាក់ទំនងដោយផ្ទាល់ជាមួយអ្នកប្រើប្រាស់ ដើម្បីបញ្ចូលទិន្នន័យ ស្វែងរក កែប្រែ ឬលុបព័ត៌មាន ។  
ប្រភេទរបស់ User Interface មានពីរ ៖
- Single-Table Form ៖ ទាក់ទងជាមួយ Table តែមួយគត់ (Strong Entity Set) សម្រាប់ Insert, Search, Update ទិន្នន័យ ។
- Multi-Table Form ៖ ទាក់ទងជាមួយ Tables ពីរឡើងទៅ (Table សំខាន់កើតពី Weak Entity Set) ។ វាចែកចេញជាពីរទៀត ៖
  - Normal Multi-Table Form ៖ មិនទាក់ទងនឹង Table ដែលកើតចេញពី Associative Entity Set ទេ ។
  - Master-Detail Form ៖ ទាក់ទងនឹង Tables ជាច្រើន រួមទាំង Table ដែលកើតចេញពី Associative Entity Set ផងដែរ ។ វាមានពីរផ្នែក ៖
    - ផ្នែក Master ៖ តម្លៃតែមួយគត់ក្នុង Control នីមួយៗ ទាក់ទងនឹង Table សំខាន់កើតពីព្រឹត្តិការណ៍ ។
    - ផ្នែក Detail ៖ មាន Records ច្រើនក្នុង List View ឬ Data Grid View ទាក់ទងនឹង Table កើតពី Associative Entity Set ។  

គោលបំណងរបស់ User Interface Design ៖ ងាយស្រួលរៀន ងាយយល់ និងងាយស្រួលប្រើប្រាស់ ។  
គោលការណ៍របស់ User Interface Design រួមមាន៖ រៀបចំ Interface តាមមែកធាងមុខងាររបស់ប្រព័ន្ធពាណិជ្ជកម្ម ប្រើពាក្យនិងរូបភាពសមស្រប កំណត់ឱ្យដំណើរការលឿន មាន Feedback Information កំណត់ទីតាំងការងារ (ចំណងជើង Form) មិនត្រូវមាន Horizontal Scrollbar ប្រើ Control ត្រូវតាមការងារ កំណត់ Cursor ឱ្យផ្លាស់ទីតាមលំដាប់ មិនអនុញ្ញាតឱ្យ User បញ្ចូល/កែប្រែតម្លៃក្នុង Control ដែលបញ្ចេញលទ្ធផល ។
## Report Design
Report គឺជាលទ្ធផលចុងក្រោយរបស់ប្រព័ន្ធព័ត៌មានដែលត្រូវបោះពុម្ពលើក្រដាសសម្រាប់អតិថិជន ឬអ្នកគ្រប់គ្រង ដូចជាវិក្កយបត្រ របាយការណ៍លក់ ប្រចាំខែ/ត្រីមាស/ឆ្នាំ ។  
តួនាទីនៃផ្នែកនីមួយៗរបស់ Report មាន ៧ ផ្នែក ៖
- Report Header ៖ ដាក់ Logo, ចំណងជើង Report, ឈ្មោះក្រុមហ៊ុន បង្ហាញតែម្ដងគត់នៅទំព័រទី១ ។
- Page Header ៖ ស្រដៀង Report Header តែបង្ហាញលើគ្រប់ទំព័រទាំងអស់ អាចរៀបចំ Labels សម្រាប់ក្បាលជួរឈរ ។
- Group Header ៖ កើតឡើងដោយសារកំណត់ Field ណាមួយជា Group Header បង្ហាញតាមក្រុមនៃតម្លៃដូចគ្នា អាចរៀបចំ Fields ជាផ្នែក Master និង Labels ។
- Detail ៖ រៀបចំ Text Boxes សម្រាប់បង្ហាញ Records ជាតារាង អាចដាក់ Logo, ចំណងជើង Report, Labels និង Text boxes សម្រាប់ប័ណ្ណសម្គាល់ ។
- Group Footer ៖ មាននាទីគណនាលទ្ធផលបូកសរុប រាប់ចំនួន Records គណនាមធ្យមភាគ រកតម្លៃតូច/ធំបំផុត ដោយប្រើ Aggregate Functions តាមក្រុមនៃតម្លៃដូចគ្នា ។
- Page Footer ៖ ដាក់លេខទំព័រ ឬព័ត៌មានផ្សេងៗ បង្ហាញនៅខាងក្រោមបំផុតនៃគ្រប់ទំព័រ ។
- Report Footer ៖ មាននាទីគណនាលទ្ធផលបូកសរុប រាប់ចំនួន Records គណនាមធ្យមភាគ រកតម្លៃតូច/ធំបំផុត ដោយប្រើ Aggregate Functions លើ Records ទាំងអស់នៃ Report បង្ហាញតែម្ដងគត់នៅទំព័រចុងក្រោយ ។

គោលបំណងរបស់ Report Design ៖ ងាយស្រួលអាន ងាយយល់ ងាយស្រួលរកព័ត៌មាន កាត់បន្ថយបរិមាណនៃការបោះពុម្ព ។  
គោលការណ៍របស់ Report Design ៖ កំណត់ច្បាស់នូវតួនាទីនៃផ្នែកនីមួយៗ រៀបចំផ្នែកខាងលើនិងខាងក្រោមឱ្យមានលក្ខណៈស្តង់ដារ ដាក់ Description ឱ្យច្បាស់លាស់ តម្រៀបទិន្នន័យតាមលំដាប់កើនឬចុះ ចេះ High Light, Bold ឬដាក់បន្ទាត់ព័ទ្ធជុំវិញទិន្នន័យចាំបាច់ ចេះសង្ខេបព័ត៌មាន ។

# General
```
I dont't know
```
# Stored Procedure
```sql
CREATE PROCEDURE spUpdateCustomer
    @id INT, @cusName VARCHAR(100), @cusContact VARCHAR(15)
AS
    UPDATE [dbo].[tbCustomers]
    SET CusName = @cusName,
    CusContact = @cusContact
    WHERE cusID = @id
GO
EXEC spUpdateCustomer 1, 'jame', '012223344'
```
# Function
```sql
CREATE FUNCTION fnGetAllCustomer() RETURNS TABLE
AS 
    RETURN (SELECT cusID, CusName FROM [dbo].[tbCustomers] )
GO
SELECT * FROM fnGetALLCustomer()
GO
CREATE FUNCTION fnGetNumber() RETURNS INT 
AS
    BEGIN

        RETURN 10
    END
GO
SELECT fnGetNumber()
```
# Cursor
```sql
    -- Process each item in @OD
    DECLARE @ProCode VARCHAR(13), @ProName VARCHAR(100),
            @Qty SMALLINT, @Price MONEY, @Amount MONEY;

    DECLARE csOrder CURSOR SCROLL DYNAMIC FOR 
        SELECT ProCode, ProName, Qty, Price, Amount FROM @OD;

    OPEN csOrder;

    FETCH NEXT FROM csOrder INTO @ProCode, @ProName, @Qty, @Price, @Amount;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Update product quantity
        UPDATE tbProducts
        SET Qty = Qty - @Qty
        WHERE ProCode = @ProCode;

        -- Insert into tbOrderDetail
        INSERT INTO tbOrderDetail (OrdCode, ProCode, ProName, Qty, Price, Amount)
        VALUES (@OrdCode, @ProCode, @ProName, @Qty, @Price, @Amount);

        FETCH NEXT FROM csOrder INTO @ProCode, @ProName, @Qty, @Price, @Amount;
    END

    CLOSE csOrder;
    DEALLOCATE csOrder;
```
# View
```sql
CREATE VIEW [Brazil Customers] 
AS
    SELECT CustomerName, ContactName
    FROM Customers
    WHERE Country = 'Brazil';
GO
SELECT * FROM [Brazil Customers];
```
# Remark
There is no BEGIN-END for CREATE FUNCTION that return table  
BEGIN-END is optional for CREATE PROCEDURE  
BEGIN-ENd is a must for CREATE FUNCTION that return scalar  
There is no BEGIN-END for CREATE VIEW

when create or execute function, the function must have ()  
when create procedure, if it have 1 or more paramenters the () is optional else it must not have ()  
when execute procedure, it must not have ()  
