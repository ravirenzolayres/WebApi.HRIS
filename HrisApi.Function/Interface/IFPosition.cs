using HrisApi.Model;
using HrisApi.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HrisApi.Function.Interface
{
    public interface IFPosition
    {
        Task<Position> Add(string loggedUser,Position position);
        Task<Position> Edit(string loggedUser,Position position);
        Task<Position> Delete(string loggedUser,Position position);
        Task<Position> Get(int id);
        Task<Position> Get(Func<Position, bool> condition);
        Task<List<Position>> GetAll();
        Task<List<Position>> GetAll(Func<Position, bool> condition);
        Task<int> GetCode(string positionCode);
    }
}
