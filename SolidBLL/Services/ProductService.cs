﻿using SolidDAL.UoW;

namespace SolidBLL.Services
{
    public class ProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}