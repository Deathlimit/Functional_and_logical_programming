open System
open License
 
 
let Proverka =
    let license_Daniil = License(
        lastName = "Решетка",
        firstName = "Даниил",
        patronymicName = "Владимирович",
        birthDateAndPlace = "01.01.1995 г. Краснодар",
        issueDate = DateTime(2010, 1, 1),
        expiryDate = DateTime(2030, 1, 1),
        issuingAuthority = "ГИБДД 1234",
        licenseNumber = "12 34 567890",
        address = "г. Краснодар, ул. Ставропольская, д. 1",
        categories = "B С M")
     
    Console.WriteLine(license_Daniil)

    let license_Nikita = License(
        lastName = "Миков",
        firstName = "Никита",
        patronymicName = "Сергеевич",
        birthDateAndPlace = "01.01.2000 г. Краснодар",
        issueDate = DateTime(2020, 1, 1),
        expiryDate = DateTime(2030, 1, 1),
        issuingAuthority = "ГИБДД 1234",
        licenseNumber = "12 34 567899",
        address = "г. Краснодар, ул. Ставропольская, д. 2",
        categories = "B С M")
     
    Console.WriteLine(license_Nikita)
 

 
    Console.WriteLine($"Водительское удостоверение 1 = Водительское удостоверение 1 {license_Daniil.Equals(license_Daniil)}")
    Console.WriteLine($"Водительское удостоверение 1 = Водительское удостоверение 2 {license_Daniil.Equals(license_Nikita)}")
    Console.WriteLine($"Водительское удостоверение 1 > Водительское удостоверение 2 {license_Daniil > license_Nikita}")
 
Proverka
 