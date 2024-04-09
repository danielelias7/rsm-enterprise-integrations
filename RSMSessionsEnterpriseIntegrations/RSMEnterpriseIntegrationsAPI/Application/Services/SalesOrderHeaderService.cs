namespace RSMEnterpriseIntegrationsAPI.Application.Services
{
    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Application.Exceptions;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class SalesOrderHeaderService : ISalesOrderHeaderService
    {
        private readonly ISalesOrderHeaderRepository _salesOrderHeaderRepository;
        public SalesOrderHeaderService(ISalesOrderHeaderRepository repository)
        {
            _salesOrderHeaderRepository = repository;
        }

        public async Task<int> CreateSalesOrderHeader(CreateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            if (salesOrderHeaderDto is null
                // || string.IsNullOrWhiteSpace(salesOrderHeaderDto.SalesOrderNumber)
                )
            {
                throw new BadRequestException("SalesOrderHeader info is not valid.");
            }

            SalesOrderHeader salesOrder = new()
            {
                RevisionNumber = salesOrderHeaderDto.RevisionNumber,
                Status = salesOrderHeaderDto.Status,
                OnlineOrderFlag = salesOrderHeaderDto.OnlineOrderFlag,
                CustomerId = salesOrderHeaderDto.CustomerId,
                BillToAddressId = salesOrderHeaderDto.BillToAddressId,
                ShipToAddressId = salesOrderHeaderDto.ShipToAddressId,
                ShipMethodId = salesOrderHeaderDto.ShipMethodId
            };

            return await _salesOrderHeaderRepository.CreateSalesOrderHeader(salesOrder);
        }

        public async Task<int> DeleteSalesOrderHeader(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("Id is not valid.");
            }
            var salesOrder = await ValidateSalesOrderHeaderExistence(id);
            return await _salesOrderHeaderRepository.DeleteSalesOrderHeader(salesOrder);
        }

        public async Task<IEnumerable<GetSalesOrderHeaderDto>> GetAll()
        {
            var salesOrders = await _salesOrderHeaderRepository.GetAllSalesOrderHeader();
            List<GetSalesOrderHeaderDto> salesOrderHeaderDto = [];

            foreach (var salesOrder in salesOrders)
            {
                GetSalesOrderHeaderDto dto = new()
                {
                    SalesOrderId = salesOrder.SalesOrderId,
                    RevisionNumber = salesOrder.RevisionNumber,
                    OrderDate = salesOrder.OrderDate,
                    DueDate = salesOrder.DueDate,
                    Status = salesOrder.Status,
                    OnlineOrderFlag = salesOrder.OnlineOrderFlag,
                    CustomerId = salesOrder.CustomerId,
                    BillToAddressId = salesOrder.BillToAddressId,
                    ShipToAddressId = salesOrder.ShipToAddressId,
                    ShipMethodId = salesOrder.ShipMethodId,
                    SubTotal = salesOrder.SubTotal,
                    TaxAmt = salesOrder.TaxAmt,
                    Freight = salesOrder.Freight,
                    ModifiedDate = salesOrder.ModifiedDate
                };

                salesOrderHeaderDto.Add(dto);
            }

            return salesOrderHeaderDto;
        }

        public async Task<GetSalesOrderHeaderDto?> GetSalesOrderHeaderById(int id)
        {
            if (id <= 0)
            {
                throw new BadRequestException("SalesOrderId is not valid");
            }

            var salesOrder = await ValidateSalesOrderHeaderExistence(id);

            GetSalesOrderHeaderDto dto = new()
            {
                SalesOrderId = salesOrder.SalesOrderId,
                RevisionNumber = salesOrder.RevisionNumber,
                OrderDate = salesOrder.OrderDate,
                DueDate = salesOrder.DueDate,
                Status = salesOrder.Status,
                OnlineOrderFlag = salesOrder.OnlineOrderFlag,
                CustomerId = salesOrder.CustomerId,
                BillToAddressId = salesOrder.BillToAddressId,
                ShipToAddressId = salesOrder.ShipToAddressId,
                ShipMethodId = salesOrder.ShipMethodId,
                SubTotal = salesOrder.SubTotal,
                TaxAmt = salesOrder.TaxAmt,
                Freight = salesOrder.Freight,
                ModifiedDate = salesOrder.ModifiedDate
            };
            return dto;
        }

        public async Task<int> UpdateSalesOrderHeader(UpdateSalesOrderHeaderDto salesOrderHeaderDto)
        {
            if (salesOrderHeaderDto is null)
            {
                throw new BadRequestException("SalesOrderHeader info is not valid.");
            }
            var salesOrder = await ValidateSalesOrderHeaderExistence(salesOrderHeaderDto.SalesOrderId);

            // salesOrder.SalesOrderNumber = string.IsNullOrWhiteSpace(salesOrderHeaderDto.SalesOrderNumber) ? salesOrder.SalesOrderNumber : salesOrderHeaderDto.SalesOrderNumber;

            // salesOrderHeaderDto.SalesOrderNumber

            return await _salesOrderHeaderRepository.UpdateSalesOrderHeader(salesOrder);
        }

        private async Task<SalesOrderHeader> ValidateSalesOrderHeaderExistence(int id)
        {
            var existingSalesOrderHeader = await _salesOrderHeaderRepository.GetSalesOrderHeaderById(id)
                ?? throw new NotFoundException($"SalesOrderHeader with Id: {id} was not found.");

            return existingSalesOrderHeader;
        }

    }
}
