﻿namespace Stock.Services.Product
{
    using System.ServiceModel;
    using System.Collections.Generic;
    using BL.DtoEntities;

    [ServiceContract]
    public interface IProductService
    {
        [OperationContract(Name = "AddPhone")]
        void AddProduct(PhoneDto phone);

        [OperationContract(Name = "AddElectronicBook")]
        void AddProduct(ElectronicBookDto electronicBook);

        [OperationContract(Name = "AddSmartWatch")]
        void AddProduct(SmartWatchDto smartWatch);

        [OperationContract]
        void AddProducts(List<ProductDto> products);

        [OperationContract]
        void ImportProducts(FileDto file);

        [OperationContract]
        IEnumerable<ProductDto> GetAllProducts();

        [OperationContract]
        IEnumerable<PhoneDto> GetPhonesForManufacturer(int idManufacturer, string orderDirection, string orderBy);

        [OperationContract]
        IEnumerable<SmartWatchDto> GetSmartWatchesForManufacturer(int idManufacturer);

        [OperationContract]
        IEnumerable<ElectronicBookDto> GetElectronicBooksForManufacturer(int idManufacturer);
    }
}
