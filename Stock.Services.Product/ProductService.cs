﻿namespace Stock.Services.Product
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BL.DtoEntities;
    using BL.Services.Abstract;
    using BL.Services.Concrete;
    using BL.Repositories.Concrete;

    public class ProductService : IProductService
    {
        private readonly Lazy<IElectronicBookService> _electronicBookService;
        private readonly Lazy<ISmartWatchService> _smartWatchService;
        private readonly Lazy<IPhoneService> _phoneService;

        public ProductService()
        {
            _smartWatchService = new Lazy<ISmartWatchService>(() => new SmartWatchService());
            _electronicBookService = new Lazy<IElectronicBookService>(() => new ElectronicBookService());
            _phoneService = new Lazy<IPhoneService>(() => new PhoneService());
        }

        public string GetData(int value)
        {
            return $"You entered: {value}";
        }

        public void AddProduct(PhoneDto phone)
        {
            _phoneService.Value.Insert(phone);
        }

        public void AddProduct(ElectronicBookDto electronicBook)
        {
            _electronicBookService.Value.Insert(electronicBook);
        }

        public void AddProduct(SmartWatchDto smartWatch)
        {
            _smartWatchService.Value.Insert(smartWatch);
        }

        public void AddProducts(List<ProductDto> products)
        {
            _phoneService.Value.Insert(products.OfType<PhoneDto>());
            _electronicBookService.Value.Insert(products.OfType<ElectronicBookDto>());
            _smartWatchService.Value.Insert(products.OfType<SmartWatchDto>());
        }

        public void ImportProducts(FileDto file)
        {
            var repository = new DataRepository();
            _phoneService.Value.Import(repository, file);
            _electronicBookService.Value.Import(repository, file);
            _smartWatchService.Value.Import(repository, file);
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var phones = _phoneService.Value.GetAll();
            var electronicBooks = _electronicBookService.Value.GetAll();
            var smartWatches = _smartWatchService.Value.GetAll();

            var productsDto = new List<ProductDto>();
            productsDto.AddRange(phones);
            productsDto.AddRange(electronicBooks);
            productsDto.AddRange(smartWatches);

            return productsDto;
        }
    }
}
