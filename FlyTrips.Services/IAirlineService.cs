﻿using FlyTrips.DTO.Airline;
using FlyTrips.Entities;

namespace FlyTrips.Services
{
    public interface IAirlineService : IBaseService<Airline> 
    {
        AirlineResponseDto Create(AirlineCreateUpdateDto dto);

        new AirlineResponseDto GetById(int id);

        new IEnumerable<AirlineResponseDto> GetAll();

        AirlineResponseDto Update(int id, AirlineCreateUpdateDto dto);

        void Delete(int id);
    }
}